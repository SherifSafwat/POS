using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using BayMarch.Models;
using BayMarch.Data;
using System.Threading.Tasks;
using BayMarch.Dto.Filter;

namespace BayMarch.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IBaseInterface<Models.Type> _typeService;

        public TypesController(IBaseInterface<Models.Type> typeService)
        {
            _typeService = typeService;
        }

        // GET: api/Types
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAll(DefaultFilter df)
        {
            return Ok(await _typeService.GetAll(df));
        }

        // GET: api/Types
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<IEnumerable<Type>>> GetList()
        {
            return Ok(await _typeService.GetList(null));
        }

        // GET: api/Types/5
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<ActionResult<Type>> Get(long id)
        {
            var data = await _typeService.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

    }
}
