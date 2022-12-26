using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class JwtService : IJwtService
    {
        private readonly IJwtRepository jwtRepository;

        public JwtService(IJwtRepository jwtRepository)
        {
            this.jwtRepository = jwtRepository;
        }
        public string Authentication(Employee employee)
        {
            
            var result = jwtRepository.Authentication(employee);
            if (result == null)
            {
                return null;
            }
            else
            {
                if(result.ImagePath == null)
                {
                    result.ImagePath = "";
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token, It can be any string]");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Email, result.Email),
                    new Claim("id", result.Id.ToString()),
                    new Claim(ClaimTypes.Role, result.RoleName),
                    new Claim("imagename",result.ImagePath)
                }
                ),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }

        public string CheckEmail(Employee employee)
        {
            var result = jwtRepository.CheckEmail(employee);
            if (result == null)
            {
                return "The Email "+ employee.Email +" is not avilable!";
            }
            else
            {
                return "The Email " + employee.Email + " is alredy exist";
            }
        }
    }
}
