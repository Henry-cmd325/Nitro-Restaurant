using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasNitroRestuarant
{
    public class SignalRService
    {
        private HubConnection connection;

        public SignalRService()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7214/ordenesHub")
                .Build();
        }

        public async Task CreateRoom()
        {
            await connection.InvokeAsync("CreateRoom");
        }
        public async Task Connect()
        {
            await connection.StartAsync();
        }

        public async Task AddToGroup(string idPc)
        {
            await connection.InvokeAsync("AddToGroup", idPc);
        }

        public async Task NotifyOrder(string idUser)
        {
            await connection.InvokeAsync("NotifyOrder", idUser);
        }

        public void OnWithinGroup(Action action)
        {
            connection.On("WithinGroup", action);
        }

        public async Task Disconnect()
        {
            await connection.StopAsync();
        }

        public void OnReceiveKey(Action<string> action)
        {
            connection.On("ReceiveKey", action);
        }
        
        public void OnNewOrder(Action action)
        {
            connection.On("NewOrder", action);
        }
        public void OnError(Action action) => connection.On("ErrorGroup", action);
    }
}

