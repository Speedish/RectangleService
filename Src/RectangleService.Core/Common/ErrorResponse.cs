using System.Net;

namespace RectangleService.Core.Common
{
    /// <summary>
    /// ErrorResponse
    /// </summary>
    public class ErrorResponse
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
        /// Initializes a new instance of the <see cref="ValidationErrorResponse" /> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="errorMessage">The error message.</param>
        public ErrorResponse(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}
