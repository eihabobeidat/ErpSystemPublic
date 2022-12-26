using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.core.Repository
{
    public interface IVacationCountRepository
    {
        public Task<int> Insert(VacationCount vacation);
        public Task<int> Update(VacationCount vacation);
        public Task<int> Delete(decimal id);
        public Task<List<VacationCount>> GetAll();
        public Task<VacationCount> GetById(decimal id);
    }
}
