using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.InvoiceCalculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Interfaces
{
    public interface ILoanService
    {
        Task<List<InvoiceDetails>> GetLoanList();
        Task<InvoiceDetails> GetLoanDetails(int loanId);
        Task<LoanDto> Add(LoanDto loanModel);
    }
}
