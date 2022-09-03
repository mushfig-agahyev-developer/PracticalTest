using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Repositories
{
    public class ClientService : IClientService
    {
        public Task<List<ClientDto>> GetAllClients()
        {
            throw new NotImplementedException();
        }
    }
}
