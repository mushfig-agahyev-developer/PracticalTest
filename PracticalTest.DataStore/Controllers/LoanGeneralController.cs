using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.DataStore.DTO;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.Messages;
using PracticalTest.DataStore.Models;
using PracticalTest.DataStore.Query;
using PracticalTest.DataStore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanGeneralController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public Message _message { get; set; }
        public LoanGeneralController(ILoanService loanService)
        {
            _message = new Message();
            _message.Notifications = new List<Notification>();
            _loanService = loanService;
        }


        [HttpPost]
        [Route("saveloan")]
        public async Task<ActionResult> SaveLoan([FromBody] LoanDto loanDto)
        {
            SaveResponse _response = new SaveResponse();
            try
            {
                if (loanDto == null)
                    return StatusCode(400);

                _response = await _loanService.SaveAsync(loanDto);

                if(_response.Message.Notifications != null && _response.Message.Notifications.Count() > 0)
                return StatusCode(200, _response);
                else
                    return StatusCode(400, _response);
            }
            catch (Exception ex)
            {
#if DEBUG
                _response.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = ex.ToString()
                });
                return StatusCode(500, _response);
#else
                _response.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = "Someone get wrong!"
                });
                return StatusCode(500, _response);
#endif
            }


        }

        [HttpPost]
        [Route("allloans")]
        public async Task<ActionResult> AllLoans([FromBody] QueryParameters query)
        {
            BaseResponse<LoanDto> _response = new BaseResponse<LoanDto>();
            try
            {
                _response = await _loanService.GetLoanListAsync(query);

                if (_response.Message.Notifications != null && _response.Message.Notifications.Count() > 0)
                    return StatusCode(200, _response);
                else
                    return StatusCode(400, _response);
            }
            catch (Exception ex)
            {
#if DEBUG
                _response.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = ex.ToString()
                });
                return StatusCode(500, _response);
#else
                _response.Message.Notifications.Add(new Notification
                {
                    Type = (byte)NotificationType.Error,
                    Content = "Someone get wrong!"
                });
                return StatusCode(500, _response);
#endif
            }


        }

    }
}
