using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.InvoiceCalculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Repositories
{
    public class LoanService : ILoanService
    {
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
