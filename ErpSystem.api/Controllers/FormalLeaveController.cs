using ErpSystem.core.Data;
using ErpSystem.core.DTO;
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
    public class FormalLeaveController : ControllerBase
    {
        private readonly IFormalLeaveService service;
        public FormalLeaveController(IFormalLeaveService service)
        {
            this.service = service;
        }

        [ProducesResponseType(typeof(Task<List<FormalLeave>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public Task<List<FormalLeave>> GetAll()
        {
            return service.GetAll();
        }

        [ProducesResponseType(typeof(Task<FormalLeave>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:decimal}")]
        public Task<FormalLeave> GetById(decimal id)
        {
            return service.GetById(id);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public Task<int> Insert([FromBody] FormalLeave vacationType)
        {
            return service.Insert(vacationType);
        }

        [ProducesResponseType(typeof(List<Task<FormalLeave>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("ByName")]
        public Task<List<FormalLeave>> GetById([FromBody] FormalLeave vacationType)
        {
            return service.GetByName(vacationType.Name);

        }

        [ProducesResponseType(typeof(Task<List<FormalLeave>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("ByDate")]
        public Task<List<FormalLeave>> GetByDate([FromBody] IntervalDTO interval)
        {
            return service.GetByDate(interval.startDate, interval.endDate);
        }

        [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public Task<int> Update([FromBody] FormalLeave vacationType)
        {
            return service.Update(vacationType);
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
