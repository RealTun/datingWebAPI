using DatingAPI.DB;
using DatingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserAccountsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserAccountsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _context.UserAccount.ToListAsync();
            return Ok(users);
        }

        // GET: UserAccounts/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAccount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }
            var response = new
            {
                userAccount.Name,
                userAccount.Email,
                userAccount.Phone,
                userAccount.Bio,
                userAccount.Age,
                Gender = userAccount.Gender == 0 ? "Nam" : "Nữ",
                userAccount.Location,
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAccount([FromBody] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                var isEmailDuplicate = _context.UserAccount.Any(u => u.Email == userAccount.Email);
                if (isEmailDuplicate)
                {
                    return BadRequest("Email address already exists.");
                }

                // Check for duplicate phone number
                var isPhoneDuplicate = _context.UserAccount.Any(u => u.Phone == userAccount.Phone);
                if (isPhoneDuplicate)
                {
                    return BadRequest("Phone number already exists.");
                }

                userAccount.Password = HashPassword(userAccount.Password);

                _context.Add(userAccount);
                await _context.SaveChangesAsync();

                // Return a success response with relevant information (optional)
                return CreatedAtAction("GetUserAccount", new { id = userAccount.Id }, userAccount);
            }
            return BadRequest(ModelState); // Return bad request with validation errors
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAccount(int id, [FromBody] UserAccount userAccount)
        {
            if (id != userAccount.Id)
            {
                return BadRequest("User ID in request body and path don't match.");
            }

            if (ModelState.IsValid)
            {
                _context.Update(userAccount);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(new
                {
                    User = userAccount,
                    Message = "Updated information user successfully."
                });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccount = await _context.UserAccount.FindAsync(id);
            if (userAccount != null)
            {
                _context.UserAccount.Remove(userAccount);
            }

            await _context.SaveChangesAsync();
            return Ok("Deleted user successfully.");
        }

        private bool UserAccountExists(int id)
        {
            return _context.UserAccount.Any(e => e.Id == id);
        }

        [HttpGet("check/{phone}")]
        public IActionResult UserAccountExists(string? phone)
        {
            var isExisted = _context.UserAccount.Any(e => e.Phone == phone);
            var response = new
            {
                Exists = isExisted,
                Message = isExisted ? "Phone number already exists." : "Phone number not found."
            };
            return Ok(response);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
