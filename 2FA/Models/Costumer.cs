using System.ComponentModel.DataAnnotations;

namespace _2FA.Models
{
    public class Costumer
    {
        [Required]
        public int CostumerID { get; set; }
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
