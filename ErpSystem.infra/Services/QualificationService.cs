using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class QualificationService : IQualificationService

    {
        private readonly IQualificationRepository qualificationRepository;
        public QualificationService(IQualificationRepository qualification)
        {
            this.qualificationRepository = qualification;
        }

        public string Delete(int id)
        {
            return qualificationRepository.Delete(id);
        }

        public Qualification GetQualificationById(int id)
        {
            return qualificationRepository.GetQualificationById(id);
        }

        public List<Qualification> GetQualifications()
        {
            return qualificationRepository.GetQualifications();
        }

        public List<GetQualNameDTO> GetQualificationsWithName()
        {
            return qualificationRepository.GetQualificationsWithName();
        }

        public List<GetQualNameDTO> GetQualificationWithNameById(int id)
        {
            return qualificationRepository.GetQualificationWithNameById(id);
        }

        public string Insert(Qualification qualification)
        {
            return qualificationRepository.Insert(qualification);
        }

        public string Update(Qualification qualification)
        {
            return qualificationRepository.Update(qualification);
        }
    }
}
