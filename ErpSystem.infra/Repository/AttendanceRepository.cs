
﻿using System;
﻿using ErpSystem.core.Repository;
using ErpSystem.core.Services;

﻿using Dapper;
using ErpSystem.core.Data;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ErpSystem.core.Common;
using System.Linq;
using ErpSystem.core.DTO;

namespace ErpSystem.infra.Repository
{

    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IDbContext context;
        public AttendanceRepository(IDbContext dbContext)
        {
            this.context = dbContext;
        }

        public bool Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IAction", CRUD.Delete, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = context.connection.Execute("AttendancePkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return true;

        }

        public List<Attendance> GetAllAttendance()
        {
            var parameter = new DynamicParameters();

            parameter.Add("IAction", CRUD.GetAll, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Attendance> result = context.connection.Query<Attendance>("AttendancePkg.CRUD",parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<Attendance> GetByDateAndEmployeeId(DateDTO dateDTO)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IEmployeeId", dateDTO.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IDateFrom", dateDTO.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("IDateTo", dateDTO.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Attendance> result = context.connection.Query<Attendance>("AttendancePkg.GetByDateAndEmployeeId", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<Attendance> GetByEmployeeId(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IEmployeeId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Attendance> result = context.connection.Query<Attendance>("AttendancePkg.GetByEmployeeId", parameter, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Attendance GetById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IAction", CRUD.GetById, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Attendance> result = context.connection.Query<Attendance>("AttendancePkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool insert(Attendance attendance)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Insert, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("IId", null, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", attendance.Employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ICheckIn", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("ICheckOut", null, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.Execute("AttendancePkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Update(Attendance attendance)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IAction", CRUD.Update, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("IId", attendance.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("IEmployeeId", attendance.Employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ICheckIn", attendance.Checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("ICheckOut", attendance.Checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.Execute("AttendancePkg.CRUD", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateCheckIn(CheckInDTO checkInDTO)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", checkInDTO.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ICheckIn", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.Execute("AttendancePkg.UpdateCheckIn", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public string UpdateCheckOut(CheckOutDTO checkOutDTO)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IId", checkOutDTO.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("ICheckOut", DateTime.Now , dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = context.connection.ExecuteAsync("AttendancePkg.UpdateCheckOut", parameter, commandType: CommandType.StoredProcedure);
            if (result.IsFaulted)
            {
                return result.Exception.Message;
            }
            else
                return "Update Sucsess";
        }
    }
}
