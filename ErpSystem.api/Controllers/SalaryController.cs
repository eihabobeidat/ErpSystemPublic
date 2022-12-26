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
    public class SalaryController : ControllerBase
    {
        ISalaryService _service;
        public SalaryController(ISalaryService service)
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
        public async Task<List<Salary>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert([FromBody] Salary salary)
        {
            return await _service.Insert(salary);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<int> Update([FromBody] Salary salary)
        {
            return await _service.Update(salary);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Salary> GetById(decimal id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        [Route("GetByDate")]
        public async Task<List<Salary>> GetByDate([FromBody] DateIntervalDTO dateIntervalDTO)
        {
            return await _service.GetByDate(dateIntervalDTO);
        }
        [HttpGet]
        [Route("GetByEmployeeId/{id}")]
        public async Task<List<Salary>> GetByEmployeeId(decimal id)
        {
            return await _service.GetByEmployeeId(id);
        }

        [HttpPost]
        [Route("GetByEmployeeIdAndDate")]
        public async Task<List<Salary>> GetByEmployeeIdAndDate([FromBody] DateIntervalWithIdDTO dateIntervalWithIdDTO)
        {
            return await _service.GetByEmployeeIdAndDate(dateIntervalWithIdDTO);
        }

        [HttpGet]
        [Route("GetSalarySummation")]
        public SalarySummationDto GetSummation()
        {
            return _service.GetSummation();
        }
        [HttpGet]
        [Route("getallsalarywithname")]
        public List<SalaryWithName> GetSalary()
        {
            return _service.GetSalary();
        }
    }
}
