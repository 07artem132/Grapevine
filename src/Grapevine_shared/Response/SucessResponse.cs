using System;
using System.Collections.Generic;
using System.Text;

namespace Grapevine_shared.Response
{
    public class SucessResponse
    {
        public string Status { get; set; } = "success";
        public object Data { get; set; }
    }
}
