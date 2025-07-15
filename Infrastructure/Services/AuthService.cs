using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        // Geçici kullanıcı listesi (ileride DB kullanılacak)
        private static readonly List<User> _users = new();

        public Task<string> RegisterAsync(RegisterRequest request)
        {
            if (_users.Any(u => u.Email == request.Email))
                throw new Exception("Bu email adresi zaten kayıtlı.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = hashedPassword
            };

            _users.Add(user);

            return Task.FromResult("Kayıt başarılı.");
        }

        public Task<string> LoginAsync(LoginRequest request)
        {
            var user = _users.FirstOrDefault(u => u.Email == request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Email veya parola hatalı.");

            return Task.FromResult("Giriş başarılı.");
        }
    }
}
