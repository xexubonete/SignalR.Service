using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SignalR.Service.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> connections = new ConcurrentDictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            string clientIp = Context.GetHttpContext()?.Connection.RemoteIpAddress?.ToString();

            if (!string.IsNullOrEmpty(clientIp))
            {
                connections[connectionId] = clientIp;
                await Clients.All.SendAsync("notify", $"Cliente conectado: {connectionId} desde IP {clientIp}");
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string connectionId = Context.ConnectionId;

            if (connections.TryRemove(connectionId, out string clientIp))
            {
                await Clients.All.SendAsync("notify", $"Cliente desconectado: {connectionId} que estaba en la IP {clientIp}");
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
