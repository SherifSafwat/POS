using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BayMarch.Data;
using BayMarch.Models;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Services;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        // GET: api/Sellers
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetSeller()
        {
            return Ok(_sellerService.GetAll());
        }

        // GET: api/Sellers/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public IActionResult GetSeller(long id)
        {
            var seller = _sellerService.Get(id);

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
        public IActionResult PutSeller(long id, Seller seller)
        {
            if (id != seller.SellerId)
            {
                return BadRequest();
            }

            if (_sellerService.Update(seller))
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
        public IActionResult PostSeller(Seller seller)
        {
            if (_sellerService.Create(seller))
            {
                return CreatedAtAction("GetSeller", new { id = seller.SellerId }, seller);
            }
            else
            {
                return NotFound();
            }

            
        }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult DeleteSeller(long id)
        {
            if (_sellerService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

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
    }
}
