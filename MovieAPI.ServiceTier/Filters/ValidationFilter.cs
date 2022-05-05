using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieAPI.ServiceTier.Filters.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.ServiceTier.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(a => a.Value.Errors.Any())
                    .ToDictionary(b => b.Key, c => c.Value.Errors.Select(e => e.ErrorMessage))
                    .ToArray();
                ErrorResponse errorResponse = new();
                foreach (var error in errors)
                {
                    foreach (var item in error.Value)
                    {
                        var errorModel = new ErrorModel { FieldName = error.Key, Message = item };
                        errorResponse.ErrorModels.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse.ErrorModels);
                return;
            }
            await next();
        }
    }
}
