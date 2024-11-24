using BookHotel.Data;
using BookHotel.Models;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Linq;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HotelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<HotelsController>
        // GET ALL HOTEL
        [HttpGet]
        public List<Hotel> Get()
        {
            var HotelList = _context.Hotels.Select(x => new Hotel
            {
                HotelID = x.HotelID,
                HotelName = x.HotelName,
                HotelCity = x.HotelCity,
                HotelRating = x.HotelRating,
                HotelRoomAvailable = x.HotelRoomAvailable,
            });
            return HotelList.ToList();
        }

        // SEARCH HOTEL
        [HttpGet("Search")]
        public List<Hotel> GetHotel(string Name, string City, int Rating)
        {
            if(Name != null && City != null && Rating != 0)
            {
                var HotelList = _context.Hotels.Where(x => x.HotelCity == City && x.HotelName.Contains(Name) && x.HotelRating == Rating).Select(x => new Hotel
                {
                    HotelID = x.HotelID,
                    HotelName = x.HotelName,
                    HotelCity = x.HotelCity,
                    HotelRating = x.HotelRating,
                    HotelRoomAvailable = x.HotelRoomAvailable,
                });
                return HotelList.ToList();
            }

            else if(Name != null && City != null)
            {
                var HotelList = _context.Hotels.Where(x => x.HotelCity == City && x.HotelName.Contains(Name)).Select(x => new Hotel
                {
                    HotelID = x.HotelID,
                    HotelName = x.HotelName,
                    HotelCity = x.HotelCity,
                    HotelRating = x.HotelRating,
                    HotelRoomAvailable = x.HotelRoomAvailable,
                });
                return HotelList.ToList();
            }

            else if(Name != null && Rating != 0)
            {
                var HotelList = _context.Hotels.Where(x => x.HotelName.Contains(Name) && x.HotelRating == Rating).Select(x => new Hotel
                {
                    HotelID = x.HotelID,
                    HotelName = x.HotelName,
                    HotelCity = x.HotelCity,
                    HotelRating = x.HotelRating,
                    HotelRoomAvailable = x.HotelRoomAvailable,
                });
                return HotelList.ToList();
            }

            else if(City != null && Rating != 0)
            {
                var HotelList = _context.Hotels.Where(x => x.HotelCity == City && x.HotelRating == Rating).Select(x => new Hotel
                {
                    HotelID = x.HotelID,
                    HotelName = x.HotelName,
                    HotelCity = x.HotelCity,
                    HotelRating = x.HotelRating,
                    HotelRoomAvailable = x.HotelRoomAvailable,
                });
                return HotelList.ToList();
            }

            else if(Name != null)
            {
                var HotelList = _context.Hotels.Where(x => x.HotelName.Contains(Name)).Select(x => new Hotel
                {
                    HotelID = x.HotelID,
                    HotelName = x.HotelName,
                    HotelCity = x.HotelCity,
                    HotelRating = x.HotelRating,
                    HotelRoomAvailable = x.HotelRoomAvailable,
                });
                return HotelList.ToList();
            }

            else if(City != null)
            {
                var HotelList = _context.Hotels.Where(x => x.HotelCity == City).Select(x => new Hotel
                {
                    HotelID = x.HotelID,
                    HotelName = x.HotelName,
                    HotelCity = x.HotelCity,
                    HotelRating = x.HotelRating,
                    HotelRoomAvailable = x.HotelRoomAvailable,
                });
                return HotelList.ToList();
            }

            else if(Rating != 0)
            {
                var HotelList = _context.Hotels.Where(x => x.HotelRating == Rating).Select(x => new Hotel
                {
                    HotelID = x.HotelID,
                    HotelName = x.HotelName,
                    HotelCity = x.HotelCity,
                    HotelRating = x.HotelRating,
                    HotelRoomAvailable = x.HotelRoomAvailable,
                });
                return HotelList.ToList();
            }

            else
            {
                return null;
            }

        }

        // GET api/<HotelsController>/5
        // SEARCH HOTEL BY CITY
        [HttpGet("City/{City}")]
        public List<Hotel> GetCity(string City)
        {
            var HotelList = _context.Hotels.Where(x => x.HotelCity == City).Select(x => new Hotel
            {
                HotelID = x.HotelID,
                HotelName = x.HotelName,
                HotelCity = x.HotelCity,
                HotelRating = x.HotelRating,
                HotelRoomAvailable = x.HotelRoomAvailable,
            });
            return HotelList.ToList();
        }

        // GET api/<HotelsController>/5
        // SEARCH HOTEL BY RATING
        [HttpGet("Rating/{Rating}")]
        public List<Hotel> Get(int Rating)
        {
            var HotelList = _context.Hotels.Where(x => x.HotelRating == Rating).Select(x => new Hotel
            {
                HotelID = x.HotelID,
                HotelName = x.HotelName,
                HotelCity = x.HotelCity,
                HotelRating = x.HotelRating,
                HotelRoomAvailable = x.HotelRoomAvailable,
            });
            return HotelList.ToList();
        }

        // SEARCH HOTEL BY NAME
        [HttpGet("Name/{Name}")]
        public List<Hotel> GetName(string Name)
        {
            var HotelList = _context.Hotels.Where(x => x.HotelName.Contains(Name)).Select(x => new Hotel
            {
                HotelID= x.HotelID,
                HotelName = x.HotelName,
                HotelCity = x.HotelCity,
                HotelRating = x.HotelRating,
                HotelRoomAvailable = x.HotelRoomAvailable,
            });
            return HotelList.ToList();
        }

        // PUT api/<HotelsController>/5
        // SUBSTRACT AVAILABLE ROOMS
        /*
        [HttpPut("{ID}")]
        public async Task<ActionResult> PutSubstractAsync(string ID, [FromBody] int number)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Hotels.Any(x => x.HotelID == ID))
            {
                return NotFound("Incorrect HotelID");
            }

            var hotel = _context.Hotels.FirstOrDefault(x => x.HotelID == ID);
            if (hotel != null)
            {
                hotel.HotelRoomAvailable -= number;
            }

            await _context.SaveChangesAsync();
            return Ok(hotel);
        }
        */
        // PUT api/<HotelsController>/5
        // ADD AVAILABLE ROOMS
        [HttpPut("RemoveBooked/{ID}")]
        public async Task<ActionResult> PutAddAsync(string ID, [FromBody] int number)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Hotels.Any(x => x.HotelID == ID))
            {
                return NotFound("Incorrect HotelID");
            }

            var hotel = _context.Hotels.FirstOrDefault(x => x.HotelID == ID);
            if (hotel != null)
            {
                hotel.HotelRoomAvailable += number;
            }

            await _context.SaveChangesAsync();
            return Ok(hotel);
        }
    }
}
