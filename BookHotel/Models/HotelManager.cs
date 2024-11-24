using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookHotel.Models
{
    [Table("HotelManager")]
    public class HotelManager
    {
        [Key][Required]
        [StringLength(4)]
        public string AdminID { get; set; }

        [Required, MaxLength(50)]
        public string AdminPassword { get; set; }
    }
}
