using DevExpress.Xpo;
using Microsoft.AspNetCore.Http;

namespace SaoTsea.Ds.Api.EntitiesCode
{

    public partial class EDOC_TXN_ASSIGN
    {
        public EDOC_TXN_ASSIGN(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [NonPersistent]
        public IFormFile ATTACHMENT_FILE { get; set; } // ตั้งค่าเพื่ออัพโหลดไฟล์เดียว
        // public IFormFile ATTACHMENT_FILE[] { get; set; } // ตั้งค่าเพื่ออัพโหลดหลายไฟล์
    }

}
