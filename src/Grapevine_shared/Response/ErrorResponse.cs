using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Grapevine_shared.Response
{
    public class ErrorResponse
    {
        public string Status { get; set; } = "error";
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
