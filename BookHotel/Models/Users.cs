using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookHotel.Models
{
    [Table("Users")]
    public class Users
    {
        [Key][Required]
        [StringLength(4)]
        public string UserID { get; set; }

        [Required, MaxLength(50)]
        public string UserEmail { get; set; }

        [Required, MaxLength(50)]
        public string UserPassword { get; set; }

        [Required][MaxLength(50)]
        public string UserName { get; set; }
    }
}
