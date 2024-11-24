using BookHotel.Data;
using BookHotel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PaymentsController (AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<PaymentsController>
        // GET USER'S TRANSACTION HISTORY
        [HttpGet("UserHistory/{ID}")]
        public List<Payment> Get(string ID)
        {
            if (!_context.Users.Any(x => x.UserID == ID))
            {
                return null;
            }

            var user = _context.Users.FirstOrDefault(x => x.UserID == ID);
            if (user == null)
            {
                return null;
            }

            var PaymentList = _context.Payments.Where(x => x.UserID == ID).Select(x => new Payment
            {
                PaymentID = x.PaymentID,
                PaymentMethod = x.PaymentMethod,
                PaymentTime = x.PaymentTime,
                ReservationID = x.ReservationID,
                TotalFee = x.TotalFee,
                UserID = x.UserID
            });

            return PaymentList.ToList();
        }

        // POST NEW TRANSACTION
        [HttpPost("New/{UserID}/{ReservationID}/{Method}")]
        public async Task<ActionResult> PostAsync(string UserID, string ReservationID, string Method)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Users.Any(x => x.UserID == UserID))
            {
                return NotFound("Invalid UserID");
            }
            if (!_context.Reservations.Any(x => x.ReservationID == ReservationID))
            {
                return NotFound("Invalid ReservationID");
            }

            var reservation = _context.Reservations.FirstOrDefault(x => x.ReservationID == ReservationID);
            var room = _context.Rooms.FirstOrDefault(x => x.RoomID == reservation.RoomID);
            if (room == null)
            {
                return BadRequest("Reservation Not Valid");
            }

            var i = 0;
            foreach (Payment p in _context.Payments)
            {
                if (p.UserID == UserID)
                {
                    i++;
                }
            }

            var payment = new Payment
            {
                PaymentID = string.Concat(UserID, "TR", i.ToString("D2")),
                PaymentMethod = Method,
                PaymentTime = DateTime.Now,
                TotalFee = room.RoomPrice,
                UserID = UserID,
                ReservationID = ReservationID
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return Ok(payment);
        }
    }
}
