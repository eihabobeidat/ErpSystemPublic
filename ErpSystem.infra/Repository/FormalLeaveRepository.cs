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
    public class FormalLeaveRepository: IFormalLeaveRepository
    {
        private readonly IDbContext dbContext;
        public FormalLeaveRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Delete(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Delete, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("FormalLeavePKG.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<FormalLeave>> GetAll()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetAll, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<FormalLeave> vacations = await dbContext.connection.QueryAsync<FormalLeave>("FormalLeavePKG.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.ToList();
        }

        public async Task<List<FormalLeave>> GetByDate(DateTime startDate, DateTime endDate)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IStartTime", startDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEndTime", endDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            IEnumerable<FormalLeave> vacations = await dbContext.connection.QueryAsync<FormalLeave>("FormalLeavePKG.GetByDate", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.ToList();
        }

        public async Task<FormalLeave> GetById(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetById, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<FormalLeave> vacations = await dbContext.connection.QueryAsync<FormalLeave>("FormalLeavePKG.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.SingleOrDefault();
        }

        public async Task<List<FormalLeave>> GetByName(string name)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IName", name, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            IEnumerable<FormalLeave> vacations = await dbContext.connection.QueryAsync<FormalLeave>("FormalLeavePKG.GetByName", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.ToList();
        }

        public Task<int> Insert(FormalLeave vacationType)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Insert, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IName", vacationType.Name, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            parameter.Add("ITime", vacationType.Time, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("FormalLeavePKG.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public Task<int> Update(FormalLeave vacationType)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Update, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", vacationType.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IName", vacationType.Name, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            parameter.Add("ITime", vacationType.Time, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("FormalLeavePKG.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
