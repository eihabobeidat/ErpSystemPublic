using Dapper;
using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Repository.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Repository
{
    public class VacationRepository : IVacationRepository
    {
        private readonly IDbContext dbContext;
        public VacationRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Approve(decimal id, decimal reviewedBy, decimal approvedBy)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IReviewedBy", reviewedBy, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IApprovedBy", approvedBy, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationPkg.Approve", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public Task<int> Delete(decimal id) 
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Delete, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            //Should return the number of rows affected
            return dbContext.connection.ExecuteAsync("VacationPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<VacationDTO>> GetAll()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetAll, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<VacationDTO> vacations = await dbContext.connection.QueryAsync<VacationDTO>("VacationPkg.Crud", parameter, commandType:System.Data.CommandType.StoredProcedure);
            return vacations.ToList();
        }

        public async Task<List<VacationDTO>> GetByDate(DateTime startDate, DateTime endDate)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IStartTime", startDate, dbType: DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEndTime", endDate, dbType: DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            IEnumerable<VacationDTO> vacations = await dbContext.connection.QueryAsync<VacationDTO>("VacationPkg.GetByDate", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.ToList();
        }

        public async Task<List<Vacation>> GetByEmployeeId(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IEmployeeid", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<Vacation> vacations = await dbContext.connection.QueryAsync<Vacation>("VacationPkg.GetById", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.ToList();
        }

        public async Task<Vacation> GetById(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetById, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<Vacation> vacations = await dbContext.connection.QueryAsync<Vacation>("VacationPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.SingleOrDefault();
        }

        public async Task<List<VacationDTO>> GetByIdAndDate(decimal Id, DateTime startDate, DateTime endDate)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IStartTime", startDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEndTime", endDate, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            IEnumerable<VacationDTO> vacations = await dbContext.connection.QueryAsync<VacationDTO>("VacationPkg.GetByDate", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.Where(x => x.Employeeid == Id).ToList();
        }

        public async Task<Vacation> GetByIdApproved(decimal id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.GetById, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            IEnumerable<Vacation> vacations = await dbContext.connection.QueryAsync<Vacation>("VacationPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return vacations.SingleOrDefault(x => x.Status == (decimal)VacationStatus.Approved);
        }

        public VacationCountDto GetCount()
        {
            var result = dbContext.connection.Query<VacationCountDto>("VacationPkg.GetCount", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public Task<int> Insert(Vacation vacation)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Insert, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEmployeeId", vacation.Employeeid, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IApprovedBy", vacation.Approvedby, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IReviewedBy", vacation.Reviewedby, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IStartTime", vacation.Starttime, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEndTime", vacation.Endtime, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IType", vacation.Type, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IStatus", vacation.Status, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IFilePath", vacation.Filepath, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IComments", vacation.Comments, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }

        public Task<int> Update(Vacation vacation)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", (decimal)CrudActions.Update, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IId", vacation.Id, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEmployeeId", vacation.Employeeid, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IApprovedBy", vacation.Approvedby, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IReviewedBy", vacation.Reviewedby, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IStartTime", vacation.Starttime, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IEndTime", vacation.Endtime, dbType: System.Data.DbType.DateTime, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IType", vacation.Type, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IStatus", vacation.Status, dbType: System.Data.DbType.Decimal, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IFilePath", vacation.Filepath, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            parameter.Add("IComments", vacation.Comments, dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Input);
            return dbContext.connection.ExecuteAsync("VacationPkg.Crud", parameter, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
