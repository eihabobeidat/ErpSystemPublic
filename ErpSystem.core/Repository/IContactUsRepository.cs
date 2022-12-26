using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Repository
{
    public interface IContactUsRepository
    {
        public bool Insert(Contactus contactus);
        public bool Update(Contactus contactus);
        public bool Delete(int id);
        public List<Contactus> Getall();
        public Contactus GetById(int id);
    }
}
