using PracticalTest.DataStore.DAL;
using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Repositories
{
    public class ClientService : IClientService
    {
        private readonly AppStore _db;
        public Message _message { get; set; }
        public ClientService(AppStore dbContext)
        {
            _message = new Message();
            _message.Notifications = new List<Notification>();
            _db = dbContext;
        }

        public Task<List<ClientDto>> GetAllClients()
        {
            throw new NotImplementedException();
        }
    }
}
