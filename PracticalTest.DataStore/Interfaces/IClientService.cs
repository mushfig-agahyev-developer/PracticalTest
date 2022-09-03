using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Query;
using PracticalTest.DataStore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Interfaces
{
    public interface IClientService
    {
        Task<BaseResponse<ClientDto>> GetAllClientsAsync(QueryParameters queryParameters);
        ClientDto GetClientByIDAsync(int id);
        void AddAsync(ClientDto item);
        void DeleteAsync(int id);
        ClientDto UpdateAsync(int id, ClientDto item);
        int CountAsync();
        bool SaveAsync();
    }
}
