using Microsoft.EntityFrameworkCore;
using PracticalTest.DataStore.DAL;
using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Extensions;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.Messages;
using PracticalTest.DataStore.Models;
using PracticalTest.DataStore.Query;
using PracticalTest.DataStore.Response;
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

        public async Task<BaseResponse<ClientDto>> GetAllClientsAsync(QueryParameters query)
        {
            BaseResponse<ClientDto> _model = new BaseResponse<ClientDto>();

            try
            {
                _model.Datas = await _db.Clients.AsNoTracking()
                           .Where(r => query.Query == null || (r.Name.Contains(query.Query, StringComparison.OrdinalIgnoreCase) ||
                           r.Surname.Contains(query.Query, StringComparison.OrdinalIgnoreCase))).Include(r => r.Loans)
                           .Skip(query.PageCount * (query.Page - 1)).Take(query.PageCount)
                           .Select(r => (ClientDto)r).ToListAsync();

                return _model;
            }
            catch (Exception ex)
            {
#if DEBUG
                _model.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = ex.ToString()
                });
                return _model;
#else
        _model.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = "Someone get wrong!"
                });
                return _model;
#endif

            }

        }

        public ClientDto GetClientByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(ClientDto item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ClientDto UpdateAsync(int id, ClientDto item)
        {
            throw new NotImplementedException();
        }

        public int CountAsync()
        {
            throw new NotImplementedException();
        }

        public bool SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
