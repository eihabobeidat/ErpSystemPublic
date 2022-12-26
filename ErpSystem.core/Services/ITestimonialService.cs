using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Services
{
    public interface ITestimonialService
    {
        public bool Insert(Testimonial testimonial);
        public bool Update(Testimonial testimonial);
        public bool Delete(int id);
        public List<Testimonial> Getall();
        public Testimonial GetById(int id);
        public List<HomeTestimonialDto> GetallTestimonial();
        public bool UpdateStatus(int id, int status);

    }
}
