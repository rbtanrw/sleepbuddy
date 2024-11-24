using BookHotel.Data;
using BookHotel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<RoomController>
        // GET ROOM AVAILABLE BY HOTEL ID
        [HttpGet("AvailableRoom/{HotelID}")]
        public List<Room> Get(string HotelID)
        {
            var RoomList = _context.Rooms.Where(x => x.HotelID == HotelID && x.RoomAvailability != false).Select(x => new Room
            {
                RoomID = x.RoomID,
                RoomPrice = x.RoomPrice,
                RoomCategory = x.RoomCategory,
                HotelID = x.HotelID
            });
            return RoomList.ToList();
        }

        // PUT api/<RoomController>/5
        // CHANGE ROOM AVAILABILITY TO FALSE
        /*
        [HttpPut("{ID}/false")]
        public async Task<ActionResult> PutFalseAsync(string ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Rooms.Any(x => x.RoomID == ID))
            {
                return NotFound("Invalid RoomID");
            }

            var room = _context.Rooms.FirstOrDefault(x => x.RoomID == ID);
            if (room != null)
            {
                room.RoomAvailability = false;
            }

            await _context.SaveChangesAsync();
            return Ok(room);
        }
        */
        // PUT api/<RoomController>/5
        // CHANGE ROOM AVAILABILITY TO TRUE
        [HttpPut("RemoveBooked/{ID}/true")]
        public async Task<ActionResult> PutTrueAsync(string ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Rooms.Any(x => x.RoomID == ID))
            {
                return NotFound("Invalid RoomID");
            }

            var room = _context.Rooms.FirstOrDefault(x => x.RoomID == ID);
            if (room != null)
            {
                room.RoomAvailability = true;
            }

            await _context.SaveChangesAsync();
            return Ok(room);
        }
    }
}
