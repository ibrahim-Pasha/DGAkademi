using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AudiController : ControllerBase
    {
        Audi audi = new Audi();

        [HttpGet("GetAudiDetile")]
        public string GetBrand()
        {
            return audi.GetAudiDetiles();
        }
    }
}
