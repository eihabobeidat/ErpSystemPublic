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
    public class SalaryChangesController : ControllerBase
    {
        ISalaryChangesService _service;
        public SalaryChangesController(ISalaryChangesService service)
        {
            _service = service;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<int> Delete(decimal id)
        {
            return await _service.Delete(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<SalaryChanges>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert([FromBody] SalaryChanges salaryChanges)
        {
            return await _service.Insert(salaryChanges);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<int> Update([FromBody] SalaryChanges salaryChanges)
        {
            return await _service.Update(salaryChanges);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<SalaryChanges> GetById(decimal id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        [Route("GetByDate")]
        public async Task<List<SalaryChanges>> GetByDate([FromBody] DateIntervalDTO dateIntervalDTO)
        {
            return await _service.GetByDate(dateIntervalDTO);
        }
        [HttpGet]
        [Route("GetByEmployeeId/{id}")]
        public async Task<List<SalaryChanges>> GetByEmployeeId(decimal id)
        {
            return await _service.GetByEmployeeId(id);
        }

        [HttpPost]
        [Route("GetByEmployeeIdAndDate")]
        public async Task<List<SalaryChanges>> GetByEmployeeIdAndDate([FromBody] DateIntervalWithIdDTO dateIntervalWithIdDTO)
        {
            return await _service.GetByEmployeeIdAndDate(dateIntervalWithIdDTO);
        }
    }
}
