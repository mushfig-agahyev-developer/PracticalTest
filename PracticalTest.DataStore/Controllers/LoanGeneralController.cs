using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanGeneralController : ControllerBase
    {


        public LoanGeneralController()
        {

        }


        [HttpPost]
        [Route("uplcordinates")]
        public async Task<ActionResult> ApplyLoan([FromBody] LoanDto model)
        {
            if (ModelState.IsValid)
            {
                var loanModel = new Loan()
                {
                    Amount = model.Amount,
                    InterestRate = model.InterestRate,
                    LoanPeriod = model.LoanPeriod,
                    PayoutDate = model.PayoutDate,
                    ClientID = model.ClientID,
                    Invoices = _invoiceRepository.CalculateInvoices(model).Result.InvoicesList
                };

                var resultModel = await _loanRepository.Add(loanModel);

                return RedirectToAction("Details", new { loanId = resultModel.Id });

            }
        }
    }
}
