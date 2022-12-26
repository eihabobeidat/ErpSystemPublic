using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class PagesService: IPagesService
    {
        private readonly IPagesRepository pagesRepository;

        public PagesService(IPagesRepository pagesRepository)
        {
            this.pagesRepository = pagesRepository;
        }

        public bool Delete(int id)
        {
            return pagesRepository.Delete(id);
        }

        public List<Pages> Getall()
        {
            return pagesRepository.Getall();
        }

        public Pages GetById(int id)
        {
            return pagesRepository.GetById(id);
        }

        public string Insert(Pages pages)
        {
            return pagesRepository.Insert(pages);
        }

        public bool Update(Pages pages)
        {
            return pagesRepository.Update(pages);
        }
    }
}
