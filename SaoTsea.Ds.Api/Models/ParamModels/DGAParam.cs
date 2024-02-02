namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class DGAParam
	{
		public string IdentityId { get; set; }
		public string IdentityType { get; set; }
		public string ApplicationId { get; set; }
		public DGAData Data { get; set; }

	}

	public class DGAData
    {
		public string Name { get; set; }
		public string Url { get; set; }
		public string ReferenceId { get; set; }
		public string ReferenceNumber { get; set; }
	}

	public class DGAPutParam
	{
		public string IdentityId { get; set; }
		public string IdentityType { get; set; }
		public string ApplicationId { get; set; }
		public string RequestId { get; set; }
		public string Status { get; set; }
		public string StatusOther { get; set; }
		public string Remark { get; set; }

		public DGAPutOptionParam Option { get; set; }

	}

	public class DGAPutOptionParam
	{
		public ExternalButtonOption ExternalButtonOption { get; set; }

	}

	public class ExternalButtonOption
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }

	}
}
