using Microsoft.AspNetCore.Mvc;
using BayMarch.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using BayMarch.Dto.Filter;
using BayMarch.Data;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ParentCategoriesController : ControllerBase
    {
        private readonly IBaseInterface<ParentCategory> _parentCategoryService;

        public ParentCategoriesController(IBaseInterface<ParentCategory> parentCategoryService)
        {
            _parentCategoryService = parentCategoryService;
        }

        // GET: api/ParentCategories
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ParentCategory>>> GetAll(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.GetAll(df));
        }

        // GET: api/ParentCategories
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetList()
        {
            return Ok(await _parentCategoryService.GetList(null));
        }

        // GET: api/ParentCategories/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<ActionResult<ParentCategory>> Get(long id)
        {
            var parentCategory = await _parentCategoryService.Get(id);

            if (parentCategory == null)
            {
                return NotFound();
            }

            return Ok(parentCategory);
        }


        /*
        // PUT: api/ParentCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult<ParentCategory>> Put(long id, ParentCategory parentCategory)
        {
            if (id != parentCategory.ParentCategoryId)
            {
                return BadRequest();
            }

            if (await _parentCategoryService.Update(parentCategory))
            {
                return Ok(parentCategory);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/ParentCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ParentCategory>> Post(ParentCategory parentCategory)
        {
            if (await _parentCategoryService.Create(parentCategory))
            {
                return CreatedAtAction("Get", new { id = parentCategory.ParentCategoryId }, parentCategory);
            }
            else
            {
                return NotFound();
            }            
        }

        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<ParentCategory>>> Page(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.Page(df));
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<ParentCategory>>> Search(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.Search(df));
        }*/
                
    }
}
