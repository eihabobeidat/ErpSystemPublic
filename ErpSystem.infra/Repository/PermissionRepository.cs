using Dapper;
using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ErpSystem.infra.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IDbContext context;
        public PermissionRepository(IDbContext dbContext)
        {
            this.context = dbContext;
        }


        public bool Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Execute("PermissionPkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public PermissionDTO GetById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<PermissionDTO> result = context.connection.Query<PermissionDTO>("PermissionPkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<PermissionDTO> GetAll()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PermissionDTO> result = context.connection.Query<PermissionDTO>("PermissionPkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Insert(PermissionDTO permissionDTO)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmail", permissionDTO.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ITime", permissionDTO.time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("ISalaryFlag", permissionDTO.salaryFlag, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployFlag", permissionDTO.employFlag, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Execute("PermissionPkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Update(PermissionDTO permissionDTO)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", permissionDTO.employeeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ITime", permissionDTO.time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("ISalaryFlag", permissionDTO.salaryFlag, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployFlag", permissionDTO.employFlag, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Execute("PermissionPkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
