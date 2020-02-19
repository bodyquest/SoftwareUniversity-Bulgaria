namespace _02.DemoCoreMVCApp.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(int) && context.Metadata.Name == "Year")
            {
                return new DateTimeToYearModelBinder();
            }

            return null; 
        }
    }

    public class DateTimeToYearModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var httpYear = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if(DateTime.TryParse(httpYear.FirstValue, out var dateTime))
            {
                bindingContext.Result = ModelBindingResult.Success(dateTime.Year);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            
            return Task.CompletedTask;
        }
    }
}
