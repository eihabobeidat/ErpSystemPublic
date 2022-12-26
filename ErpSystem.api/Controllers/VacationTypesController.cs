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
    public class VacationTypesController : ControllerBase
    {
        private readonly IVacationTypesService service;
        public VacationTypesController(IVacationTypesService service)
        {
            this.service = service;
        }

        [ProducesResponseType(typeof(Task<List<VacationTypes>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public Task<List<VacationTypes>> GetAll()
        {
            return service.GetAll();
        }

        [ProducesResponseType(typeof(Task<VacationTypes>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:decimal}")]
        public Task<VacationTypes> GetById(decimal id)
        {
            return service.GetById(id);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public Task<int> Insert([FromBody] VacationTypes vacation)
        {
            return service.Insert(vacation);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public Task<int> Update([FromBody] VacationTypes vacation)
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
