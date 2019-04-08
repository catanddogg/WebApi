using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using IllyaVirych.Web.Models;
using Microsoft.AspNet.SignalR;
using static System.Net.Mime.MediaTypeNames;

namespace IllyaVirych.Web.Hubs
{
    public class TaskHub : Hub
    {
        static List<TaskItem> Tasks = new List<TaskItem>();

        public void SendMessage(string name, string group,string message)
        {
            //Clients.All.addMessage(name, message);
            Clients.All.GetMessage(name, message);
        }

  
        public Task JoinGroup(string group)
        {
            return Groups.Add(Context.ConnectionId, group);
        }

        public void Connect(string userTask)
        {
            var id = Context.ConnectionId;

            if (!Tasks.Any(x => x.UserId == id))
            {
                Tasks.Add(new TaskItem { UserId = id, NameTask = userTask });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userTask, Tasks);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userTask);
            }
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
       {
            var item = Tasks.FirstOrDefault(x => x.UserId == Context.ConnectionId);
            if (item != null)
            {
                Tasks.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.NameTask);
            }

            return base.OnDisconnected(stopCalled);
        }
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
    
}