using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Models
{
    public class Loan
    {
        public int ID { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }

        public string ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
