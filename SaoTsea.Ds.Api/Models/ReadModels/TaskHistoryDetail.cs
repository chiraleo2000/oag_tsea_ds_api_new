using System.Collections.Generic;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class TaskHistoryDetail
	{
		public string TaskId { get; set; }
		public string TaskFormId { get; set; }
		public string DataFormId { get; set; }
		public  Dictionary<string, object>  DataFormSubmission { get; set; }
		public  Dictionary<string, object>  TaskSubmission { get; set; }
	}
}
