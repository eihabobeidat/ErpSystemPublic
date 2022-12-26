using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Services
{
    public interface IQualificationService
    {
        public string Insert(Qualification qualification);
        public string Update(Qualification qualification);
        public string Delete(int id);
        public List<Qualification> GetQualifications();
        public Qualification GetQualificationById(int id);
        public List<GetQualNameDTO> GetQualificationsWithName();
        public List<GetQualNameDTO> GetQualificationWithNameById(int id);
    }
}
