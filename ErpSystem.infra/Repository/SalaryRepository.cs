using ErpSystem.core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using ErpSystem.infra.Repository;
using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System.Data;

namespace ErpSystem.core.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly IDbContext dbContext;
        public SalaryRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Delete(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Delete, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.ExecuteAsync("SalariesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<Salary>> GetAll()
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetAll, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<Salary>("SalariesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Salary> GetById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetById, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", id, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<Salary>("SalariesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task<int> Insert(Salary salary)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Insert, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IEmployeeId", salary.EmployeeId, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("ITime", salary.Time, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IValue", salary.Value, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            return await dbContext.connection.ExecuteAsync("SalariesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> Update(Salary salary)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Update, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", salary.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IEmployeeId", salary.EmployeeId, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("ITime", salary.Time, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IValue", salary.Value, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            return await dbContext.connection.ExecuteAsync("SalariesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<Salary>> GetByDate(DateIntervalDTO dateIntervalDTO)
        {
            var p = new DynamicParameters();
            p.Add("IStart", dateIntervalDTO.StartDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IEnd", dateIntervalDTO.EndDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            var result= await dbContext.connection.QueryAsync<Salary>("SalariesPkg.Search", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Salary>> GetByEmployeeId(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("IEmployeeId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<Salary>("SalariesPkg.Search", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Salary>> GetByEmployeeIdAndDate(DateIntervalWithIdDTO dateIntervalWithIdDTO)
        {
            var p = new DynamicParameters();
            p.Add("IStart", dateIntervalWithIdDTO.StartDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IEnd", dateIntervalWithIdDTO.EndDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IEmployeeId", dateIntervalWithIdDTO.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<Salary>("SalariesPkg.Search", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public SalarySummationDto GetSummation()
        {
            var result = dbContext.connection.Query<SalarySummationDto>("SalariesPkg.GetSummation", commandType: System.Data.CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
        public List<SalaryWithName> GetSalary()
        {
            var p = new DynamicParameters();
            IEnumerable<SalaryWithName> result = dbContext.connection.Query<SalaryWithName>("SalariesPkg.GetAllWithName", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
