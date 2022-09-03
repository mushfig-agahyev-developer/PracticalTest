using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public string InvoiceNr { get; set; }
        public int OrderNr { get; set; }

       // [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }

        public int LoanID { get; set; }
        public Loan Loan { get; set; }
    }
}
