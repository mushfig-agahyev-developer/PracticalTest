using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.DTO
{
    public class LoanDto
    {
        public int ID { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }

        public string ClientID { get; set; }
        public  ClientDto Client { get; set; }
        public List<InvoiceDto> Invoices { get; set; }
    }
}
