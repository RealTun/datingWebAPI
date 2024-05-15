using DatingAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingAPI.Controllers
{
    [Route("api/interest")]
    [ApiController]
    public class InterestTypeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public InterestTypeController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var interests = await _context.InterestType.ToListAsync();
            return Ok(interests);
        }

        // GET api/<RelationshipTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interest = await _context.InterestType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interest == null)
            {
                return NotFound();
            }
            return Ok(interest);
        }
    }
}
