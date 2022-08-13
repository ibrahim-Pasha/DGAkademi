using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Entity.Abstract;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BMWController : ControllerBase
    {
       private readonly IBMW _bmw;
        public BMWController(IBMW bmw)
        {
            _bmw = bmw;
        }

        [HttpGet("GetBmwDetile")]
        public string GetBrand()
        {
            return _bmw.GetBmwDetiles();
        }
    }
}


