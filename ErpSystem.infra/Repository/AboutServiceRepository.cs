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
    public class AboutServiceRepository : IAboutServiceRepository
    {
        private readonly IDbContext context;

        public AboutServiceRepository(IDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("AboutServicesPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<AboutService> Getall()
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AboutService> result = context.connection.Query<AboutService>("AboutServicesPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public AboutService GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Query<AboutService>("AboutServicesPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public string Insert(AboutService aboutService)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ITitle", aboutService.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IImagePath", aboutService.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IDescription", aboutService.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("AboutServicesPKG.Crud", p, commandType: CommandType.StoredProcedure);

            return "ok";

        }

        public bool Update(AboutService aboutService)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", aboutService.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ITitle", aboutService.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IImagePath", aboutService.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IDescription", aboutService.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.connection.Execute("AboutServicesPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateImage(string name , int id)
        {
            var p = new DynamicParameters();
            p.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IImagePath", name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = context.connection.Execute("AboutServicesPKG.UpdateImage", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
