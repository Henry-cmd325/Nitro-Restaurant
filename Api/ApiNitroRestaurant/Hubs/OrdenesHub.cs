using Microsoft.AspNetCore.SignalR;
using shortid;

namespace ApiNitroRestaurant.Hubs
{
    public class OrdenesHub : Hub
    {
        private static string Code = string.Empty;
        private static string RoomOwner = string.Empty;

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("--> Conexión establecida " + Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (Context.ConnectionId == RoomOwner)  Clients.Group(Code).SendAsync("Disconnected");
            
            return base.OnDisconnectedAsync(exception);
        }

        public async Task CreateRoom()
        {
            Code = ShortId.Generate();
            RoomOwner = Context.ConnectionId;
            await Groups.AddToGroupAsync(Context.ConnectionId, Code);
            Console.WriteLine($"El usuario {Context.ConnectionId} ha creado la sala {Code}");
        }

        public async Task AddToGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, Code);
            Console.WriteLine($"El usuario {Context.ConnectionId} ha entrado a la sala con llave {Code}");

            await Clients.Caller.SendAsync("WithinGroup");
        }

        public async Task NotifyOrder()
        {
            await Clients.Client(RoomOwner).SendAsync("NewOrder");
        }
    }
}
