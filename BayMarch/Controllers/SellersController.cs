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
    public class SellersController : ControllerBase
    {
        private readonly IBaseInterface<Seller> _sellerService;

        public SellersController(IBaseInterface<Seller> sellerService)
        {
            _sellerService = sellerService;
        }

        // GET: api/Sellers
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetAll(string _Orderby, bool _IsDesc)
        {
            return Ok(await _sellerService.GetAll(new DefaultFilter { Orderby = _Orderby, IsDesc = _IsDesc }));
        }

        // GET: api/Sellers
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetList()
        {
            return Ok(await _sellerService.GetList(null));
        }

        // GET: api/Sellers/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Seller>> Get(long id)
        {
            var seller = await _sellerService.Get(id);

            if (seller == null)
            {
                return NotFound();
            }

            return Ok(seller);
        }

        // PUT: api/Sellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult<Seller>> Put(long id, Seller seller)
        {
            if (id != seller.SellerId)
            {
                return BadRequest();
            }

            if (await _sellerService.Update(seller))
            {
                return Ok(seller);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/Sellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Seller>> Post(Seller seller)
        {
            if (await _sellerService.Create(seller))
            {
                return CreatedAtAction("Get", new { id = seller.SellerId }, seller);
            }
            else
            {
                return NotFound();
            }            
        }

        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult<IEnumerable<Seller>>> Page(long _PageNumber, string _Orderby, bool _IsDesc)
        {
            return Ok(await _sellerService.Page(new DefaultFilter { PageNumber = _PageNumber, Orderby = _Orderby, IsDesc = _IsDesc }));
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<Seller>>> Search(string _Filter, string _Orderby, bool _IsDesc)
        {
            return Ok(await _sellerService.Search(new DefaultFilter { Filter = _Filter, Orderby = _Orderby, IsDesc = _IsDesc }));
        }
                
    }
}
