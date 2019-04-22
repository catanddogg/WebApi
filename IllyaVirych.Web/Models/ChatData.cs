using IllyaVirych.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace IllyaVirych.Web.Models
{
    public class ChatData
    {
        public ReceiverType ReceiverType { get; set; }
        public string ReceiverGroup { get; set; }
        public string Message { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }
        public MethodType MethodType { get; set; }
        //public List<string> NameGroups { get; set; }
        //
        //public List<ReceiverType> ListReceiverTypes { get; set; }
        //public List<string> ChatListUsersAndGroups { get; set; }
        public List<ChatRooms> ChatRooms { get; set; }
    }
}