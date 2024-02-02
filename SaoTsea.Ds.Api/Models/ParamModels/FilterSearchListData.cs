namespace SaoTsea.Ds.Api.Models.ParamModels
{
    public class FilterSearchListData
    {
        public FilterSearchColumn[] SearchMain { get; set; }
        public FilterSearchColumn[] SearchColumns { get; set; }
        public bool UseSort{ get; set; }
        public bool SortAscending { get; set; } = true;
        public string SortColumnName { get; set; }
        public int officerOrganizeId { get; set; }
        public int organizeRootId { get; set; }
        public int roleId { get; set; }
        public string sectionCode { get; set; } = "00";
        public int Offset { get; set; } = 0;
        public int Length { get; set; } = 10;
        //public string CandidateUser { get; set; }
    }

    public class FilterSearchColumn
    {
        public string ColumnName { get; set; }
        public string SearchWords { get; set; }
    }

}
