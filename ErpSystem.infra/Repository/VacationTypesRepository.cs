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
    public class VacationTypesRepository : IVacationTypesRepository
    {
        private readonly IDbContext dbContext;
        public VacationTypesRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Delete(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Delete, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationTypePkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<VacationTypes>> GetAll()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetAll, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<VacationTypes> vacations = await dbContext.connection.QueryAsync<VacationTypes>("VacationTypePkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.ToList();
        }

        public async Task<VacationTypes> GetById(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetById, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<VacationTypes> vacations = await dbContext.connection.QueryAsync<VacationTypes>("VacationTypePkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.SingleOrDefault();
        }

        public Task<int> Insert(VacationTypes vacationType)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Insert, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IName", vacationType.Name, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationTypePkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public Task<int> Update(VacationTypes vacationType)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Update, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", vacationType.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IName", vacationType.Name, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationTypePkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
