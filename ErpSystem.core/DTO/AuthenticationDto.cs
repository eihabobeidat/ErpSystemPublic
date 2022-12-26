using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.DTO
{
    public class AuthenticationDto
    {
        public string Email { get; set; }
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string ImagePath { get; set; }
    }
}
