using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticalTest.MVC.FilterModels;
using PracticalTest.MVC.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.MVC.Controllers
{
    public class LoanController : Controller
    {
        private readonly HttpClient _client;
        private readonly HttpContext _httpContext;
        public Message _message { get; set; }
        public LoanController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContext)
        {
            _client = httpClientFactory.CreateClient();
            _httpContext = httpContext.HttpContext;
            _message = new Message();
            _message.Notifications = new List<Notification>();
        }

        public async Task<IActionResult> Index(BaseFileter filter)
        {
            try
            {
                var json = JsonConvert.SerializeObject(filter);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44398/api/Login/initialize";

                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage _response = await _client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(filter), Encoding.UTF8, "application/json"));

                if (_response.StatusCode == HttpStatusCode.OK)
                {
                  
                }
                else
                {
                    return View();
                }

                return Content("ok");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
