using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Account
    {
        [Key, MaxLength(25)]
        public string Username { get; set; }
        [MaxLength(25)]
        public string Password { get; set; }
        [MaxLength(25)]
        public string Role { get; set; }
    }
}