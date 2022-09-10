using Microsoft.EntityFrameworkCore;
using PracticalTest.DataStore.DAL;
using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.InvoiceCalculate;
using PracticalTest.DataStore.Messages;
using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Repositories
{
    public class InvoiceService : IInvoiceService
    {
        private readonly AppStore _db;
        public Message _message { get; set; }
        public InvoiceService(AppStore dbContext)
        {
            _message = new Message();
            _message.Notifications = new List<Notification>();
            _db = dbContext;
        }

        public async Task<List<Invoice>> GetLoanInvoices(LoanDto loanDto)
        {
            if (loanDto == null)
                return null;

            List<Invoice> invoices = new List<Invoice>();
            for (var _month = 1; _month <= loanDto.LoanPeriod; _month++)
            {
                Invoice invoice = new Invoice();
                int _number = await _db.Invoices.CountAsync();

                invoice.OrderNr = _month;
                invoice.InvoiceNr = _number / 10000 > 0 ? _number.ToString().PadLeft(4, '0') : (_number + _month).ToString();
                invoice.DueDate = loanDto.PayoutDate.AddMonths(_month).Date;
                invoice.Amount = CalcPayment(loanDto.Amount, loanDto.InterestRate, loanDto.LoanPeriod);

                invoices.Add(invoice);
            };
            return invoices;
        }

        public async Task<LoanDto> GenerateInvoiceItems(LoanDto loanDto)
        {
            var _monthlyPayment = CalcPayment(loanDto.Amount, loanDto.InterestRate, loanDto.LoanPeriod);

            var balance = loanDto.Amount;
            var totalInterest = 0.0m;
            var monthlyInterest = 0.0m;
            var monthlyPrincipal = 0.0m;
            var monthlyRate = CalcMonthyRate(loanDto.InterestRate);


            loanDto.Invoices = new List<InvoiceDto>();
            int _number = await _db.Invoices.CountAsync();
            for (var _month = 1; _month <= loanDto.LoanPeriod; _month++)
            {
                monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = _monthlyPayment - monthlyInterest;
                balance -= monthlyPrincipal;

                InvoiceDto invoiceDto = new InvoiceDto();
                invoiceDto.InvoiceItem = new InvoiceItem();
                invoiceDto.InvoiceItem.Month = _month;
                invoiceDto.InvoiceItem.Principal = monthlyPrincipal;
                invoiceDto.InvoiceItem.Interest = monthlyInterest;
                invoiceDto.InvoiceItem.TotalInterest = totalInterest;
                invoiceDto.InvoiceItem.Balance = balance;

                invoiceDto.OrderNr = _month;
                invoiceDto.Amount = _monthlyPayment;
                invoiceDto.InvoiceNr = _number / 10000 > 0 ? _number.ToString().PadLeft(4, '0') : (_number + _month).ToString();
                invoiceDto.PayoutDate = loanDto.PayoutDate.AddMonths(_month).Date;

                loanDto.Invoices.Add(invoiceDto);
            }
            loanDto.TotalInterest = totalInterest;
            loanDto.TotalCost = loanDto.Amount + totalInterest;
            return loanDto;
        }

        private decimal CalcPayment(decimal amount, decimal insertRate, int TermInMonths)
        {

            decimal MonthlyRate = CalcMonthyRate(insertRate);
            var amountD = Convert.ToDouble(amount);
            var rateD = Convert.ToDouble(MonthlyRate);

            var payment = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -TermInMonths));

            return Convert.ToDecimal(payment);
        }

        private decimal CalcMonthyRate(decimal InterestRate)=> InterestRate / 1200;

        private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate) => balance * monthlyRate;
    }
}
