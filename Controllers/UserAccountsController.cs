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
            //return View(await _context.UserAccount.ToListAsync());
            var users = await _context.UserAccount.ToListAsync();
            return Ok(users);
        }

        // GET: UserAccounts/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
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
                Name = userAccount.Name,
                Email = userAccount.Email,
                Phone = userAccount.Phone,
                Bio = userAccount.Bio,
                Age = userAccount.Age,
                Gender = userAccount.Gender == 0 ? "Nam" : "Nữ",
                Location = userAccount.Location,
            };

            return Ok(response);
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Phone,Password,Name,Bio,Age,Gender,Looking_For,Location,Confirmation_Code,Confirmation_Time")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest(ModelState);
        }

        // GET: UserAccounts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userAccount = await _context.UserAccount.FindAsync(id);
        //    if (userAccount == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userAccount);
        //}

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Phone,Password,Name,Bio,Age,Gender,Looking_For,Location,Confirmation_Code,Confirmation_Time")] UserAccount userAccount)
        //{
        //    if (id != userAccount.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(userAccount);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserAccountExists(userAccount.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userAccount);
        //}

        // GET: UserAccounts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userAccount = await _context.UserAccount
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (userAccount == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userAccount);
        //}

        // POST: UserAccounts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var userAccount = await _context.UserAccount.FindAsync(id);
        //    if (userAccount != null)
        //    {
        //        _context.UserAccount.Remove(userAccount);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

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
    }
}
