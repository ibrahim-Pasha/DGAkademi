
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
    public class MercedesController : ControllerBase
    {
        Mercedes mercedes = new Mercedes();

        [HttpGet("GetBmwDetile")]
        public string GetBrand()
        {
            return mercedes.GetMercedesDetiles();
        }
    }
}
