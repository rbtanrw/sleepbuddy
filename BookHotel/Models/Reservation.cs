using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace BookHotel.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key][Required]
        [StringLength(7)]
        public string ReservationID { get; set; }

        [Required][ForeignKey("Users")]
        public string UserID { get; set; }

        [Required][ForeignKey("Room")]
        public string RoomID { get; set; }
    }
}
