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
    public class PageController : ControllerBase
    {
        private readonly IPagesService pagesService;

        public PageController(IPagesService pagesService)
        {
            this.pagesService = pagesService;
        }


        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public string Insert([FromBody] Pages pages)
        {
            return pagesService.Insert(pages);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return pagesService.Delete(id);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public List<Pages> Getall()
        {
            return pagesService.Getall();
        }
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public bool Update([FromBody] Pages pages)
        {
            return pagesService.Update(pages);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetById/{id}")]
        public Pages GetById(int id)
        {
            return pagesService.GetById(id);
        }

    }
}
