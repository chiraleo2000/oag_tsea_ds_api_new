namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class BpmAttachmentFilterParam: FilterParam
	{
		public int? BpmInstanceId { get; set; }
		public string PublishFlag { get; set; }
		public int? InstAttachmentTypeId { get; set; }
		public int? PersonalId { get; set; }

	}
}
