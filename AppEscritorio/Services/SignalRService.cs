using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorio.Services
{
    public class SignalRService : ISignalRService
    {
        private readonly HubConnection connection;

        public SignalRService()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7214/ordenesHub")
                .Build();
        }

        public async Task Connect()
        {
            await connection.StartAsync();
            await connection.InvokeAsync("CreateRoom");
        }

        public void OnNewOrder(Action action)
        {
            connection.On("NewOrder", action);
        }

    }
}
