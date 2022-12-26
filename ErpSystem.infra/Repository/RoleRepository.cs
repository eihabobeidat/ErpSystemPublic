using Dapper;
using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ErpSystem.infra.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext context;
        public RoleRepository(IDbContext dbContext)
        {
            this.context = dbContext;
        }
        public bool Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", id, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.connection.Execute("RolePkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Role> Get()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Role> result = context.connection.Query<Role>("RolePkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Role> result = context.connection.Query<Role>("RolePkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Role GetByName(string name)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IName", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Role> result = context.connection.Query<Role>("RolePkg.GetByName", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool Insert(Role role)
        {

            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IName", role.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.connection.Execute("RolePkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Update(Role role)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", role.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IName", role.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.connection.Execute("RolePkg.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
