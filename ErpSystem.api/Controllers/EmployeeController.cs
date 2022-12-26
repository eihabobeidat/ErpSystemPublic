using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("importexcel")]
        public Task<string> ImportExcel(IFormFile file)
        {
            return employeeService.ImportExel(file);
        }
       

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public string Insert([FromBody] Employee employee)
        {
            return employeeService.Insert(employee);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return employeeService.Delete(id);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("employeelist")]
        public List<Employee> Getall()
        {
            return employeeService.Getall();
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("updateemployee")]
        public bool Update([FromBody]Employee employee)
        {
            return employeeService.Update(employee);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetById/{id}")]
        public Employee GetById(int id)
        {
            return employeeService.GetById(id);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetByName/{name}")]
        public List<Employee> GetByName(string name)
        {
            return employeeService.GetByName(name);
        }

        [ProducesResponseType(typeof(EmployeeCoutnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetCount")]
        public EmployeeCoutnDto GetCount()
        {
            return employeeService.GetCount();
        }

        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("UploadImage")]
        public Employee UploadImage()
        {
            
            var file = Request.Form.Files[0];
            Byte[] fileimagecontent;
            try
            {
                using (var memory = new MemoryStream())
                {
                    file.CopyTo(memory);
                    fileimagecontent = memory.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string imageFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                string path = Path.Combine("./../../ERPSystemFE/src/assets/EmployeeImg/", imageFileName);
                using (var files = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(files);
                }

                Employee employee = new Employee();
                employee.Imagepath = imageFileName;
                return employee;
            }

            catch (FileLoadException e)
            {
                return null;
            }
        }
    }


    }
