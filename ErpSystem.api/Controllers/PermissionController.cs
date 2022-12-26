using ErpSystem.core.DTO;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService permissionService; 

        public PermissionController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;

        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return permissionService.Delete(id);
        }
        [HttpGet]
        public List<PermissionDTO> GetAll()
        {
            return permissionService.GetAll();
        }
        [HttpGet("GetById/{id}")]

        public PermissionDTO GetById(int id)
        {
            return permissionService.GetById(id);
        }
        [HttpPost]
        public bool Insert([FromBody]PermissionDTO permissionDTO)
        {
            return permissionService.Insert(permissionDTO);
        }
        [HttpPut]
        public bool Update(PermissionDTO permissionDTO)
        {
            return permissionService.Update(permissionDTO);
        }
    }
}
