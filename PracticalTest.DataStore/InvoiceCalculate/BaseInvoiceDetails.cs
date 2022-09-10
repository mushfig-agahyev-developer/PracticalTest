using PracticalTest.DataStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.InvoiceCalculate
{
    public class BaseInvoiceDetails
    {
        public List<InvoiceDto> InvoiceItem { get; set; }
        public decimal Total { get; set; }
    }
}
