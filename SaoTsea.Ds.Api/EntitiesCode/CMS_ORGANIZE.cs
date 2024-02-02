using DevExpress.Xpo;
using Microsoft.AspNetCore.Http;

namespace SaoTsea.Ds.Api.EntitiesCode
{

	public partial class CMS_ORGANIZE
	{
		public CMS_ORGANIZE(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }

		[NonPersistent]
		public IFormFile UPLOAD_LOGO { get; set; }
	}

}
