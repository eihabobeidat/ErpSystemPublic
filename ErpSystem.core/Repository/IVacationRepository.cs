using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.core.Repository
{
    public interface IVacationRepository
    {
        public Task<int> Insert(Vacation vacation);
        public Task<int> Update(Vacation vacation);
        public Task<int> Delete(decimal id);
        public Task<List<VacationDTO>> GetAll();
        public Task<Vacation> GetById(decimal id);
        public Task<int> Approve(decimal id, decimal reviewedBy, decimal approvedBy);
        public Task<Vacation> GetByIdApproved(decimal id);
        public Task<List<Vacation>> GetByEmployeeId(decimal id);
        public Task<List<VacationDTO>> GetByDate(DateTime startDate, DateTime endDate);
        public Task<List<VacationDTO>> GetByIdAndDate(decimal Id, DateTime startDate, DateTime endDate);
        public VacationCountDto GetCount();
    }
}
