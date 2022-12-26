using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Services
{
    public class SalaryService : ISalaryService
    {

        ISalaryRepository _repository;
        public SalaryService(ISalaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(decimal id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<Salary>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Salary> GetById(decimal id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> Insert(Salary salary)
        {
            return await _repository.Insert(salary);
        }

        public async Task<int> Update(Salary salary)
        {
            return await _repository.Update(salary);
        }
        public async Task<List<Salary>> GetByDate(DateIntervalDTO dateIntervalDTO)
        {
            return await _repository.GetByDate(dateIntervalDTO);
        }

        public async Task<List<Salary>> GetByEmployeeId(decimal id)
        {
            return await _repository.GetByEmployeeId(id);
        }

        public async Task<List<Salary>> GetByEmployeeIdAndDate(DateIntervalWithIdDTO dateIntervalWithIdDTO)
        {
            return await _repository.GetByEmployeeIdAndDate(dateIntervalWithIdDTO);
        }

        public SalarySummationDto GetSummation()
        {
            return _repository.GetSummation();
        }
        public List<SalaryWithName> GetSalary()
        {
            return _repository.GetSalary();
        }

    }
}
