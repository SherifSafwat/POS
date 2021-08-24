using Microsoft.AspNetCore.Mvc;
using BayMarch.Models;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Dto.Filter;
using BayMarch.Services;
using BayMarch.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IBaseInterface<Customer> _parentCategoryService;

        public CustomersController(IBaseInterface<Customer> parentCategoryService)
        {
            _parentCategoryService = parentCategoryService;
        }

        // GET: api/Customer
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.GetAll(df));
        }

        // GET: api/Customer
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetList(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.GetList(df));
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Customer>> Get(long id)
        {
            var parentCategory = await _parentCategoryService.Get(id);

            if (parentCategory == null)
            {
                return NotFound();
            }

            return Ok(parentCategory);
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult<Customer>> Put(long id, Customer parentCategory)
        {
            if (id != parentCategory.CustomerId)
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

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Customer>> Post(Customer parentCategory)
        {
            if (await _parentCategoryService.Create(parentCategory))
            {
                return CreatedAtAction("Get", new { id = parentCategory.CustomerId }, parentCategory);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Customer>>> Page(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.Page(df));
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Customer>>> Search(DefaultFilter df)
        {
            return Ok(await _parentCategoryService.Search(df));
        }

    }
}


/*
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(long id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
    }
}

*/