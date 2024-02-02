using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.Metadata.Helpers;

namespace SaoTsea.Ds.Api.Core
{
	public class BetimesUntiOfWork : UnitOfWork
	{
		public BetimesUntiOfWork()
		{
		}

		public BetimesUntiOfWork(XPDictionary dictionary) : base(dictionary)
		{
		}

		public BetimesUntiOfWork(IDataLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer,
			disposeOnDisconnect)
		{
		}

		public BetimesUntiOfWork(IObjectLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer,
			disposeOnDisconnect)
		{
		}

		//กรองเอา property ที่อัพเดท จริงๆ
		protected override MemberInfoCollection GetPropertiesListForUpdateInsert(object theObject, bool isUpdate,
			bool addDelayedReference)
		{
			MemberInfoCollection defaultMembers =
				base.GetPropertiesListForUpdateInsert(theObject, isUpdate, addDelayedReference);
			if (TrackPropertiesModifications && isUpdate)
			{
				MemberInfoCollection members = new MemberInfoCollection(GetClassInfo(theObject));
				foreach (XPMemberInfo mi in defaultMembers)
				{
					if (mi.GetModified(theObject))
						members.Add(mi);
				}

				return members;
			}

			return defaultMembers;
		}
	}
}