using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class AboutServiceService: IAboutServiceService
    {
        private readonly IAboutServiceRepository aboutServiceRepository;

        public AboutServiceService(IAboutServiceRepository aboutServiceRepository)
        {
            this.aboutServiceRepository = aboutServiceRepository;
        }

        public bool Delete(int id)
        {
            return aboutServiceRepository.Delete(id);
        }

        public List<AboutService> Getall()
        {
            return aboutServiceRepository.Getall();
        }

        public AboutService GetById(int id)
        {
            return aboutServiceRepository.GetById(id);
        }

        public string Insert(AboutService aboutService)
        {
            return aboutServiceRepository.Insert(aboutService);
        }

        public bool Update(AboutService aboutService)
        {
            return aboutServiceRepository.Update(aboutService);
        }
        
    }
}
