using Microsoft.AspNetCore.Mvc;
using BayMarch.Dto;
using Microsoft.AspNetCore.Authorization;
using BayMarch.Services;
using BayMarch.Dto.Filter;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productSevice; 

        public ProductsController(IProductService productSevice)
        {
            _productSevice = productSevice;
        }

        [HttpGet]
        [Route("GetAll")]
        //[HttpGet(ApiRoutes.PropductRoutes.GetAll)]
        public IActionResult GetProduct()
        {
            //string userId = User.FindFirst(ClaimTypes.Name)?.Value;
            //return Ok(new { user = userId , data = _productSevice.GetAll() });
            return Ok(_productSevice.GetAll());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetProduct(long id)
        {
            var product = _productSevice.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        [Route("Find")]
        public IActionResult FindProduct(ProductFilter productFilter)
        {
            var product = _productSevice.Find(productFilter);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult PutProduct(long id, ProductDto product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            if( _productSevice.Update(product))
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("Create")]
        public IActionResult PostProduct(ProductDto productDto)
        {

            if (_productSevice.Create(productDto))
            {
                return CreatedAtAction("GetProduct", new { id = productDto.ProductId }, productDto);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult DeleteProduct(long id)
        {

            if (_productSevice.Delete(id))
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
        public IActionResult PagingProduct(long id, string orderby)
        {
            return Ok(_productSevice.Page(id, orderby));
        }

        [HttpGet]
        [Route("Pages")]
        public IActionResult PagesProduct()
        {
            return Ok(_productSevice.PagesCount());
        }
            
    }
}
