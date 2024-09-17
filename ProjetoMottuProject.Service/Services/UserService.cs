using ProjetoMottuProject.Domain.DTOs;
using ProjetoMottuProject.Domain.Entities;
using ProjetoMottuProject.Domain.Interfaces.Repository;
using ProjetoMottuProject.Domain.Interfaces.Services;
using ProjetoMottuProject.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjetoMottuProject.Domain.Responses.CustomResponses;

namespace ProjetoMottuProject.Service.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await userRepository.DeleteAsync(user);
                await userRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return await userRepository.GetByIdAsync(userId);
        }

        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO model)
        {
            var findUser = await GetUserByEmailAsync(model.Email);
            if (findUser != null) return new RegistrationResponse(false, "Usuário já existe.");

            var newUser = new UserEntity()
            {
                Email = model.Email,
                Role = model.Role,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Ativo = true,
                CriadoEm = DateTime.Now
            };

            await userRepository.AddAsync(newUser);
            await userRepository.SaveAsync();
            return new RegistrationResponse(true, "Sucesso", newUser.Id.ToString());
        }


        public async Task<UserEntity> UpdateUserAsync(UserEntity user)
        {
            var updatedUser = await userRepository.GetByIdAsync(user.Id);
            if (updatedUser != null)
            {
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.Role = updatedUser.Role;
            }
            await userRepository.UpdateAsync(user);
            await userRepository.SaveAsync();
            return await Task.FromResult(user);
        }

        private async Task<UserEntity?> GetUserByEmailAsync(string email) => await userRepository.GetUserByEmailAsync(email);
    }
}
