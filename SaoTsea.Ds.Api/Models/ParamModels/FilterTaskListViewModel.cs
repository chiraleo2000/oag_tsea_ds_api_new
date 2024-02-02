using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
    public class FilterTaskListViewModel
    {
        public FilterSearchMainCondtion SearchMain { get; set; }
        public FilterSearchColumns[] SearchColumns { get; set; }
        public int Offset { get; set; } = 0;
        public int Length { get; set; } = 10;
        public bool UseSort { get; set; }
        public bool SortAscending { get; set; } = true;
        public string SortColumnName { get; set; }
    }

    public class FilterSearchMainCondtion
    {
        public int RoleId { get; set; }
        public RoleInfo RoleInfo { get; set; } // TODO: ทำแบบนี้ไปก่อนย้าย DB ไป SQL SERVER แล้วค่อยเปลี่ยนเป้นดึง current role แทน
        public string TrackingCode { get; set; }
        public string FormCode { get; set; }
        public string CreateDate { get; set; }
        public string GroupStatusCode { get; set; }
        public string StatusCode { get; set; }

    }


    public class FilterSearchColumns
    {
        public string ColumnName { get; set; }
        public string SearchWords { get; set; }
    }
}
