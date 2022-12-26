using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        public bool Delete(int id)
        {
            return reviewRepository.Delete(id);
        }

        public Review GetById(int id)
        {
            return reviewRepository.GetById(id);
        }

        public List<ReviewDto> GetReviews()
        {
            return reviewRepository.GetReviews();
        }

        public bool Insert(Review review)
        {
            return  reviewRepository.Insert(review);
        }

        public bool Update(Review review)
        {
            return reviewRepository.Update(review);
        }
        public List<TopTenEmployeeDTO> GetTenTopEmployee()
        {
            return reviewRepository.GetTenTopEmployee();

        }
    }
}
