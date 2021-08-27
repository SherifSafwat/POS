using Microsoft.AspNetCore.Mvc;
using BayMarch.Models;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Dto.Filter;
using BayMarch.Services;
using BayMarch.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IBaseInterface<Category> _categoryService;

        public CategoriesController(IBaseInterface<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll(DefaultFilter df)
        {
            return Ok(await _categoryService.GetAll(df));
        }

        // GET: api/Categories
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<IEnumerable<Category>>> GetList(DefaultFilter df)
        {
            return Ok(await _categoryService.GetList(df));
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Category>> Get(long id)
        {
            var category = await _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        /*
        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult<Category>> Put(long id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            if (await _categoryService.Update(category))
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            if (await _categoryService.Create(category))
            {
                return CreatedAtAction("Get", new { id = category.CategoryId }, category);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Category>>> Page(DefaultFilter df)
        {
            return Ok(await _categoryService.Page(df));
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Category>>> Search(DefaultFilter df)
        {
            return Ok(await _categoryService.Search(df));
        }*/

    }
}


/*private readonly ICategoryService _categoryService;

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
}*/
