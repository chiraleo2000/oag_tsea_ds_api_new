using Microsoft.AspNetCore.Mvc;
using SaoTsea.Ds.Api.Core;

namespace SaoTsea.Ds.Api.Models.ParamModels
{
	public class CamundaSearchParam<T>
	{
		[ModelBinder(typeof(FieldModelBinder))]
		public T Condition { get; set; }
		public int Offset { get; set; }
		public int Length { get; set; }
	}
}
