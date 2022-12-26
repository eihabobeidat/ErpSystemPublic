using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Repository
{
    public interface IPermissionRepository
    {
        public bool Delete(int id);
        public PermissionDTO GetById(int id);
        public List<PermissionDTO> GetAll();
        public bool Insert(PermissionDTO permissionDTO);
        public bool Update(PermissionDTO permissionDTO);

    }
}
