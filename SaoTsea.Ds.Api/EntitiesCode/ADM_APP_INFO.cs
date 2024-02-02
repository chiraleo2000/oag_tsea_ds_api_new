using DevExpress.Xpo;
using Microsoft.AspNetCore.Http;

namespace SaoTsea.Ds.Api.EntitiesCode
{

	public partial class ADM_APP_INFO
	{
		public ADM_APP_INFO(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }

		[NonPersistent] public IFormFile UPLOAD_IMAGE { get; set; }
	}

}
