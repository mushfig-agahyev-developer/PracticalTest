using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.DTO
{
    public class LoanDto
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
        //public decimal MonthlyPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }

        public static implicit operator LoanDto(Loan loan)
        {
            if (loan == null)
                return null;

            return new LoanDto()
            {
                ID = loan.ID,
                Amount = loan.Amount,
                InterestRate = loan.InterestRate,
                LoanPeriod = loan.LoanPeriod,
                ClientID = loan.ClientID,
                PayoutDate = loan.PayoutDate,
                Invoices = loan.Invoices.Select(r => (InvoiceDto)r).ToList()
            };
        }
    }
}
