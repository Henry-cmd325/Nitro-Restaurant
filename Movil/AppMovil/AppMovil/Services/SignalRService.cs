using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.Services
{
    public class SignalRService : ISignalRService
    {
        private HubConnection connection;

        public SignalRService()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://nitrorestaurant-001-site1.ctempurl.com/ordenesHub")
                .Build();
        }

        public async Task Connect(string id)
        {
            await connection.StartAsync();
            await connection.InvokeAsync("AddToGroup", id);
        }

        public async Task NotifyOrder(string idUser)
        {
            await connection.InvokeAsync("NotifyOrder", idUser);
        }

        public void OnWithinGroup(Action action)
        {
            connection.On("WithinGroup", action);
        }

        public void OnError(Action action)
        {
            connection.On("ErrorGroup", action);
        }
    }
}
