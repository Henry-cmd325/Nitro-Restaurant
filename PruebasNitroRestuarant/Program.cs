// See https://aka.ms/new-console-template for more information

using PruebasNitroRestuarant;

Console.WriteLine("hola");

var service = new SignalRService();
var service2 = new SignalRService();

string idPc = null;

service.OnReceiveKey((key) => {
    idPc = key;
});

service2.OnWithinGroup(() =>
{
    Console.WriteLine("Se ha accesado correctamente");
});

service2.OnError(() =>
{
    Console.WriteLine("El codigo introducido es incorrecto o no existe");
});

service.OnNewOrder(() =>
{
    Console.WriteLine("Se ha creado una nueva orden");
});

await service.Connect();
await service.CreateRoom();

await service2.Connect();

if (idPc != null)
{
    await service2.AddToGroup(idPc);
    await service2.NotifyOrder(idPc);
}
else
{
    Console.WriteLine("No se ha llamado al OnReceiveKey");
}

Console.WriteLine("Hola");





