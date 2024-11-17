using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEntitySecurity.Data
{
    [Table(name:"user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Veillez Donner votre nom d'utilisateur")]
        [Column(name: "username")]
        [MaxLength(length: 100)]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Veillez Donner votre mot de passe")]
        [MaxLength(length: 100)]
        [Column(name:"password")]
        public string PassWord { get; set; } = string.Empty;
        
        [Column(name: "role")]
        [MaxLength(length:20)]
        public string Role { get; set; } = string.Empty;
    }
}