using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public bool Delete(int id)
        {
            return roleRepository.Delete(id);
        }

        public List<Role> Get()
        {
            return roleRepository.Get();
        }

        public Role GetById(int id)
        {
            return roleRepository.GetById(id);
        }

        public Role GetByName(string name)
        {
            return roleRepository.GetByName(name);
        }

        public bool Insert(Role role)
        {
            return roleRepository.Insert(role);
        }

        public bool Update(Role role)
        {
            return roleRepository.Update(role);
        }
    }
}
