using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.core.Repository
{
    public interface IFormalLeaveRepository
    {
        public Task<int> Insert(FormalLeave vacationType);
        public Task<int> Update(FormalLeave vacationType);
        public Task<int> Delete(decimal id);
        public Task<List<FormalLeave>> GetAll();
        public Task<FormalLeave> GetById(decimal id);
        public Task<List<FormalLeave>> GetByDate(DateTime startDate, DateTime endDate);
        public Task<List<FormalLeave>> GetByName(string name);
    }
}
