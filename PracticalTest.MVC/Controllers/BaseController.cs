using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalTest.MVC.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PracticalTest.MVC.Controllers
{
    public class BaseController : Controller
    {
        protected HttpClient _client;
        protected HttpContext _httpContext;
        public Message _message { get; set; }
        public BaseController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContext)
        {
            _client = httpClientFactory.CreateClient();
            _httpContext = httpContext.HttpContext;
            _message = new Message();
            _message.Notifications = new List<Notification>();
        }
    }
}
