using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleService.Core.Common
{
    /// <summary>
    /// Messages
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// The API authenticate missing authentication header message
        /// </summary>
        public const string ApiAuthenticateMissingAuthHeaderMessage = "Missing Authorization Header.";

        /// <summary>
        /// The API authenticate invalid credentials message
        /// </summary>
        public const string ApiAuthenticateInvalidCredentialsMessage = "Invalid Username or Password provided.";

        /// <summary>
        /// The API authenticated success message
        /// </summary>
        public const string ApiAuthenticatedSuccessMessage = "Api authenticated successfully,api user id {0}.";

        /// <summary>
        /// The API authenticate invalid authentication header message
        /// </summary>
        public const string ApiAuthenticateInvalidAuthHeaderMessage = "Invalid Authorization Header.";

        /// <summary>
        /// The internal server error occurred message
        /// </summary>
        public const string InternalServerErrorOccurredMessage = "Error occurred while processing the api request.";

        /// <summary>
        /// The validation error occurred
        /// </summary>
        public const string ValidationErrorOccurred = "One or more validation errors occurred.";

        /// <summary>
        /// The user creation failed message
        /// </summary>
        public const string UserCreationFailedMessage = "User creation failed.";

    }
}
