using System;
using PracticalTest.DataStore.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticalTest.DataStore.InvoiceCalculate;
using PracticalTest.DataStore.Models;

namespace PracticalTest.DataStore.Interfaces
{
    public interface IInvoiceService
    {
        public Task<List<Invoice>> GetLoanInvoices(LoanDto loanDto);
        public Task<LoanDto> GenerateInvoiceItems(LoanDto model);
    }
}
