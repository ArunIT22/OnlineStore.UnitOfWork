using System.ComponentModel.DataAnnotations;

namespace OnlineStore.UnitOfWork.WebAPI.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string EmailId { get; set; } = null!;
        public string RoleName { get; set; } = null!;
    }

    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
