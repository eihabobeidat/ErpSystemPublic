using Dapper;
using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Repository.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Repository
{
    public class VacationCountRepository : IVacationCountRepository
    {
        private readonly IDbContext dbContext;
        public VacationCountRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Delete(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Delete, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationCountPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<VacationCount>> GetAll()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetAll, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<VacationCount> vacations = await dbContext.connection.QueryAsync<VacationCount>("VacationCountPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.ToList();
        }

        public async Task<VacationCount> GetById(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetById, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<VacationCount> vacations = await dbContext.connection.QueryAsync<VacationCount>("VacationCountPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.SingleOrDefault();
        }

        public Task<int> Insert(VacationCount vacation)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Insert, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEmployeeId", vacation.Employeeid, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("ICount", vacation.Count, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("ILimit", vacation.Limit, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IType", vacation.Type, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationCountPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public Task<int> Update(VacationCount vacation)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Update, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", vacation.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEmployeeId", vacation.Employeeid, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("ICount", vacation.Count, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("ILimit", vacation.Limit, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IType", vacation.Type, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationCountPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
