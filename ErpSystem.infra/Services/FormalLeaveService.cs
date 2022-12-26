using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Services
{
    public class FormalLeaveService : IFormalLeaveService
    {
        private readonly IFormalLeaveRepository repository;
        public FormalLeaveService(IFormalLeaveRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Delete(decimal id)
        {
            return repository.Delete(id);
        }

        public Task<List<FormalLeave>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<List<FormalLeave>> GetByDate(DateTime startDate, DateTime endDate)
        {
            return repository.GetByDate(startDate, endDate);
        }

        public Task<FormalLeave> GetById(decimal id)
        {
            return repository.GetById(id);
        }

        public Task<List<FormalLeave>> GetByName(string name)
        {
            return repository.GetByName(name);
        }

        public Task<int> Insert(FormalLeave vacationType)
        {
            return repository.Insert(vacationType);
        }

        public Task<int> Update(FormalLeave vacationType)
        {
            return repository.Update(vacationType);
        }
    }
}
