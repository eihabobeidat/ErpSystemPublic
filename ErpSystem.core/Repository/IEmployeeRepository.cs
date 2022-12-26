using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.core.Repository
{
    public interface IEmployeeRepository
    {
        public string Insert(Employee employee);
        public bool Update(Employee employee);
        public bool Delete(int id);
        public List<Employee> Getall();
        public Employee GetById(int id);
        public List<Employee> GetByName(string name);
        public EmployeeCoutnDto GetCount();
        public string ImportExel(List<Employee> list);
    }
}
