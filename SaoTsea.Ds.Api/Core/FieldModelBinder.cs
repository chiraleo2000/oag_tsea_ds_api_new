using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SaoTsea.Ds.Api.Core
{
	public class FieldModelBinder: IModelBinder
	{


		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			var queryCollection = bindingContext.ActionContext.HttpContext.Request.Query;
			var target = Activator.CreateInstance(bindingContext.ModelType);
			var targetType = target.GetType();
			var fieldsList = targetType.GetFields();
			foreach (var item in queryCollection)
			{
				FieldInfo field = fieldsList
					.FirstOrDefault(f => f.Name.ToLower() == item.Key.ToLower());
				if (field == null)
				{
					bindingContext.ModelState.TryAddModelError(item.Key, $"Is not member of {targetType}");
					return Task.CompletedTask;
				}

				TypeConverter obj = TypeDescriptor.GetConverter(field.FieldType);
				field.SetValue(target, obj.ConvertFromString(item.Value));
			}

			bindingContext.Result = ModelBindingResult.Success(target);
			return Task.CompletedTask;
		}
	}
}
