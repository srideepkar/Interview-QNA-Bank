using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InterviewFAQ.Data;
using InterviewFAQ.Model;

namespace InterviewFAQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QNAsController : ControllerBase
    {
        private readonly InterviewFAQContext _context;

        public QNAsController(InterviewFAQContext context)
        {
            _context = context;
        }

        // GET: api/QNAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QNA>>> GetQNA()
        {
          if (_context.QNA == null)
          {
              return NotFound();
          }
            return await _context.QNA.ToListAsync();
        }

        // GET: api/QNAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QNA>> GetQNA(int id)
        {
          if (_context.QNA == null)
          {
              return NotFound();
          }
            var qNA = await _context.QNA.FindAsync(id);

            if (qNA == null)
            {
                return NotFound();
            }

            return qNA;
        }

        // PUT: api/QNAs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQNA(int id, QNA qNA)
        {
            if (id != qNA.id)
            {
                return BadRequest();
            }

            _context.Entry(qNA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QNAExists(id))
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

        // POST: api/QNAs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QNA>> PostQNA(QNA qNA)
        {
          if (_context.QNA == null)
          {
              return Problem("Entity set 'InterviewFAQContext.QNA'  is null.");
          }
            _context.QNA.Add(qNA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQNA", new { id = qNA.id }, qNA);
        }

        // DELETE: api/QNAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQNA(int id)
        {
            if (_context.QNA == null)
            {
                return NotFound();
            }
            var qNA = await _context.QNA.FindAsync(id);
            if (qNA == null)
            {
                return NotFound();
            }

            _context.QNA.Remove(qNA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QNAExists(int id)
        {
            return (_context.QNA?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
