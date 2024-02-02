using DevExpress.Xpo;

namespace SaoTsea.Ds.Api.EntitiesCode
{

	public partial class ADM_USER
	{
		public ADM_USER(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }
	}

}
