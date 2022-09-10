using PracticalTest.DataStore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Response
{
    public class SaveResponse
    {
        public SaveResponse()
        {
            Message = new Message();
        }
        public bool Save { get; set; }
        public Message Message { get; set; }
    }
}
