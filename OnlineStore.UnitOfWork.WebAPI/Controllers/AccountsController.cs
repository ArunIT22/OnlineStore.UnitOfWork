using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.UnitOfWork.WebAPI.DTO;
using OnlineStore.UnitOfWork.WebAPI.Models;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OnlineStore.UnitOfWork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest();
            }
            var (salt, hash) = CreatePasswordHash(registerDto.Password);
            User userData = new User
            {
                Username = registerDto.Username,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                EmailId = registerDto.EmailId,
                RoleName = registerDto.RoleName,
                PasswordSalt = salt,
                PasswordHash = hash
            };

            _context.Users.Add(userData);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var currentUser = _context.Users.SingleOrDefault(x => x.Username == login.Username);
            if (currentUser == null)
            {
                return BadRequest("Invalid Username");
            }
            var isValidPassword = VerifyPassword(login.Password, currentUser.PasswordSalt, currentUser.PasswordHash);
            if (!isValidPassword)
            {
                return BadRequest("Invalid Password");
            }
            var token = GenerateToken(currentUser);
            if (token == null)
            {
                return BadRequest("Invalid Credentials");
            }
            return Ok(token);
        }

        [NonAction]
        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var myClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email,user.EmailId),
                new Claim(ClaimTypes.Role, user.RoleName),
                new Claim(ClaimTypes.GivenName, user.FirstName)
            };

            var token = new JwtSecurityToken(issuer: _configuration["JWT:issuer"],
                                             //audience: _configuration["JWT:issuer"],
                                             claims: myClaims,
                                             expires: DateTime.Now.AddDays(1),
                                             signingCredentials: credentials
                                             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [NonAction]
        public (byte[] salt, byte[] hash) CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var passwordSalt = hmac.Key;
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return (passwordSalt, passwordHash);
            }
        }

        [NonAction]
        public bool VerifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmca = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmca.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
