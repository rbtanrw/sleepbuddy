using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookHotel.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key][Required]
        [StringLength(4)]
        public string HotelID { get; set; }

        [Required, MaxLength(50)]
        public string HotelName { get; set; }

        [Required, MaxLength(50)]
        public string HotelCity { get; set; }

        [Required]
        public int HotelRoomAvailable { get; set; }

        [Required]
        public int HotelRating { get; set; }
    }
}
