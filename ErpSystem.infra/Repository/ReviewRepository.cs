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
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbContext context;
        public ReviewRepository(IDbContext dbContext)
        {
            this.context = dbContext;
        }
       

        public bool Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Execute("ReviewPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public Review GetById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Review> result = context.connection.Query<Review>("ReviewPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<ReviewDto> GetReviews()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ReviewDto> result = context.connection.Query<ReviewDto>("ReviewPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Insert(Review review)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", review.Employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IReviewedBy", review.Reviewedby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IValue", review.Value, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IObjective", review.Objective, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ICompetency", review.Competency, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ITime ", review.Time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.Execute("ReviewPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Update(Review review)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IId", review.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", review.Employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IReviewedBy", review.Reviewedby, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IValue", review.Value, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IObjective", review.Objective, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ICompetency", review.Competency, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ITime ", review.Time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.Execute("ReviewPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<TopTenEmployeeDTO> GetTenTopEmployee()
        {
            
            IEnumerable<TopTenEmployeeDTO> result = context.connection.Query<TopTenEmployeeDTO>("ReviewPkg.RetriveTopTenEmployee", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }
}
