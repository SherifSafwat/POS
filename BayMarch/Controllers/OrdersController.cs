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
using BayMarch.Dto;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orderDtos/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public IActionResult Getorder(long id)
        {
            var orderDto = _orderService.Get(id);

            if (orderDto == null)
            {
                return NotFound();
            }

            return Ok(orderDto);
        }

        // POST: api/orderDtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public IActionResult Postorder(OrderDto orderDto)
        {
            if (_orderService.Create(orderDto))
            {
                return CreatedAtAction("Getorder", new { id = orderDto.OrderHead.OrderHeadId }, orderDto);
            }
            else
            {
                return NotFound();
            }
        }

        /*
        // GET: api/orderDtos
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetorderDto()
        {
            return Ok(_orderService.GetAll());
        }



        // PUT: api/orderDtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public IActionResult PutorderDto(long id, orderDto orderDto)
        {
            if (id != orderDto.orderDtoId)
            {
                return BadRequest();
            }

            if (_orderService.Update(orderDto))
            {
                return Ok(orderDto);
            }
            else
            {
                return NotFound();
            }

        }


        // DELETE: api/orderDtos/5
        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult DeleteorderDto(long id)
        {
            if (_orderService.Delete(id))
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
        public IActionResult PagingorderDto(long id, string orderby)
        {
            return Ok(_orderService.Page(id, orderby));
        }

        [HttpGet]
        [Route("PagesCount")]
        public IActionResult PagesCountorderDto()
        {
            return Ok(_orderService.PagesCount());
        }
        */
    }
}
