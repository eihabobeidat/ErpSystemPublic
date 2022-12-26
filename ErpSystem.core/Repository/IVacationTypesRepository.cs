using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.core.Repository
{
    public interface IVacationTypesRepository
    {
        public Task<int> Insert(VacationTypes vacationType);
        public Task<int> Update(VacationTypes vacationType);
        public Task<int> Delete(decimal id);
        public Task<List<VacationTypes>> GetAll();
        public Task<VacationTypes> GetById(decimal id);
    }
}
