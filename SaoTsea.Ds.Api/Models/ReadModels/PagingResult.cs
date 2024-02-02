using System.Collections.Generic;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class PagingResult<T>
	{
		public IEnumerable<T> Data { get;}
		public int TotalCount { get; }

		public PagingResult(IEnumerable<T> values, int total)
		{
			Data = values;
			TotalCount = total;
		}
	}

	public class PagingResult
	{
		public PagingResult(int totalCount, object data)
		{
			TotalCount = totalCount;
			Data = data;
		}

		public int TotalCount { get; set; }
		public object Data { get; set; }
	}
}
