using DevExpress.Xpo;
using Microsoft.AspNetCore.Http;

namespace SaoTsea.Ds.Api.EntitiesCode
{

	public partial class BPM_PROC_INST_ATTACHMENT
	{
		public BPM_PROC_INST_ATTACHMENT(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }

		[NonPersistent] public IFormFile File { get; set; }
	}

}
