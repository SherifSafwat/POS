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
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/InvoiceDtos/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public IActionResult GetInvoice(long id)
        {
            var invoiceDto = _invoiceService.Get(id);

            if (invoiceDto == null)
            {
                return NotFound();
            }

            return Ok(invoiceDto);
        }

        // POST: api/InvoiceDtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public IActionResult PostInvoice(InvoiceDto invoiceDto)
        {
            if (_invoiceService.Create(invoiceDto))
            {
                return CreatedAtAction("GetInvoice", new { id = invoiceDto.InvoiceHead.OrderHeadId }, invoiceDto);
            }
            else
            {
                return NotFound();
            }


        }

        /*
        // GET: api/InvoiceDtos
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetInvoiceDto()
        {
            return Ok(_invoiceService.GetAll());
        }



        // PUT: api/InvoiceDtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public IActionResult PutInvoiceDto(long id, InvoiceDto InvoiceDto)
        {
            if (id != InvoiceDto.InvoiceDtoId)
            {
                return BadRequest();
            }

            if (_invoiceService.Update(InvoiceDto))
            {
                return Ok(InvoiceDto);
            }
            else
            {
                return NotFound();
            }

        }


        // DELETE: api/InvoiceDtos/5
        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult DeleteInvoiceDto(long id)
        {
            if (_invoiceService.Delete(id))
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
        public IActionResult PagingInvoiceDto(long id, string orderby)
        {
            return Ok(_invoiceService.Page(id, orderby));
        }

        [HttpGet]
        [Route("PagesCount")]
        public IActionResult PagesCountInvoiceDto()
        {
            return Ok(_invoiceService.PagesCount());
        }
        */
    }
}
