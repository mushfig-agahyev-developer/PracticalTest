using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.InvoiceCalculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Repositories
{
    public class InvoiceService : IInvoiceService
    {
        public Task<BaseInvoiceDetails> DetailsInvoices(InvoiceDetails model)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceDto>> GetLoanInvoices(int loanId)
        {
            throw new NotImplementedException();
        }
    }
}
