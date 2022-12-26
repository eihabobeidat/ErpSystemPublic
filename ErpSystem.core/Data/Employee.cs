using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErpSystem.core.Data
{
    public  class Employee
    {
        public decimal? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal?  Roleid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Imagepath { get; set; }
        public decimal? Salary { get; set; }

        public virtual Role Role { get; set; }
        public virtual Review ReviewEmployee { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Message> MessageReceiverNavigations { get; set; }
        public virtual ICollection<Message> MessageSenderNavigations { get; set; }
        public virtual ICollection<Pages> Pages { get; set; }
        public virtual ICollection<Qualification> Qualifications { get; set; }
        public virtual ICollection<Review> ReviewReviewedbyNavigations { get; set; }

        public virtual ICollection<SalaryChanges> Salaries { get; set; }
        public virtual ICollection<SalaryChanges> SalarychangeDonebyNavigations { get; set; }
        public virtual ICollection<SalaryChanges> SalarychangeEmployees { get; set; }

        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Vacation> VacationApprovedbyNavigations { get; set; }
        public virtual ICollection<Vacation> VacationEmployees { get; set; }
        public virtual ICollection<Vacation> VacationReviewedbyNavigations { get; set; }
        public virtual ICollection<VacationCount> Vacationcounts { get; set; }
    }
}
