using System.ComponentModel.DataAnnotations;

namespace _2FA.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string? CPF { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
