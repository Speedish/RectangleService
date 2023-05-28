using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RectangleService.Infrastructure.Common
{
    public class ValidationErrorResponse
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        public List<ValidationError> ValidationErrors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationErrorResponse" /> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="errorMessage">The error message.</param>
        public ValidationErrorResponse(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationErrorResponse" /> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="modelState">State of the model.</param>
        public ValidationErrorResponse(HttpStatusCode statusCode, string errorMessage, ModelStateDictionary modelState)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;

            if (modelState != null)
            {
                ValidationErrors = new List<ValidationError>();

                foreach (var state in modelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        ValidationErrors.Add(new ValidationError(state.Key, error.ErrorMessage));
                    }
                }
            }
        }

    }
}
