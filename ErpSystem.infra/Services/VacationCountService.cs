using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Services
{
    public class VacationCountService: IVacationCountService
    {
        private readonly IVacationCountRepository repository;
        public VacationCountService (IVacationCountRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Delete(decimal id)
        {
            return repository.Delete(id);
        }

        public Task<List<VacationCount>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<VacationCount> GetById(decimal id)
        {
            return repository.GetById(id);
        }

        public Task<int> Insert(VacationCount vacation)
        {
            return repository.Insert(vacation);
        }

        public Task<int> Update(VacationCount vacation)
        {
            return repository.Update(vacation);
        }
    }
}
