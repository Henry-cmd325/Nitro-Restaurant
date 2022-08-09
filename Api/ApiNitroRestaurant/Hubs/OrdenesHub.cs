using Microsoft.AspNetCore.SignalR;
using shortid;

namespace ApiNitroRestaurant.Hubs
{
    public class OrdenesHub : Hub
    {
        private static Dictionary<string, string> GroupByIdPc = new();
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("--> Conexión establecida " + Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (GroupByIdPc.TryGetValue(Context.ConnectionId, out var value))
            {
                GroupByIdPc.Remove(Context.ConnectionId);
                Console.WriteLine($"--> EL grupo con llave {value} ha sido eliminado");
            }
            else
            {
                Console.WriteLine($"El usuario {Context.ConnectionId} no era dueño de ningun grupo");
            }
                
            return base.OnDisconnectedAsync(exception);
        }

        public async Task CreateRoom()
        {
            string id = ShortId.Generate();

            await Groups.AddToGroupAsync(Context.ConnectionId, id);
            Console.WriteLine($"El usuario {Context.ConnectionId} ha creado la sala {id}");
            GroupByIdPc.Add(Context.ConnectionId, id);
            await Clients.Caller.SendAsync("ReceiveKey", Context.ConnectionId);

            
        }

        public async Task AddToGroup(string idPc)
        {
            if (GroupByIdPc.TryGetValue(idPc, out var value))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, value);
                Console.WriteLine($"El usuario {Context.ConnectionId} ha entrado a la sala con llave {value}");
                await Clients.Caller.SendAsync("WithinGroup");
            }
            else
            {
                Console.WriteLine($"El usuario {Context.ConnectionId} ha usado una llave que no existe ({idPc})");
                await Clients.Caller.SendAsync("ErrorGroup");
            }
        }

        public async Task NotifyOrder(string idUser)
        {
            await Clients.Client(idUser).SendAsync("NewOrder");
        }
    }
}
