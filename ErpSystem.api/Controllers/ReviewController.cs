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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;
        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }
        [HttpDelete]
        [Route("deletereview/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Delete(int id)
        {
            return reviewService.Delete(id);
        }
        [HttpGet]
        [Route("getreviewbyid/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Review GetById(int id)
        {
            return reviewService.GetById(id);
        }
        [HttpGet]
        [Route("getallreview")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<ReviewDto> GetReviews()
        {
            return reviewService.GetReviews();
        }
        [HttpPost]
        [Route("insertnewreview")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Insert(Review review)
        {
            return reviewService.Insert(review);
        }
        [HttpPut]
        [Route("updatereview")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update(Review review)
        {
            return reviewService.Update(review);
        }
        [HttpGet]
        [Route("GetTopTenEmployee")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<TopTenEmployeeDTO> GetTenTopEmployee()
        {
            return reviewService.GetTenTopEmployee();


        }
    }
}
