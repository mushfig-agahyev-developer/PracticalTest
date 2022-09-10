using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.DataStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceGeneralController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceGeneralController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        [Route("uplcordinates")]
        public async Task<ActionResult> InvoiceCalculate()
        {

            if (true)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }

        }
    }
}
