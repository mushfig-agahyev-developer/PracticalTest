using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.InvoiceCalculate
{
    public class InvoiceDetails
    {
        public string ClientId { get; set; }
        public string TelephoneNr { get; set; }

        [Required(ErrorMessage = "Amount cannot be empty")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "LoanPeriod cannot be empty")]
        public int LoanPeriod { get; set; }

        [Required(ErrorMessage = "Interest Rate cannot be empty")]
        public decimal InterestRate { get; set; }

        [Required(ErrorMessage = "Payout Date cannot be empty")]
        public DateTime PayoutDate { get; set; }
        public List<InvoiceDetails> InvoicesList { get; set; }

        public decimal Total { get; set; }
    }
}
