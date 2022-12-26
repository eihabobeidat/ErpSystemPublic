using Dapper;
using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ErpSystem.infra.Repository
{
    public class JwtRepository: IJwtRepository
    {
        private readonly IDbContext context;

        public JwtRepository(IDbContext context)
        {
            this.context = context;
        }

        public AuthenticationDto Authentication(Employee employee)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IEmail", employee.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("IPassword", employee.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<AuthenticationDto> result = context.connection.Query<AuthenticationDto>("EmployeePKG.Authentication", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public CheckEmailDto CheckEmail(Employee employee)
        {
            var parameter = new DynamicParameters();
            parameter.Add("IEmail", employee.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<CheckEmailDto> result = context.connection.Query<CheckEmailDto>("EmployeePKG.CheckEmail", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
