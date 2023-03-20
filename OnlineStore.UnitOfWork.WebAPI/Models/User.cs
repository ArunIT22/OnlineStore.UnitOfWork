using System.ComponentModel.DataAnnotations;

namespace OnlineStore.UnitOfWork.WebAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string EmailId { get; set; } = null!;

        public byte[] PasswordSalt { get; set; } = null!;

        public byte[] PasswordHash { get; set; } = null!;

        public string RoleName { get; set; } = null!;
    }
}
