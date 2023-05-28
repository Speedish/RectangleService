using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleSearchAPI.DataAccess.Common
{
    public static class Messages
    {
        public const string ApiAuthenticateMissingAuthHeaderMessage = "Missing Authorization Header.";

        public const string ApiAuthenticateInvalidCredentialsMessage = "Invalid Username or Password provided.";

        public const string ApiAuthenticatedSuccessMessage = "Api authenticated successfully,api user id {0}.";

        public const string ApiAuthenticateInvalidAuthHeaderMessage = "Invalid Authorization Header.";

        public const string InternalServerErrorOccurredMessage = "Error occurred while processing the api request.";

        public const string ValidationErrorOccurred = "One or more validation errors occurred.";

    }
}
