using DevExpress.Xpo;
using Microsoft.AspNetCore.Http;

namespace SaoTsea.Ds.Api.EntitiesCode
{

	public partial class CMS_PERSONAL
	{
		public CMS_PERSONAL(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }

		[NonPersistent]
		public string NEW_PASSWORD { get; set; }
		[NonPersistent]
		public string OLD_PASSWORD { get; set; }
		[NonPersistent]
		public string USER_NAME { get; set; }
		[NonPersistent]
		public IFormFile UPLOAD_SIGNATURE_PICTURE { get; set; }
		[NonPersistent]
		public IFormFile UPLOAD_PICTURE { get; set; }
		[NonPersistent]
		public bool SYNC_USER_CAMUNDA { get; set; } = true;

		[NonPersistent]
		public IFormFile FRONT_PPD_PICTURE { get; set; }
		[NonPersistent]
		public IFormFile BACK_PPD_PICTURE { get; set; }
	}

}
