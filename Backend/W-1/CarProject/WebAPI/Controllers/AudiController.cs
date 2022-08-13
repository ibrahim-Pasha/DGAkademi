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
    public class AudiController : ControllerBase
    {
       private readonly IAudi _audi;
        public AudiController(IAudi audi)
        {
            _audi = audi;
        }

        [HttpGet("GetAudiDetile")]
        public string GetBrand()
        {
            return _audi.GetAudiDetiles();
        }
    }
}
