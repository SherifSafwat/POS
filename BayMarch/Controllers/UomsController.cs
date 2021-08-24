using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Services;
using Microsoft.Extensions.Logging;
using BayMarch.Data;
using BayMarch.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using BayMarch.Dto.Filter;

namespace BayMarch.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UomsController : ControllerBase
    {

        private readonly IBaseInterface<Uom> _uomService;

        public UomsController(IBaseInterface<Uom> uomService)
        {
            _uomService = uomService;
        }

        // GET: api/Uoms
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Uom>>> GetAll(DefaultFilter df)
        {
            return Ok(await _uomService.GetAll(df));
        }

        // GET: api/Uoms
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetList()
        {
            return Ok(await _uomService.GetList(null));
        }

        // GET: api/Uoms/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Uom>> Get(long id)
        {
            var uom = await _uomService.Get(id);

            if (uom == null)
            {
                return NotFound();
            }

            return Ok(uom);
        }

        // PUT: api/Uoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult<Uom>> Put(long id, Uom uom)
        {
            if (id != uom.UomId)
            {
                return BadRequest();
            }

            if (await _uomService.Update(uom))
            {
                return Ok(uom);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/Uoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Uom>> Post(Uom uom)
        {
            if (await _uomService.Create(uom))
            {
                return CreatedAtAction("Get", new { id = uom.UomId }, uom);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Uom>>> Page(DefaultFilter df)
        {
            return Ok(await _uomService.Page(df));
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Uom>>> Search(DefaultFilter df)
        {
            return Ok(await _uomService.Search(df));
        }

    }
}

/*private readonly ILogger _logger;
private readonly IUomService _uomService;

public UomsController(ILogger<UomsController> logger, IUomService categoryService)
{
    _logger = logger;
    _uomService = categoryService;
}

// GET: api/uoms
[HttpGet]
[Route("GetDefault")]
public IActionResult GetDefault()
{
    _logger.LogInformation("Log message in the Index() method");
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
