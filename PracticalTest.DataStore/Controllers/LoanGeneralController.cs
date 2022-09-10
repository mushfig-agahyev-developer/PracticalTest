using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        public LoanGeneralController()
        {

        }


        [HttpPost]
        [Route("uplcordinates")]
        public async Task<ActionResult> UplCordinates()
        {


            if (true)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }

        }
    }
}
