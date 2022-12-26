
﻿using System;
﻿using ErpSystem.core.Repository;

﻿using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Services;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{ 

    public class AttendanceService : IAttendanceService


    {
        private readonly IAttendanceRepository attendanceRepository;
        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            this.attendanceRepository = attendanceRepository;
        }
        public bool Delete(int id)
        {
            return attendanceRepository.Delete(id);
        }

        public List<Attendance> GetAllAttendance()
        {
            return attendanceRepository.GetAllAttendance();
        }

        public List<Attendance> GetByDateAndEmployeeId(DateDTO dateDTO)
        {
            return attendanceRepository.GetByDateAndEmployeeId(dateDTO);
        }

        public List<Attendance> GetByEmployeeId(int id)
        {
            return attendanceRepository.GetByEmployeeId(id);
        }

        public Attendance GetById(int id)
        {
            return attendanceRepository.GetById(id);
        }

        public bool insert(Attendance attendance)
        {
            return attendanceRepository.insert(attendance);
        }

        public bool Update(Attendance attendance)
        {
            return attendanceRepository.Update(attendance);
        }

        public bool UpdateCheckIn(CheckInDTO checkInDTO)
        {
            return attendanceRepository.UpdateCheckIn(checkInDTO);
        }

        public string UpdateCheckOut(CheckOutDTO checkOutDTO)
        {
            return attendanceRepository.UpdateCheckOut(checkOutDTO);
        }
    }
}
