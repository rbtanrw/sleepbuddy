using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookHotel.Models
{
    [Table("Payment")]
    public class Payment
    {
        [Key][Required]
        [StringLength(8)]
        public string PaymentID { get; set; }

        [Required, MaxLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        public DateTime PaymentTime { get; set; }

        [Required]
        public int TotalFee { get; set; }

        [Required][ForeignKey("Users")]
        public string UserID { get; set; }

        [Required][ForeignKey("Reservation")]
        public string ReservationID { get; set; }
    }
}
