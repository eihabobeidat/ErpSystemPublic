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
    public class SalaryChangesService : ISalaryChangesService
    {

        ISalaryChangesRepository _repository;
        public SalaryChangesService(ISalaryChangesRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(decimal id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<SalaryChanges>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<SalaryChanges> GetById(decimal id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> Insert(SalaryChanges salaryChanges)
        {
            return await _repository.Insert(salaryChanges);
        }

        public async Task<int> Update(SalaryChanges salaryChanges)
        {
            return await _repository.Update(salaryChanges);
        }
        public async Task<List<SalaryChanges>> GetByDate(DateIntervalDTO dateIntervalDTO)
        {
            return await _repository.GetByDate(dateIntervalDTO);
        }

        public async Task<List<SalaryChanges>> GetByEmployeeId(decimal id)
        {
            return await _repository.GetByEmployeeId(id);
        }

        public async Task<List<SalaryChanges>> GetByEmployeeIdAndDate(DateIntervalWithIdDTO dateIntervalWithIdDTO)
        {
            return await _repository.GetByEmployeeIdAndDate(dateIntervalWithIdDTO);
        }
    }
}
