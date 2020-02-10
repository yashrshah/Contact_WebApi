using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EHI.Application.Models
{
    public class ValidationError
    {
        /// <summary>
        /// Gets the Field
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        /// <summary>
        /// Gets the Message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError"/> class.
        /// </summary>
        /// <param name="field">The field<see cref="string"/></param>
        /// <param name="message">The message<see cref="string"/></param>
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }

    /// <summary>
    /// Defines the <see cref="ValidationResultModel" />
    /// </summary>
    public class ValidationResultModel
    {
        public string Message { get; }
        public List<ValidationError> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}