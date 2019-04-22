using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IllyaVirych.Web.Models
{
    public class Users
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        private bool _isLoggedIn = true;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; }
        }

        private bool _hasSentNewMessage;
        public bool HasSentNewMessage
        {
            get { return _hasSentNewMessage; }
            set { _hasSentNewMessage = value; }
        }

        private bool _isTyping;
        public bool IsTyping
        {
            get { return _isTyping; }
            set { _isTyping = value; }
        }

    }
}