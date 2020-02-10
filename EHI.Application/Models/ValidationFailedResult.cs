using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EHI.Application.Models
{
    public class ValidationFailedResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFailedResult"/> class.
        /// </summary>
        /// <param name="modelState">The modelState<see cref="ModelStateDictionary"/></param>
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
