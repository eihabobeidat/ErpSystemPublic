using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Repository
{
    public interface IPagesRepository
    {
        public string Insert(Pages pages);
        public bool Update(Pages pages);
        public bool Delete(int id);
        public List<Pages> Getall();
        public Pages GetById(int id);
    }
}

