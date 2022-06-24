using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio.Models.Response
{
    internal class ServerResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
    }
}
