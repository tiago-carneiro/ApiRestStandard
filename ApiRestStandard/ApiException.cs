using System;
using System.Net;

namespace ApiRestStandard
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }
    }
}
