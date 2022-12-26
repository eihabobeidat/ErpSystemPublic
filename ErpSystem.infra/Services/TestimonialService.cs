using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public  class TestimonialService: ITestimonialService
    {
        private readonly ITestimonialRepository testiomonialRepository;

        public TestimonialService(ITestimonialRepository testiomonialRepository)
        {
            this.testiomonialRepository = testiomonialRepository;
        }

        public bool Delete(int id)
        {
            return testiomonialRepository.Delete(id);
        }

        public List<Testimonial> Getall()
        {
            return testiomonialRepository.Getall();
        }

        public List<HomeTestimonialDto> GetallTestimonial()
        {
            return testiomonialRepository.GetallTestimonial();
        }

        public Testimonial GetById(int id)
        {
            return testiomonialRepository.GetById(id);
        }

        public bool Insert(Testimonial testimonial)
        {
            return testiomonialRepository.Insert(testimonial);
        }

        public bool Update(Testimonial testimonial)
        {
            return testiomonialRepository.Update(testimonial);
        }

        public bool UpdateStatus(int id, int status)
        {
            return testiomonialRepository.UpdateStatus(id, status);
        }
    }
}
