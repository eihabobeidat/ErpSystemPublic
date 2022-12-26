using Dapper;
using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ErpSystem.core.Common;
using System.Linq;
using ErpSystem.core.DTO;

namespace ErpSystem.infra.Repository
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly IDbContext Context;
        public QualificationRepository(IDbContext dbContext)
        {
            this.Context = dbContext;
        }
        public string Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = Context.connection.ExecuteAsync("QualificationPkg.CRUD", parameter,commandType:CommandType.StoredProcedure);

            if(result.IsFaulted)
            {
                return result.Exception.Message;

            }
            else
            {
                return "The Qualification is deleted Successfully";
            }

        }

        public Qualification GetQualificationById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Qualification> Result = Context.connection.Query<Qualification>("QualificationPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public List<Qualification> GetQualifications()
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Qualification> Result = Context.connection.Query<Qualification>("QualificationPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }

        public List<GetQualNameDTO> GetQualificationsWithName()
        {
            IEnumerable<GetQualNameDTO> Result = Context.connection.Query<GetQualNameDTO>("QualificationPkg.GetNameAndFile", commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }
        //
        public List<GetQualNameDTO> GetQualificationWithNameById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<GetQualNameDTO> Result = Context.connection.Query<GetQualNameDTO>("QualificationPkg.GetNameAndFileById", parameter, commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }

        public string Insert(Qualification qualification)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", qualification.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ITime", qualification.Time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("IFilePath", qualification.Filepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ITitle", qualification.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", qualification.Employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = Context.connection.ExecuteAsync("QualificationPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result.IsFaulted)
            {
                return result.Exception.Message;

            }
            else
            {
                return "The Qualification Insert Successfully";
            }
        }

        public string Update(Qualification qualification)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", qualification.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ITime", qualification.Time, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("IFilePath", qualification.Filepath, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("ITitle", qualification.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", qualification.Employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = Context.connection.ExecuteAsync("QualificationPkg.CRUD", parameter, commandType: CommandType.StoredProcedure);

            if (result.IsFaulted)
            {
                return result.Exception.Message;

            }
            else
            {
                return "The Qualification Update Successfully";
            }
        }
    }
}
