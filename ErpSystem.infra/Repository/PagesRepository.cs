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
    public class PagesRepository: IPagesRepository
    {
        private readonly IDbContext context;

        public PagesRepository(IDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("PagesPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Pages> Getall()
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Pages> result = context.connection.Query<Pages>("PagesPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Pages GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Query<Pages>("PagesPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public string Insert(Pages pages)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IName", pages.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IValue", pages.Value, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IUpdatedBy", pages.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IUpdateTime", pages.Updatetime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("PagesPKG.Crud", p, commandType: CommandType.StoredProcedure);

            return "ok";

        }

        public bool Update(Pages pages)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", pages.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IName", pages.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IValue", pages.Value, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IUpdatedBy", pages.Updatedby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IUpdateTime", pages.Updatetime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("PagesPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
