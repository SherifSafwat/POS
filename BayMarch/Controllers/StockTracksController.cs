using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BayMarch.Data;
using BayMarch.Models;

namespace BayMarch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTracksController : ControllerBase
    {
        private readonly DataContext _context;

        public StockTracksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/StockTracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTrack>>> GetStockTrack()
        {
            return await _context.StockTrack.ToListAsync();
        }

        // GET: api/StockTracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockTrack>> GetStockTrack(long id)
        {
            var stockTrack = await _context.StockTrack.FindAsync(id);

            if (stockTrack == null)
            {
                return NotFound();
            }

            return stockTrack;
        }

        // PUT: api/StockTracks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockTrack(long id, StockTrack stockTrack)
        {
            if (id != stockTrack.StockTrackId)
            {
                return BadRequest();
            }

            _context.Entry(stockTrack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockTrackExists(id))
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

        // POST: api/StockTracks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockTrack>> PostStockTrack(StockTrack stockTrack)
        {
            _context.StockTrack.Add(stockTrack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockTrack", new { id = stockTrack.StockTrackId }, stockTrack);
        }

        // DELETE: api/StockTracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockTrack(long id)
        {
            var stockTrack = await _context.StockTrack.FindAsync(id);
            if (stockTrack == null)
            {
                return NotFound();
            }

            _context.StockTrack.Remove(stockTrack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockTrackExists(long id)
        {
            return _context.StockTrack.Any(e => e.StockTrackId == id);
        }
    }
}
