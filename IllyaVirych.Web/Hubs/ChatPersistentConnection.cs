using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using IllyaVirych.Web.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace IllyaVirych.Web.Hubs
{
    public class ChatPersistentConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            Data chatdata = new Data() { Name = "Name Message!", Message = "User"+ connectionId + "welcom in server!"};
            return Connection.Broadcast(chatdata);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            Data chatdata = JsonConvert.DeserializeObject<Data>(data);
            return Connection.Broadcast(chatdata);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            Data chatdata = new Data() { Name = "Name Message!", Message = "User" + connectionId + "goodbye!"};
            return Connection.Broadcast(chatdata);
        }
    }
}