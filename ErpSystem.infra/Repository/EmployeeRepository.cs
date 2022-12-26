using Dapper;
using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbContext context;

        public EmployeeRepository(IDbContext context)
        {
            this.context = context;
        }
       
       
        public bool Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("EmployeePKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Employee> Getall()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Employee> result = context.connection.Query<Employee>("EmployeePKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Employee GetById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Query<Employee>("EmployeePKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        
        }

        public List<Employee> GetByName(string name)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IFirstName", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Employee> result = context.connection.Query<Employee>("EmployeePKG.GetByName", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public EmployeeCoutnDto GetCount()
        {
            var result = context.connection.Query<EmployeeCoutnDto>("EmployeePKG.GetCount", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public string ImportExel(List<Employee> list)
        {
            
            var parameter = new DynamicParameters();
            for(int i=0;i< list.Count;i++)
            {
                parameter.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);

                parameter.Add("IEmail", list[i].Email, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("IPassword", list[i].Password, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("IRoleId", list[i].Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameter.Add("IFirstName", list[i].Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("ILastName", list[i].Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("IMobile", list[i].Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("IAddress", list[i].Address, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("IImagePath", list[i].Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("ISalary", list[i].Salary, dbType: DbType.Double, direction: ParameterDirection.Input);
                var result = context.connection.Execute("EmployeePKG.Crud", parameter, commandType: CommandType.StoredProcedure);

            }
            return "done";
        }


        public string Insert(Employee employee)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmail", employee.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IPassword", employee.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IRoleId", employee.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IFirstName", employee.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ILastName", employee.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IMobile", employee.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IAddress", employee.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IImagePath", employee.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ISalary", employee.Salary, dbType: DbType.Double, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("EmployeePKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            
            if(result.IsFaulted)
            {
                return result.Exception.Message;
            }
            return "Ok";
        }

        public bool Update(Employee employee)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", employee.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmail", employee.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IPassword", employee.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IRoleId", employee.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IFirstName", employee.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ILastName", employee.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IMobile", employee.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IAddress", employee.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IImagePath", employee.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ISalary", employee.Salary, dbType: DbType.Double, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("EmployeePKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
