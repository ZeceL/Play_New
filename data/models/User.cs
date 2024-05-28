using System.ComponentModel.DataAnnotations;

namespace Play_New.data.Models
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Name_User { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
