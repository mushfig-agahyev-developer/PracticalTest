using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.DTO
{
    public class InvoiceDto
    {
        public int ID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }

        public string ClientID { get; set; }
        public ClientDto Client { get; set; }
        public List<InvoiceDto> Invoices { get; set; }

        public static implicit operator InvoiceDto(Invoice _invoice)
        {
            if (_invoice == null)
                return null;

            return new Invoice()
            {
                ID = _invoice.ID,
                Amount = _invoice.Amount,
                DueDate = _invoice.DueDate,
                InvoiceNr = _invoice.InvoiceNr,
                OrderNr = _invoice.OrderNr,
                LoanID = _invoice.LoanID
            };
        }
    }
}
