using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookHotel.Models
{
    [Table("Room")]
    public class Room
    {
        [Key][Required]
        [StringLength(8)]
        public string RoomID { get; set; }

        [Required]
        public int RoomPrice { get; set; }

        [Required, MaxLength(25)]
        public string RoomCategory { get; set; }

        [Required]
        public bool RoomAvailability { get; set; }

        [Required][ForeignKey("Hotel")]
        public string HotelID { get; set; }
    }
}
