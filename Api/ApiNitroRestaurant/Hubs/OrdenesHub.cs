using Microsoft.AspNetCore.SignalR;
using shortid;

namespace ApiNitroRestaurant.Hubs
{
    public class OrdenesHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("--> Conexión establecida " + Context.ConnectionId);

            Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnID");

            return base.OnConnectedAsync();
        }

        public async Task CreateRoom()
        {
            string id = ShortId.Generate();

            await Groups.AddToGroupAsync(Context.ConnectionId, id);
            Console.WriteLine($"El usuario {Context.ConnectionId} ha creado la sala {id}");
            await Clients.Caller.SendAsync("ReceiveGroup", id, Context.ConnectionId);
        }

        public async Task AddToGroup(string id)
        {
            if (Clients.Group(id) != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, id);
                Console.WriteLine($"El usuario {Context.ConnectionId} ha entrado a la sala {id}");
                await Clients.Caller.SendAsync("WithinGroup");
            }
            else
                Console.WriteLine($"El usuario {Context.ConnectionId} ha intentado a entrar a un grupo que no existe");   
        }

        public async Task NotifyOrder(string idUser)
        {
            await Clients.Client(idUser).SendAsync("NewOrder");
        }


    }
}
