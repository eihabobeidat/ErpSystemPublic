using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Services
{
    public interface IRoleService
    {
        public bool Insert(Role role);
        public List<Role> Get();
        public bool Delete(int id);
        public bool Update(Role role);
        public Role GetById(int id);

        public Role GetByName(string name);
    }
}
