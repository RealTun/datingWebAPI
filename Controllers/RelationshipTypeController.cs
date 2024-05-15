using DatingAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingAPI.Controllers
{
    [Route("api/relationship")]
    [ApiController]
    public class RelationshipTypeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RelationshipTypeController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var realationships = await _context.RelationshipType.ToListAsync();
            return Ok(realationships);
        }

        // GET api/<RelationshipTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelationship(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relationship = await _context.RelationshipType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relationship == null)
            {
                return NotFound();
            }
            return Ok(relationship);
        }
    }
}
