using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Services
{
    public class VacationTypesService: IVacationTypesService
    {
        private readonly IVacationTypesRepository repository;
        public VacationTypesService(IVacationTypesRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Delete(decimal id)
        {
            return repository.Delete(id);
        }

        public Task<List<VacationTypes>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<VacationTypes> GetById(decimal id)
        {
            return repository.GetById(id);
        }

        public Task<int> Insert(VacationTypes vacationType)
        {
            return repository.Insert(vacationType);
        }

        public Task<int> Update(VacationTypes vacationType)
        {
            return repository.Update(vacationType);
        }
    }
}
