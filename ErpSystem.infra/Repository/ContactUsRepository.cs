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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDbContext context;

        public ContactUsRepository(IDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("ContactusPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Contactus> Getall()
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Contactus> result = context.connection.Query<Contactus>("ContactusPKG.Crud",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Contactus GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Query<Contactus>("ContactusPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public bool Insert(Contactus contactus)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IEmail", contactus.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IDescription", contactus.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ITime", contactus.Time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("ContactusPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return true;


        }

        public bool Update(Contactus contactus)
        {
            var p = new DynamicParameters();
            p.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IId", contactus.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IEmail", contactus.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IDescription", contactus.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ITime", contactus.Time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("ContactusPKG.Crud", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }

     

        
    
}
