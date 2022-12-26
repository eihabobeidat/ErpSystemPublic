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
    public class TestimonialRepository: ITestimonialRepository
    {
        private readonly IDbContext context;

        public TestimonialRepository(IDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("TestimonialPKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Testimonial> Getall()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Testimonial> result = context.connection.Query<Testimonial>("TestimonialPKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<HomeTestimonialDto> GetallTestimonial()
        {
            IEnumerable<HomeTestimonialDto> result = context.connection.Query<HomeTestimonialDto>("TestimonialPKG.HomeTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testimonial GetById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Query<Testimonial>("TestimonialPKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public bool Insert(Testimonial testimonial)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", testimonial.Employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IMessage", testimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ITime",testimonial.Time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("IStatus", testimonial.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("TestimonialPKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;

        }

        

        public bool Update(Testimonial testimonial)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId",testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", testimonial.Employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IMessage", testimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ITime", testimonial.Time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("IStatus", testimonial.Status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("TestimonialPKG.Crud", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateStatus(int id, int status)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IStatus", status, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("TestimonialPKG.UpdateStatus", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
