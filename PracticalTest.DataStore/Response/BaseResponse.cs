using PracticalTest.DataStore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Response
{
    public class BaseResponse<T> where T : class
    {
        public BaseResponse()
        {
            Message = new Message();
        }
        public List<T> Datas { get; set; }
        public Message Message { get; set; }
    }
}
