using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
       

        public bool Delete(int id)
        {
            return employeeRepository.Delete(id);
        }

        public List<Employee> Getall()
        {
            return employeeRepository.Getall();
        }

        public Employee GetById(int id)
        {
            return employeeRepository.GetById(id);
        }

        public List<Employee> GetByName(string name)
        {
            return employeeRepository.GetByName(name);
        }

        public EmployeeCoutnDto GetCount()
        {
            return employeeRepository.GetCount();
        }

        public string Insert(Employee employee)
        {
            return employeeRepository.Insert(employee);
        }

        public bool Update(Employee employee)
        {
            return employeeRepository.Update(employee);
        }

        public async Task<string> ImportExel(IFormFile file)
        {
            var list = new List<Employee>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {
                        list.Add(new Employee
                        {
                            Id = null,
                            Email = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Password = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Roleid = 4,
                            Firstname = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Lastname = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            Mobile = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            Address = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            Imagepath = null,
                            Salary = 400,                             
                        });

                    }
                }

            }
            return employeeRepository.ImportExel(list);


        }

    }
}
