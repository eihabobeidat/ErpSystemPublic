using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.core.Services
{
    public interface ISalaryService
    {
        public Task<int> Insert(Salary salary);
        public Task<int> Update(Salary salary);
        public Task<int> Delete(decimal id);
        public Task<List<Salary>> GetAll();
        public Task<Salary> GetById(decimal id);
        public Task<List<Salary>> GetByDate(DateIntervalDTO dateIntervalDTO);
        public Task<List<Salary>> GetByEmployeeId(decimal id);
        public Task<List<Salary>> GetByEmployeeIdAndDate(DateIntervalWithIdDTO dateIntervalWithIdDTO);
        public SalarySummationDto GetSummation();
        public List<SalaryWithName> GetSalary();
    }
}
