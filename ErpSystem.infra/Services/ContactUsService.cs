using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository contactusRepository;

        public ContactUsService(IContactUsRepository contactusRepository)
        {
            this.contactusRepository = contactusRepository;
        }
        public bool Delete(int id)
        {
            return contactusRepository.Delete(id);
        }

        public List<Contactus> Getall()
        {
            return contactusRepository.Getall();
        }

        public Contactus GetById(int id)
        {
            return contactusRepository.GetById(id);
        }

        public bool Insert(Contactus contactus)
        {
            return contactusRepository.Insert(contactus);
        }

        public bool Update(Contactus contactus)
        {
            return contactusRepository.Update(contactus);
        }
    }
}
