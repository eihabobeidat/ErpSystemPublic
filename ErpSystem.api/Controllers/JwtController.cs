using ErpSystem.core.Data;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtService jwtService;

        public JwtController(IJwtService jwtService)
        {
            this.jwtService = jwtService;
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Authentication([FromBody]Employee employee)
        {
            var token = jwtService.Authentication(employee);

            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }


        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CheckEmail")]
        public string CheckEmail(Employee employee)
        {
            return jwtService.CheckEmail(employee);
        }

    }
}
