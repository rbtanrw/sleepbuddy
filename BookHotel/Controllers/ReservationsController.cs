using BookHotel.Data;
using BookHotel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReservationsController (AppDbContext context)
        {
            _context = context;
        }

        // GET USER'S RESERVATION
        [HttpGet("UserRsv/{ID}")]
        public List<Reservation> Get(string ID)
        {
            var ReservationList = _context.Reservations.Where(x => x.UserID == ID).Select(x => new Reservation
            {
                ReservationID = x.ReservationID,
                RoomID = x.RoomID,
                UserID = x.UserID
            });
            return ReservationList.ToList();
        }

        // POST NEW RESERVATION
        [HttpPost("New/{UserID}/{RoomID}")]
        public async Task<ActionResult> PostAsync(string UserID, string RoomID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Users.Any(x => x.UserID == UserID))
            {
                return NotFound("Invalid UserID");
            }
            if (!_context.Rooms.Any(x => x.RoomID == RoomID))
            {
                return NotFound("Invalid RoomID");
            }

            var room = _context.Rooms.FirstOrDefault(x => x.RoomID == RoomID);
            room.RoomAvailability = false;

            var HotelID = room.HotelID;
            var hotel = _context.Hotels.FirstOrDefault(x => x.HotelID == HotelID);
            if (hotel != null)
            {
                hotel.HotelRoomAvailable -= 1;
            }

            var i = 0;
            foreach (Reservation p in _context.Reservations)
            {
                if (p.UserID == UserID)
                {
                    i++;
                }
            }

            var reservation = new Reservation
            {
                ReservationID = string.Concat(UserID, "R", i.ToString("D2")),
                RoomID = RoomID,
                UserID = UserID
            };


            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return Ok(reservation);
        }
    }
}
