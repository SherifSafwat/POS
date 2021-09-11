using Microsoft.AspNetCore.Mvc;
using BayMarch.Models;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Dto.Filter;
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
        private readonly IBaseInterface<Customer> _categoryService;

        public CustomersController(IBaseInterface<Customer> categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Customer
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll(string _Orderby, bool _IsDesc)
        {
            return Ok(await _categoryService.GetAll(new DefaultFilter { Orderby = _Orderby, IsDesc = _IsDesc }));
        }

        // GET: api/Customer
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetList()
        {
            return Ok(await _categoryService.GetList(null));
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Customer>> Get(long id)
        {
            var category = await _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult<Customer>> Put(long id, Customer category)
        {
            if (id != category.CustomerId)
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

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Customer>> Post(Customer category)
        {
            if (await _categoryService.Create(category))
            {
                return CreatedAtAction("Get", new { id = category.CustomerId }, category);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Customer>>> Page(long _PageNumber, string _Orderby, bool _IsDesc)
        {
            return Ok(await _categoryService.Page(new DefaultFilter { PageNumber = _PageNumber, Orderby = _Orderby, IsDesc = _IsDesc }));
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Customer>>> Search(string _Filter, string _Orderby, bool _IsDesc)
        {
            return Ok(await _categoryService.Search(new DefaultFilter { Filter = _Filter, Orderby = _Orderby, IsDesc = _IsDesc }));
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