
using Newtonsoft.Json;
using System.Net;

namespace Sat.Recruitment.Api.Utils
{
    /// <summary>
    /// Api Envelope response.
    /// </summary>
    public class ApiEnvelope<TData>
    {

        /// <summary>
        /// The http status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// A custom message of the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The data associated with the response.
        /// </summary>
        public TData Data { get; set; }

        /// <summary>
        /// Gets a value indicating whether this response indicates a success.
        /// </summary>
        public bool IsSuccessStatusCode => StatusCode >= HttpStatusCode.OK && StatusCode <= HttpStatusCode.IMUsed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiEnvelope{T}"/> class.
        /// </summary>
        public ApiEnvelope()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiEnvelope{T}"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        public ApiEnvelope(HttpStatusCode statusCode, TData data = default, string message = "")
        {
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }
    }
}


