using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using SaoTsea.Ds.Api.Core.DataHandlers;

namespace SaoTsea.Ds.Api.Core
{
	public class XpoFormCollectionModelBinder : IModelBinder
	{
		private readonly IDictionary<ModelMetadata, IModelBinder> _propertyBinders;

		public XpoFormCollectionModelBinder(IDictionary<ModelMetadata, IModelBinder> propertyBinders)
		{
			_propertyBinders = propertyBinders;
		}

		public async Task BindModelAsync(ModelBindingContext ctx)
		{
			DBHandlerCore db = ctx.HttpContext.RequestServices.GetService<DBHandlerCore>();

			Session dbSession = null;

			XpoBindingOptionAttribute options = ctx.ActionContext.ActionDescriptor.EndpointMetadata.OfType<XpoBindingOptionAttribute>().FirstOrDefault();

			if (options != null)
			{
				if (options.UseSameSession)
				{
					dbSession = db.Session;
				}
				else
				{
					dbSession = new Session();
				}
			}
			else
			{
				dbSession = new Session();
			}

			XPLiteObject xpObj = (XPLiteObject) Activator.CreateInstance(ctx.ModelType, dbSession);
			bool modified;

			ctx.Model = xpObj;

			ModelMetadata modelMetadata = ctx.ModelMetadata;
			for (int i = 0; i < modelMetadata.Properties.Count; i++)
			{
				modified = false;
				var property = modelMetadata.Properties[i];

				var fieldName = property.BinderModelName ?? property.PropertyName;
				var modelName = ModelNames.CreatePropertyModelName(ctx.ModelName, fieldName);

				ModelBindingResult result;
				using (ctx.EnterNestedScope(
					modelMetadata: property,
					fieldName: fieldName,
					modelName: modelName,
					model: null))
				{
					await BindProperty(ctx);
					result = ctx.Result;
					modified = !property.IsComplexType
					           && ctx.HttpContext.Request.Method == "PUT"
					           && result.IsModelSet;
				}

				if (result.IsModelSet)
				{
					SetProperty(ctx, modelName, property, result);
					if (modified)
					{
						var member = xpObj.ClassInfo.FindMember(fieldName);
						member?.SetModified(xpObj, result.Model);
					}
				}
			}

			ctx.Result = ModelBindingResult.Success(ctx.Model);
		}

		protected virtual Task BindProperty(ModelBindingContext bindingContext)
		{
			var binder = _propertyBinders[bindingContext.ModelMetadata];
			return binder.BindModelAsync(bindingContext);
		}

		protected virtual void SetProperty(
			ModelBindingContext bindingContext,
			string modelName,
			ModelMetadata propertyMetadata,
			ModelBindingResult result)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			if (modelName == null)
			{
				throw new ArgumentNullException(nameof(modelName));
			}

			if (propertyMetadata == null)
			{
				throw new ArgumentNullException(nameof(propertyMetadata));
			}

			if (!result.IsModelSet)
			{
				// If we don't have a value, don't set it on the model and trounce a pre-initialized value.
				return;
			}

			if (propertyMetadata.IsReadOnly)
			{
				// The property should have already been set when we called BindPropertyAsync, so there's
				// nothing to do here.
				return;
			}

			var value = result.Model;
			try
			{
				propertyMetadata.PropertySetter(bindingContext.Model, value);
			}
			catch (Exception exception)
			{
				AddModelError(exception, modelName, bindingContext);
			}
		}

		private static void AddModelError(
			Exception exception,
			string modelName,
			ModelBindingContext bindingContext)
		{
			var targetInvocationException = exception as TargetInvocationException;
			if (targetInvocationException?.InnerException != null)
			{
				exception = targetInvocationException.InnerException;
			}

			// Do not add an error message if a binding error has already occurred for this property.
			var modelState = bindingContext.ModelState;
			var validationState = modelState.GetFieldValidationState(modelName);
			if (validationState == ModelValidationState.Unvalidated)
			{
				modelState.AddModelError(modelName, exception, bindingContext.ModelMetadata);
			}
		}
	}
}