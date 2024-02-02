namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class DGA
	{
		public string Result { get; set; }
	}

	public class DGAResult
    {
		public int status { get; set; }
		public string message { get; set; }
		public string errorMessage { get; set; }
		public DGADataResult data { get; set; }
	}

	public class DGADataResult
	{
		public string requestId { get; set; }
	}


	public class DGAPutResult
	{
		public int status { get; set; }
		public string message { get; set; }
		public string errorMessage { get; set; }
	}
}
