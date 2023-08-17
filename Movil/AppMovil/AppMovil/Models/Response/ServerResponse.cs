using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovil.Models.Response
{
    internal class ServerResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; }
    }
}
