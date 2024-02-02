using System;
using DevExpress.Xpo;

namespace SaoTsea.Ds.Api.EntitiesCode
{

	public partial class BPM_PROC_INST_APPOINTMENT
	{
		public BPM_PROC_INST_APPOINTMENT(Session session) : base(session) { }
		public override void AfterConstruction() { base.AfterConstruction(); }

		[NonPersistent] public DateTime? APPOINTMENT_DATE_NEXT { get; set; }
		[NonPersistent] public int? CONTACT_ID_NEXT { get; set; }
		[NonPersistent] public int? PERSONAL_ID_NEXT { get; set; }
		[NonPersistent] public string APPOINTMENT_PERSONAL_TEL_NO_NEXT { get; set; }
		[NonPersistent] public string _documentId { get; set; }

		//ใช้สำหรับหน้า form-submit
		[NonPersistent] public string FORM_CODE { get; set; }
		[NonPersistent] public string FORM_DOCUMENT_ID { get; set; }
	}

}
