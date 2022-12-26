
﻿using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Services
{
    public interface IAttendanceService
    {
        public bool insert(Attendance attendance);
        public List<Attendance> GetAllAttendance();
        public bool Update(Attendance attendance);
        public bool Delete(int id);
        public Attendance GetById(int id);
        public bool UpdateCheckIn(CheckInDTO checkInDTO);
        public string UpdateCheckOut(CheckOutDTO checkOutDTO);
        public List<Attendance> GetByEmployeeId(int id);
        public List<Attendance> GetByDateAndEmployeeId(DateDTO dateDTO);

    }
}
