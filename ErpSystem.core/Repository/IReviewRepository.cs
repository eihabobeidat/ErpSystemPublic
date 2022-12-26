using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Repository
{
    public interface IReviewRepository
    {
        public bool Insert(Review review);
        public bool Update(Review review);
        public bool Delete(int id);
        public List<ReviewDto> GetReviews();
        public Review GetById(int id);
        public List<TopTenEmployeeDTO> GetTenTopEmployee();
    }
}
