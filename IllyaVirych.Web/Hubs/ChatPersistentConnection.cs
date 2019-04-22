using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using IllyaVirych.Web.Models;
using IllyaVirych.Web.Service;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using AutoMapper;
using System.Collections.Concurrent;

namespace IllyaVirych.Web.Hubs
{
    public class ChatPersistentConnection : PersistentConnection
    {
        private static ConcurrentDictionary<string, ChatRooms> ChatClients = new ConcurrentDictionary<string, ChatRooms>();
        private bool firstStart = true;

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            if(firstStart)
            {
                firstStart = false;
                ChatRooms newChatRooms = new ChatRooms { ChatRoomName = "Agroup", receiverType = ReceiverType.Group };
                ChatClients.TryAdd("Agroup", newChatRooms);
                newChatRooms = new ChatRooms { ChatRoomName = "Bgroup", receiverType = ReceiverType.Group };
                ChatClients.TryAdd("Bgroup", newChatRooms);
                newChatRooms = new ChatRooms { ChatRoomName = "Cgroup", receiverType = ReceiverType.Group };
                ChatClients.TryAdd("Cgroup", newChatRooms);
            }
            ChatData chatdata = JsonConvert.DeserializeObject<ChatData>(data);
            string nameUser = chatdata.SenderId;
            string nameUserWhoReceiveMessage = chatdata.ReceiverId;
            string groupName = chatdata.ReceiverGroup;
            string message = chatdata.Message;
            ReceiverType receiverType = chatdata.ReceiverType;
            MethodType methodType = chatdata.MethodType;
            if (methodType == MethodType.Send)
            {
                if (receiverType == ReceiverType.User)
                {
                    ChatData chatData = new ChatData() { SenderId = nameUser, Message = message, ReceiverType = ReceiverType.User, ReceiverId = nameUserWhoReceiveMessage, MethodType = MethodType.Send };
                    return Connection.Broadcast(chatData);
                }
                if (receiverType == ReceiverType.Group)
                {
                    groupName = nameUserWhoReceiveMessage;
                    ChatData chatData = new ChatData() { SenderId = nameUser, Message = message, ReceiverType = ReceiverType.Group, ReceiverGroup = nameUserWhoReceiveMessage, MethodType =  MethodType.Send };
                    return Groups.Send(groupName, chatData);
                }
            }
            if(methodType == MethodType.AddUser)
            {
                List<ChatRooms> listChatRooms = new List<ChatRooms>(ChatClients.Values);
                for (int i = 0; i < listChatRooms.Count; i++)
                {
                    AddUserToGroup(listChatRooms[i].ChatRoomName, connectionId);
                }
                ChatRooms newChatRooms = new ChatRooms { ChatRoomName = nameUser, receiverType = ReceiverType.User };
                var added = ChatClients.TryAdd(nameUser, newChatRooms);
                if (!added)
                {
                    return null;
                }
                listChatRooms = new List<ChatRooms>(ChatClients.Values);
                ChatData dataSendNameUser = new ChatData() { SenderId = nameUser, ChatRooms = listChatRooms, Message = null, ReceiverGroup = groupName,
                MethodType = MethodType.AddUser};
                return Connection.Broadcast(dataSendNameUser);
            }
            if(methodType == MethodType.RemoveUser)
            {
                ChatRooms chatRooms = new ChatRooms();
                ChatClients.TryRemove(nameUser, out chatRooms);
                List<ChatRooms> listChatRooms = new List<ChatRooms>(ChatClients.Values);
                ChatData dataSendNameUser = new ChatData() { SenderId = nameUser, ChatRooms = listChatRooms, Message = null, ReceiverGroup  = groupName,
                MethodType = MethodType.AddUser };
                return Connection.Broadcast(dataSendNameUser);
            }
            return null;
        }

        protected override IList<string> OnRejoiningGroups(IRequest request, IList<string> groups, string connectionId)
        {
            return groups;
        }

        private void AddUserToGroup(string groupName, string connectionId)
        {
            Groups.Add(connectionId, groupName);
        }
    }

    public enum ReceiverType
    {
        Group = 0,
        User = 1,
        None = 2
    }

    public enum MethodType
    {
        Send = 0, 
        AddUser = 1, 
        RemoveUser = 2
    }

    public class ChatRooms
    {
        public string ChatRoomName;
        public ReceiverType receiverType;
    }
}