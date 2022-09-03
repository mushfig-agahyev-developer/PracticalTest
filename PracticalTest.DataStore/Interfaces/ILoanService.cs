using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.InvoiceCalculate;
using PracticalTest.DataStore.Query;
using PracticalTest.DataStore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Interfaces
{
    public interface ILoanService
    {
        Task<BaseResponse<LoanDto>> GetLoanListAsync(QueryParameters query);
        Task<InvoiceDetails> GetLoanDetails(int loanId);
        Task<LoanDto> AddAsync(LoanDto loanModel);
    }
}
