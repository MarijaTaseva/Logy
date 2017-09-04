using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Logy.Models;

namespace Logy.Controllers
{
    [Produces("application/json")]
    [Route("api/TimeLogs")]
    public class TimeLogsController : Controller
    {
        private readonly LogyContext _context;

        public TimeLogsController(LogyContext context)
        {
            _context = context;
        }

        // GET: api/TimeLogs
        [HttpGet]
        public IEnumerable<TimeLog> GetTimeLog()
        {
            return _context.TimeLog;
        }

        // GET: api/TimeLogs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimeLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeLog = await _context.TimeLog.SingleOrDefaultAsync(m => m.TimeLogId == id);

            if (timeLog == null)
            {
                return NotFound();
            }

            return Ok(timeLog);
        }

        // PUT: api/TimeLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeLog([FromRoute] int id, [FromBody] TimeLog timeLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeLog.TimeLogId)
            {
                return BadRequest();
            }

            _context.Entry(timeLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeLogExists(id))
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

        // POST: api/TimeLogs
        [HttpPost]
        public async Task<IActionResult> PostTimeLog([FromBody] TimeLog timeLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TimeLog.Add(timeLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeLog", new { id = timeLog.TimeLogId }, timeLog);
        }

        // DELETE: api/TimeLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeLog = await _context.TimeLog.SingleOrDefaultAsync(m => m.TimeLogId == id);
            if (timeLog == null)
            {
                return NotFound();
            }

            _context.TimeLog.Remove(timeLog);
            await _context.SaveChangesAsync();

            return Ok(timeLog);
        }

        private bool TimeLogExists(int id)
        {
            return _context.TimeLog.Any(e => e.TimeLogId == id);
        }
    }
}