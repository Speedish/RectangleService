using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleService.Core.Common
{
    /// <summary>
    /// ValidationError
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public object Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError" /> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="message">The message.</param>
        public ValidationError(string field, object message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }

    }
}
