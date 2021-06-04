using Microsoft.AspNetCore.Mvc;
using BayMarch.Models;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Dto.Filter;
using BayMarch.Services;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories
        //[HttpGet]
        //[Route("GetAll")]
        //public IActionResult GetAll()
        //{
        //    return Ok(_categoryService.GetAll());
        //}

        // GET: api/categories
        [HttpGet]
        [Route("GetDefault")]
        public IActionResult GetDefault()
        {
            return Ok(_categoryService.GetDefault());
        }

        // GET: api/categories
        [HttpGet]
        [Route("GetPage")]
        public IActionResult GetPage([FromQuery]DefaultFilter defaultFilter)
        {
            return Ok(_categoryService.GetPage(defaultFilter));
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public IActionResult GetCategory(long id)
        {
            var category = _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public IActionResult PutCategory(long id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            if (_categoryService.Update(category))
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public IActionResult PostCategory(Category category)
        {
            if (_categoryService.Create(category))
            {
                return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult DeleteCategory(long id)
        {
            if (_categoryService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}


/*
 
        [HttpGet]
        [Route("Page")]
        public IActionResult PagingSeller(long id, string condition, string orderby)
        {
            return Ok(_sellerService.Page(id, condition, orderby));
        }

        [HttpGet]
        [Route("PagesCount")]
        public IActionResult PagesCountSeller()
        {
            return Ok(_sellerService.PagesCount());
        }

*/

/*
private readonly DataContext _context;

public CategoriesController(DataContext context)
{
    _context = context;
}

// GET: api/Categories
[HttpGet]
public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
{
    return await _context.Category.ToListAsync();
}

// GET: api/Categories/5
[HttpGet("{id}")]
public async Task<ActionResult<Category>> GetCategory(long id)
{
    var category = await _context.Category.FindAsync(id);

    if (category == null)
    {
        return NotFound();
    }

    return category;
}

// PUT: api/Categories/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPut("{id}")]
public async Task<IActionResult> PutCategory(long id, Category category)
{
    if (id != category.CategoryId)
    {
        return BadRequest();
    }

    _context.Entry(category).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!CategoryExists(id))
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

// POST: api/Categories
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPost]
public async Task<ActionResult<Category>> PostCategory(Category category)
{
    _context.Category.Add(category);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
}

// DELETE: api/Categories/5
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteCategory(long id)
{
    var category = await _context.Category.FindAsync(id);
    if (category == null)
    {
        return NotFound();
    }

    _context.Category.Remove(category);
    await _context.SaveChangesAsync();

    return NoContent();
}

private bool CategoryExists(long id)
{
    return _context.Category.Any(e => e.CategoryId == id);
}*/
