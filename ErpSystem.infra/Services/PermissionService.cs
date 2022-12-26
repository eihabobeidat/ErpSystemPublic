using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }
        public bool Delete(int id)
        {
            return permissionRepository.Delete(id);
        }

        public List<PermissionDTO> GetAll()
        {
            return permissionRepository.GetAll();
        }

        public PermissionDTO GetById(int id)
        {
            return permissionRepository.GetById(id);
        }

        public bool Insert(PermissionDTO permissionDTO)
        {
            return permissionRepository.Insert(permissionDTO);
        }

        public bool Update(PermissionDTO permissionDTO)
        {
            return permissionRepository.Update(permissionDTO);
        }
    }
}
