using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UBEE.Data;
using UBEE.Models;

namespace UBEE.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<(bool Succeeded, string[] Errors)> RegisterUser(UserRegistrationDto model)
        {
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            {
                return (false, new[] { "User with this email already exists." });
            }

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Role = model.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }

        public async Task<(bool Succeeded, string Token)> LoginUser(UserLoginDto model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                return (false, null);
            }

            var token = GenerateJwtToken(user);

            return (true, token);
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdateUser(int id, UserUpdateDto model)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return (false, new[] { "User not found." });
            }

            user.Name = model.Name;
            user.Email = model.Email;

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            }

            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }

        public async Task<(bool Succeeded, string[] Errors)> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return (false, new[] { "User not found." });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return (true, Array.Empty<string>());
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

