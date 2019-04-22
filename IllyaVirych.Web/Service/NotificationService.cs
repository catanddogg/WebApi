//using IllyaVirych.Web.Hubs;
//using Microsoft.AspNet.SignalR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace IllyaVirych.Web.Service
//{
//    public class NotificationService
//    {
//        private readonly static Lazy<NotificationService> instance =
//            new Lazy<NotificationService>(() => new NotificationService(
//                GlobalHost.ConnectionManager.GetConnectionContext<ChatPersistentConnection>().Connection));

//        private IConnection Connection { get; set; }

//        public static NotificationService Instance { get { return instance.Value; } }

//        public NotificationService(IConnection connection)
//        {
//            this.Connection = connection;
//        }

//        public void Notify(string message)
//        {
//            Connection.Broadcast(message);
//        }

//        //public void NotificationGroup()
//        //{
//        //    var context = GlobalHost.ConnectionManager.GetConnectionContext<ChatPersistentConnection>();
//        //    context.Groups.Send(group, message);
//        //}
//    }
//}