using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Services
{
    public interface IJwtService
    {
        public string Authentication(Employee employee);
        public string CheckEmail(Employee employee);

    }
}
