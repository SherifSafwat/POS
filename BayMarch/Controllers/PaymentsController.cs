using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Dto.Filter;
using System.Threading.Tasks;
using System.Collections.Generic;
using BayMarch.Models;
using BayMarch.Data;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        private readonly IBaseInterface<Payment> _parentCategoryService;

        public PaymentsController(IBaseInterface<Payment> parentCategoryService)
        {
            _parentCategoryService = parentCategoryService;
        }

        // GET: api/Payments
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAll(string _Orderby, bool _IsDesc)
        {
            return Ok(await _parentCategoryService.GetAll(new DefaultFilter { Orderby = _Orderby, IsDesc = _IsDesc }));
        }

        // GET: api/Payments
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetList()
        {
            return Ok(await _parentCategoryService.GetList(null));
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Payment>> Get(long id)
        {
            var parentCategory = await _parentCategoryService.Get(id);

            if (parentCategory == null)
            {
                return NotFound();
            }

            return Ok(parentCategory);
        }


        /*
        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult<Payment>> Put(long id, Payment parentCategory)
        {
            if (id != parentCategory.PaymentId)
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Payment>> Post(Payment parentCategory)
        {
            if (await _parentCategoryService.Create(parentCategory))
            {
                return CreatedAtAction("Get", new { id = parentCategory.PaymentId }, parentCategory);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Payment>>> Page(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.Page(df));
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Payment>>> Search(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.Search(df));
        }*/

    }
}
