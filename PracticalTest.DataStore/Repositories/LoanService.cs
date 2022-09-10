using Microsoft.EntityFrameworkCore;
using PracticalTest.DataStore.DAL;
using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.InvoiceCalculate;
using PracticalTest.DataStore.Messages;
using PracticalTest.DataStore.Models;
using PracticalTest.DataStore.Query;
using PracticalTest.DataStore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Repositories
{
    public class LoanService : ILoanService
    {
        private readonly AppStore _db;
        public Message _message { get; set; }
        public LoanService(AppStore dbContext)
        {
            _message = new Message();
            _message.Notifications = new List<Notification>();
            _db = dbContext;
        }

        public async Task<BaseResponse<LoanDto>> GetLoanListAsync(QueryParameters query)
        {
            BaseResponse<LoanDto> _model = new BaseResponse<LoanDto>();

            try
            {
                DateTime date = query.Query != null ? DateTime.Parse(query.Query) : default;

                _model.Datas = await _db.Loans.AsNoTracking().Where(r => date == default || r.PayoutDate >= date)
                    .Include(r => r.Client).Include(y => y.Invoices)
                    .Skip(query.PageCount * (query.Page - 1)).Take(query.PageCount)
                        .Select(r => (LoanDto)r).ToListAsync();

                return _model;
            }
            catch (Exception ex)
            {
#if DEBUG
                _model.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = ex.ToString()
                });
                return _model;
#else
        _model.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = "Someone get wrong!"
                });
                return _model;
#endif

            }

        }

        public Task<InvoiceDatas> GetLoanDetails(int loanId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<LoanDto>> AddAsync(LoanDto _dto)
        {
            BaseResponse<LoanDto> _model = new BaseResponse<LoanDto>();
            try
            {
                Loan loan = new Loan()
                {
                    Amount = _dto.Amount,
                    InterestRate = _dto.InterestRate,
                    LoanPeriod = _dto.LoanPeriod,
                    PayoutDate = _dto.PayoutDate,
                    ClientID = _dto.ClientID
                };

                var _invoices = _dto.Invoices
                    .Select(r =>
                    new Loan
                    {
                        Amount = r.Amount,
                        InterestRate = r.InterestRate,
                        ClientID = r.ClientID,
                        LoanPeriod = r.LoanPeriod,
                        PayoutDate = r.PayoutDate
                    }).ToList();

                for (int i = 0; i < _invoices.Count; i++)
                    await _db.Loans.AddAsync(_invoices[i]);

                await _db.Loans.AddAsync(loan);

                if (await _db.SaveChangesAsync() > 0)
                {
                    _model.Message.Notifications.Add(new Notification
                    {
                        Type = (byte)NotificationType.Sussess,
                        Content = ""
                    });
                    return _model;
                }
                else
                {
                    _model.Message.Notifications.Add(new Notification
                    {
                        Type = (byte)NotificationType.Error,
                        Content = "When data recording same get wrong!"
                    });
                    return _model;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                _model.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = ex.ToString()
                });
                return _model;
#else
        _model.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = "Someone get wrong!"
                });
                return _model;
#endif

            }

        }
    }
}
