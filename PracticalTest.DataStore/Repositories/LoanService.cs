using PracticalTest.DataStore.DAL;
using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.InvoiceCalculate;
using PracticalTest.DataStore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Repositories
{
    public class LoanService : ILoanService
    {
        private readonly AppStore _db;
        public Message _message { get; set; }
        public LoanService(AppStore dbContext)
        {
            _message = new Message();
            _message.Notifications = new List<Notification>();
            _db = dbContext;
        }
        public Task<LoanDto> Add(LoanDto loanModel)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDetails> GetLoanDetails(int loanId)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceDetails>> GetLoanList()
        {
            throw new NotImplementedException();
        }
    }
}
