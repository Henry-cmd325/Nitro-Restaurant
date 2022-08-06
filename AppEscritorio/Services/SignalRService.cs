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
        private HubConnection connection;

        public SignalRService()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://manuwolf-001-site1.atempurl.com/ordenesHub")
                .Build();
        }

        public async Task OnConnect()
        {
            await connection.StartAsync();
            await connection.InvokeAsync("CreateRoom");
        }

        public void OnReceiveGroup(Action<string, string> action)
        {
            connection.On("ReceiveGroup", action);
        }
    }
}
