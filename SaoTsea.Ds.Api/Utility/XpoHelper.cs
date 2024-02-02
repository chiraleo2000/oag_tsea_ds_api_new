using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.Metadata.Helpers;

namespace SaoTsea.Ds.Api.Utility
{
	//Referent https://github.com/DevExpress-Examples/XPO_how-to-clone-a-persistent-object-e804/blob/13.1.4%2B/CS/CloneHelper.cs
	public static class XpoHelper
	{
		public static T Clone <T>(T source, Session targetSession, bool modified = false) where T : XPBaseObject
		{
			if (source == null)
				return null;

			T target = (T) targetSession.GetClassInfo(source.GetType())
			                            .CreateNewObject(targetSession);

			foreach (XPMemberInfo m in source.ClassInfo.Members)
			{
				if (!m.IsPersistent && !m.HasAttribute(typeof(NonPersistentAttribute)))
                {
					continue;
                }

				if (m is ServiceField)
				{
					continue;
				}

				m.SetValue(target, m.GetValue(source));
				if (modified && m.GetModified(source))
				{
					target.ClassInfo.GetMember(m.Name)
					      .SetModified(target, m.GetValue(source));
				}
			}

			return target;
		}

		public static void CopyValueTo <T>(object start, T destination) where T : XPBaseObject
		{
			if (start == null)
				return;

			var startType = start.GetType();
			foreach (XPMemberInfo m in destination.ClassInfo.PersistentProperties)
			{
				if (m is ServiceField || m.IsKey)
				{
					continue;
				}

				var property = startType.GetProperty(m.Name);
				if (property != null)
				{
					m.SetValue(destination, property.GetValue(start));
				}
			}
		}
	}
}