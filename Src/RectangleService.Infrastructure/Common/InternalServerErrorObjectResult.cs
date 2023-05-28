using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RectangleService.Infrastructure.Common
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        private string _message = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorObjectResult"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public InternalServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorObjectResult"/> class.
        /// </summary>
        public InternalServerErrorObjectResult(string message = null) : base(message)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Formatting = Formatting.Indented;

            Value = JsonConvert.SerializeObject(new ErrorResponse(
                HttpStatusCode.InternalServerError,
                message ?? Messages.InternalServerErrorOccurredMessage),
                settings);
        }
    }
}
