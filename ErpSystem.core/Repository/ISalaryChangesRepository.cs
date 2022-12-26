using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.core.Repository
{
    public interface ISalaryChangesRepository
    {
        public Task<int> Insert(SalaryChanges salaryChanges);
        public Task<int> Update(SalaryChanges salaryChanges);
        public Task<int> Delete(decimal id);
        public Task<List<SalaryChanges>> GetAll();
        public Task<SalaryChanges> GetById(decimal id);
        public Task<List<SalaryChanges>> GetByDate(DateIntervalDTO dateIntervalDTO);
        public Task<List<SalaryChanges>> GetByEmployeeId(decimal id);
        public Task<List<SalaryChanges>> GetByEmployeeIdAndDate(DateIntervalWithIdDTO dateIntervalWithIdDTO);
    }
}
