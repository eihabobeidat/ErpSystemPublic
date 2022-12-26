using ErpSystem.core.Data;
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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleServices;
        public RoleController (IRoleService roleServices)
        {
            this.roleServices = roleServices;
        }
        [HttpPost]
        [Route("addnewuserrole")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool insert([FromBody] Role role)
        {
            return roleServices.Insert(role);
        }
        [HttpDelete]
        [Route("deleteuserrole/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Delete(int id)
        {
            return roleServices.Delete(id);
        }
        [HttpPut]
        [Route("updateuserrole")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update([FromBody] Role role)
        {
            return roleServices.Update(role);
        }
        [HttpGet]
        [Route("getalluserrole")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Role> Get()
        {
            return roleServices.Get();
        }
        [HttpGet]
        [Route("getuserrolebyid/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Role GetById(int id)
        {
            return roleServices.GetById(id);
        }
        [HttpGet]
        [Route("getuserrolebyname/{name}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Role GetByName(string name)
        {
            return roleServices.GetByName(name);
        }
    }
}
