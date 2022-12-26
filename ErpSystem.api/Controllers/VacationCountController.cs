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
    public class VacationCountController : ControllerBase
    {
        private readonly IVacationCountService service;
        public VacationCountController(IVacationCountService service)
        {
            this.service = service;
        }
        [ProducesResponseType(typeof(Task<List<VacationCount>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public Task<List<VacationCount>> GetAll()
        {
            return service.GetAll();
        }

        [ProducesResponseType(typeof(Task<VacationCount>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:decimal}")]
        public Task<VacationCount> GetById(decimal id)
        {
            return service.GetById(id);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public Task<int> Insert([FromBody] VacationCount vacation)
        {
            return service.Insert(vacation);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public Task<int> Update([FromBody] VacationCount vacation)
        {
            return service.Update(vacation);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:decimal}")]
        public Task<int> Delete(decimal id)
        {
            return service.Delete(id);
        }
    }
}
