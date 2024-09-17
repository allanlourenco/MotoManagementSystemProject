using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoMottuProject.Domain.DTOs;
using ProjetoMottuProject.Domain.Entities;
using ProjetoMottuProject.Domain.Interfaces.Repository;
using ProjetoMottuProject.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ProjetoMottuProject.Domain.Responses.CustomResponses;

namespace ProjetoMottuProject.Service.Services
{
    public class AccountService(IUserRepository userRepository, IConfiguration configuration) : IAccountService
    {
        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            var findUser = await GetUserByEmailAsync(model.Email);
            if (findUser == null) return new LoginResponse(false, "Usuário não encontrado.");

            if (!BCrypt.Net.BCrypt.Verify(model.Password, findUser.Password))
                return new LoginResponse(false, "Email ou senha inválidos.");

            string jwtToken = GenerateToken(findUser);
            return new LoginResponse(true, "Login feito com sucesso.", jwtToken, findUser.Email);
        }

        private string GenerateToken(UserEntity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       

        private async Task<UserEntity?> GetUserByEmailAsync(string email) => await userRepository.GetUserByEmailAsync(email);
    }
}
