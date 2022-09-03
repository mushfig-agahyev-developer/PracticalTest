using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Messages
{
    public class Message
    {
        public Message()
        {
            Notifications = new List<Notification>();
        }
        public List<Notification> Notifications { get; set; }
    }
}
