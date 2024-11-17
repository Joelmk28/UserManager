using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyEntitySecurity.Data
{
    public class LoginDTO
    {
       // [Required(ErrorMessage = "Veillez Donner votre nom d'utilisateur")]
        
        [MaxLength(length: 100)]
        public string UserName { get; set; } = string.Empty;
        
        [MaxLength(length: 100)]
        [Column(name: "password")]
        public string PassWord { get; set; } = string.Empty;
    }
}
