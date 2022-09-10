using System;
using PracticalTest.DataStore.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticalTest.DataStore.InvoiceCalculate;

namespace PracticalTest.DataStore.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDto>> GetLoanInvoices(int loanId);
        Task<LoanDto> GenerateInvoiceItems(LoanDto model);
    }
}
