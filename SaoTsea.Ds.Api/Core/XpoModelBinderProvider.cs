using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SaoTsea.Ds.Api.Core
{
	public class XpoModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder GetBinder(ModelBinderProviderContext ctx)
		{
			if (ctx == null)
			{
				throw new ArgumentNullException(nameof(ctx));
			}

			if (ctx == null)
			{
				throw new ArgumentNullException(nameof(ctx));
			}

			if (typeof(XPLiteObject).IsAssignableFrom(ctx.Metadata.ModelType) ||
			    typeof(XPLiteObject[]).IsAssignableFrom(ctx.Metadata.ModelType) ||
			    typeof(INeedXpoBinding).IsAssignableFrom(ctx.Metadata.ModelType))
			{
				if (ctx.BindingInfo.BindingSource == null)
				{
					return null;
				} 

				if (ctx.BindingInfo.BindingSource.CanAcceptDataFrom(BindingSource.Form))
				{
					var propertyBinders = new Dictionary<ModelMetadata, IModelBinder>();
					for (var i = 0; i < ctx.Metadata.Properties.Count; i++)
					{
						var property = ctx.Metadata.Properties[i];
						propertyBinders.Add(property, ctx.CreateBinder(property));
					}

					return new XpoFormCollectionModelBinder(propertyBinders);
				}

				if (ctx.BindingInfo.BindingSource.CanAcceptDataFrom(BindingSource.Body))
				{
					return new XpoModelBinder();
				}
			}

			return null;
		}
	}
}