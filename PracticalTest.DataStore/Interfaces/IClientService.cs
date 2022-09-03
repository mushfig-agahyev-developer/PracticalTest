using PracticalTest.DataStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllClients();
    }
}
