using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SaoTsea.Ds.Api.EntitiesCode;

namespace SaoTsea.Ds.Api.Core
{
    public class EntityJsonResolver : DefaultContractResolver
    {
        public bool SerializeCollections { get; set; } = false;
        public bool SerializeReferences { get; set; } = true;
        public bool SerializeByteArrays { get; set; } = true;
        private static XPDictionary dictionary;
        private readonly bool _excludeNonePersistent;

        public EntityJsonResolver()
        {
            if (dictionary == null)
            {
                dictionary = new ReflectionDictionary();
                dictionary.GetDataStoreSchema(ConnectionHelper.GetPersistentTypes());
            }
        }

        public EntityJsonResolver(bool excludeNonePersistent) : this()
        {
            _excludeNonePersistent = excludeNonePersistent;
        }


        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            XPClassInfo classInfo = dictionary.QueryClassInfo(objectType);
            if (classInfo != null && classInfo.IsPersistent)
            {
                var allSerializableMembers = base.GetSerializableMembers(objectType);
                var serializableMembers = new List<MemberInfo>(allSerializableMembers.Count);
                foreach (MemberInfo member in allSerializableMembers)
                {
                    XPMemberInfo mi = classInfo.FindMember(member.Name);
                    if (!(mi.IsPersistent || mi.IsAliased || mi.IsCollection || mi.IsManyToManyAlias)
                        || ((mi.IsCollection || mi.IsManyToManyAlias) && !SerializeCollections)
                        || (mi.ReferenceType != null && !SerializeReferences)
                        || (mi.MemberType == typeof(byte[]) && !SerializeByteArrays))
                    {
                        bool hasNonPersistent = mi.HasAttribute(typeof(NonPersistentAttribute));
                        if (_excludeNonePersistent && hasNonPersistent)
                        {
                            continue;
                        }

                        if (!hasNonPersistent)
                        {
                            continue;
                        }
                    }

                    serializableMembers.Add(member);
                }

                return serializableMembers;
            }

            return base.GetSerializableMembers(objectType);
        }

        public class XpoCreateConverter : CustomCreationConverter<XPLiteObject>
        {
            private readonly Session _session;
            private readonly bool _useDefault;
            public override bool CanRead => true;

            public XpoCreateConverter(Session session, bool useDefault)
            {
                _session = session;
                _useDefault = useDefault;
            }

            public override XPLiteObject Create(Type objectType)
            {
                return (XPLiteObject)_session.GetClassInfo(objectType).CreateNewObject(_session);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                if (_useDefault)
                {
                    return base.ReadJson(reader, objectType, existingValue, serializer);
                }

                JToken jsonToken = JToken.ReadFrom(reader);
                XPLiteObject xpo;
                using (JsonReader renewReader = jsonToken.CreateReader())
                {
                    xpo = (XPLiteObject)base
                        .ReadJson(renewReader, objectType, existingValue, serializer);
                    foreach (JProperty p in jsonToken.Children().Cast<JProperty>())
                    {
                        XPMemberInfo member = xpo.ClassInfo.FindMember(p.Name);
                        if (member != null && member.IsPersistent)
                        {
                            member.SetModified(xpo, member.GetValue(xpo));
                        }
                    }
                }

                return xpo;
            }
        }
    }
}
