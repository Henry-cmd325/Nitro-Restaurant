using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.Services
{
    public interface ISignalRService
    {
        Task Connect(string id);
        Task NotifyOrder(string idUser);
    }
}
