using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Utils
{
    /// <summary>
    /// Web API envelope response.
    /// </summary>
    public class WebApiEnvelope<TData> : ApiEnvelope<TData>
    {
        public WebApiEnvelope(HttpStatusCode statusCode, TData data = default, string message = "")
            : base(statusCode, data, message)
        {
        }

        /// <summary>
        /// Gets the action result to send to caller.
        /// </summary>
        [JsonIgnore]
        public IActionResult Result
        {
            get
            {
                return new ObjectResult(this)
                {
                    StatusCode = (int)StatusCode
                };
            }
        }
    }

}
