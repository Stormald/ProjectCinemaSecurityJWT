using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinemaSecurityBack.Models
{
    public class LoginModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        
        [NotMapped]
        public string? Token { get; set; }
        //public string? RefreshToken { get; set; }
        //public DateTime? RefreshTokenExpireTime { get; set; }
    }
}
