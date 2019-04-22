using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IllyaVirych.Web.Core.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace IllyaVirych.Web.Core.ChatsSignalR
{
    public class ChatPersistentConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            DataChatPersistentsConnections chatdata = new DataChatPersistentsConnections() { Name = "Name Message!", Message = "User" + connectionId + "welcom in server!" };
            return Connection.Broadcast(chatdata);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            DataChatPersistentsConnections chatdata = JsonConvert.DeserializeObject<DataChatPersistentsConnections>(data);
            return Connection.Broadcast(chatdata);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            DataChatPersistentsConnections chatdata = new DataChatPersistentsConnections() { Name = "Name Message!", Message = "User" + connectionId + "goodbye!" };
            return Connection.Broadcast(chatdata);
        }
    }
}
