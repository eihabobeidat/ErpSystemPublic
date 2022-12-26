using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Repository
{
    public interface IAboutServiceRepository
    {
        public string Insert(AboutService aboutService);
        public bool Update(AboutService aboutService);
        public bool Delete(int id);
        public List<AboutService> Getall();
        public AboutService GetById(int id);
    }
}

