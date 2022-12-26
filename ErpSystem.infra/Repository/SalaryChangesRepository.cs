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

namespace ErpSystem.core.Repository
{
    public class SalaryChangesRepository : ISalaryChangesRepository
    {
        private readonly IDbContext dbContext;
        public SalaryChangesRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Delete(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Delete, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.ExecuteAsync("SalaryChangesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<SalaryChanges>> GetAll()
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetAll, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<SalaryChanges>("SalaryChangesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<SalaryChanges> GetById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetById, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", id, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<SalaryChanges>("SalaryChangesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task<int> Insert(SalaryChanges salaryChanges)
        {

            var p1 = new DynamicParameters();
            p1.Add("IId", salaryChanges.EmployeeId, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);

            p1.Add("IMove",salaryChanges.Value, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            await dbContext.connection.ExecuteAsync("SalariesPkg.EditSalaryInEmployee", p1, commandType: System.Data.CommandType.StoredProcedure);


            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Insert, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IEmployeeId", salaryChanges.EmployeeId, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("ITime", DateTime.Now, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IValue", salaryChanges.Value, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IDoneBy", salaryChanges.DoneBy, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IComments", salaryChanges.Comments, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            return await dbContext.connection.ExecuteAsync("SalaryChangesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> Update(SalaryChanges salaryChanges)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Update, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Input);
            p.Add("IId", salaryChanges.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IEmployeeId", salaryChanges.EmployeeId, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("ITime", salaryChanges.Time, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IValue", salaryChanges.Value, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IDoneBy", salaryChanges.DoneBy, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            p.Add("IComments", salaryChanges.Comments, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            return await dbContext.connection.ExecuteAsync("SalaryChangesPkg.Crud", p, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<SalaryChanges>> GetByDate(DateIntervalDTO dateIntervalDTO)
        {
            var p = new DynamicParameters();
            p.Add("IStart", dateIntervalDTO.StartDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IEnd", dateIntervalDTO.EndDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            var result= await dbContext.connection.QueryAsync<SalaryChanges>("SalaryChangesPkg.Search", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<SalaryChanges>> GetByEmployeeId(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("IEmployeeId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<SalaryChanges>("SalaryChangesPkg.Search", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<SalaryChanges>> GetByEmployeeIdAndDate(DateIntervalWithIdDTO dateIntervalWithIdDTO)
        {
            var p = new DynamicParameters();
            p.Add("IStart", dateIntervalWithIdDTO.StartDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IEnd", dateIntervalWithIdDTO.EndDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            p.Add("IEmployeeId", dateIntervalWithIdDTO.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            var result = await dbContext.connection.QueryAsync<SalaryChanges>("SalaryChangesPkg.Search", p, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }


    }
}
