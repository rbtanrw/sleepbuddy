using BookHotel.Data;
using BookHotel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelManagersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HotelManagersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<HotelManagerController>
        // LOGIN
        [HttpGet("Login/{ID}, {Password}")]
        public ActionResult<HotelManager> Get(string ID, string Password)
        {
            var admin = _context.HotelManagers.FirstOrDefault(x => x.AdminID == ID);
            if (admin == null)
            {
                return NotFound("Admin ID is not valid");
            }

            if (admin.AdminPassword != Password)
            {
                return BadRequest("Incorrect password");
            }

            return Ok(admin);
        }

        // GET api/<HotelManagerController>/5
        // GET BY ID
        [HttpGet("GetAdmin/{AdminID}")]
        public ActionResult<HotelManager> Get(string ID)
        {
            var admin = _context.HotelManagers.FirstOrDefault(x => x.AdminID == ID);
            if (admin == null)
            {
                return NotFound("Admin ID not found");
            }

            return Ok(admin);
        }
    }
}