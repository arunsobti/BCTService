using BCT.SwaggerAPI.Model;
using BCT.SwaggerAPI.Model.DB;
using BCT.SwaggerAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCT.SwaggerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly db_core_sp_callContext _context;
        public CustomerDetailsController(db_core_sp_callContext context)
        {
            _context = context;

        }


        [HttpGet("GetProductByPriceGreaterThan1000Async")]
        public async Task<ActionResult<SpGetProductByPriceGreaterThan1000>> GetAllMember()
        {
            var result = await _context.GetProductByPriceGreaterThan1000Async();
            return Ok(result);
        }

    }
}
