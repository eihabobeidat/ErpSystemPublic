using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Repository
{
    public interface IJwtRepository
    {
        public AuthenticationDto Authentication(Employee employee);
        public CheckEmailDto CheckEmail(Employee employee);
    }
}
