
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
    public class MercedesController : ControllerBase
    {
      private readonly  IMercedes _mercedes;
        public MercedesController(IMercedes mercedes )
        {
            _mercedes = mercedes;
        }

        [HttpGet("GetMercedesDetile")]
        public string GetBrand()
        {
            return _mercedes.GetMercedesDetiles();
        }
    }
}
