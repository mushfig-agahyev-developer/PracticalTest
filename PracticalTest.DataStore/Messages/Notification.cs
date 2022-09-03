
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Messages
{
    public class Notification
    {
        public byte Type { get; set; }
        public string Content { get; set; }
    }
}
