using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Services;

namespace BayMarch.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UomsController : ControllerBase
    {

        private readonly IUomService _uomService;

        public UomsController(IUomService categoryService)
        {
            _uomService = categoryService;
        }

        // GET: api/uoms
        [HttpGet]
        [Route("GetDefault")]
        public IActionResult GetDefault()
        {
            return Ok(_uomService.GetDefault());
        }

    }
}

/*
        private readonly DataContext _context;

        public UomsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Uoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uom>>> GetUom()
        {
            return await _context.Uom.ToListAsync();
        }

        // GET: api/Uoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uom>> GetUom(long id)
        {
            var uom = await _context.Uom.FindAsync(id);

            if (uom == null)
            {
                return NotFound();
            }

            return uom;
        }

        // PUT: api/Uoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUom(long id, Uom uom)
        {
            if (id != uom.UomId)
            {
                return BadRequest();
            }

            _context.Entry(uom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Uoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uom>> PostUom(Uom uom)
        {
            _context.Uom.Add(uom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUom", new { id = uom.UomId }, uom);
        }

        // DELETE: api/Uoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUom(long id)
        {
            var uom = await _context.Uom.FindAsync(id);
            if (uom == null)
            {
                return NotFound();
            }

            _context.Uom.Remove(uom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UomExists(long id)
        {
            return _context.Uom.Any(e => e.UomId == id);
        }
    }
}
*/
