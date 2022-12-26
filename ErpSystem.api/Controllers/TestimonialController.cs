using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public bool Insert([FromBody] Testimonial testimonial)
        {
            return testimonialService.Insert(testimonial);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return testimonialService.Delete(id);
        }

        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public List<Testimonial> Getall()
        {
            return testimonialService.Getall();
        }

        [ProducesResponseType(typeof(HomeTestimonialDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetHomeTestimonial")]
        public List<HomeTestimonialDto> GetallTestimonial()
        {
            return testimonialService.GetallTestimonial();
        }
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public bool Update([FromBody] Testimonial testimonial)
        {
            return testimonialService.Update(testimonial);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetById/{id}")]
        public Testimonial GetById(int id)
        {
            return testimonialService.GetById(id);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("UpdateStatus")]
        public bool UpdateStatus(Testimonial testimonial)
        {
            return testimonialService.UpdateStatus((int)testimonial.Id, (int)testimonial.Status);

        }
    }
}
