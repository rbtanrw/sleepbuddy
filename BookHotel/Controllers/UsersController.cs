using BookHotel.Data;
using BookHotel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<UsersController>
        // LOGIN
        [HttpGet("Login/{Email}/{Password}")]
        public ActionResult<Users> Get(string Email, string Password)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserEmail == Email);
            if (user == null)
            {
                return NotFound("Email not registered");
            }

            if (user.UserPassword != Password)
            {
                return BadRequest("Incorrect password");
            }

            return Ok(user);
        }

        // GET api/<UsersController>/5
        // GET BY ID
        [HttpGet("GetUser/{UserID}")]
        public ActionResult<Users> Get(string UserID)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserID == UserID);
            if (user == null)
            {
                return NotFound("User ID not found");
            }

            return Ok(user);
        }

        // POST api/<UsersController>
        // REGISTER
        [HttpPost("Register/{Name}/{Email}/{Password}")]
        public async Task<ActionResult> PostAsync(string Name, string Email, string Password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Users.Any(x => x.UserEmail == Email))
            {
                return BadRequest("Email has been used");
            }

            var i = 0;
            foreach (Users users in _context.Users)
            {
                i++;
            }

            var user = new Users
            {
                UserID = string.Concat("U", i.ToString("D3")),
                UserName = Name,
                UserEmail = Email,
                UserPassword = Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // PUT api/<UsersController>/5
        // CHANGE USERNAME
        [HttpPut("ChangeName/{ID}")]
        public async Task<ActionResult> PutAsync(string ID, [FromBody] string NewUserName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Users.Any(x => x.UserID == ID))
            {
                return NotFound("Incorrect UserID");
            }

            var user = _context.Users.FirstOrDefault(x => x.UserID == ID);
            if (user != null)
            {
                user.UserName = NewUserName;
            }

            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}
