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
    [Route("api/ProjectLogs")]
    public class ProjectLogsController : Controller
    {
        private readonly LogyContext _context;

        public ProjectLogsController(LogyContext context)
        {
            _context = context;
        }

        // GET: api/ProjectLogs
        [HttpGet]
        public IEnumerable<ProjectLog> GetProjectLog()
        {
            return _context.ProjectLog;
        }

        // GET: api/ProjectLogs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectLog = await _context.ProjectLog.SingleOrDefaultAsync(m => m.ProjectLogId == id);

            if (projectLog == null)
            {
                return NotFound();
            }

            return Ok(projectLog);
        }

        // PUT: api/ProjectLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectLog([FromRoute] int id, [FromBody] ProjectLog projectLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectLog.ProjectLogId)
            {
                return BadRequest();
            }

            _context.Entry(projectLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectLogExists(id))
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

        // POST: api/ProjectLogs
        [HttpPost]
        public async Task<IActionResult> PostProjectLog([FromBody] ProjectLog projectLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectLog.Add(projectLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectLog", new { id = projectLog.ProjectLogId }, projectLog);
        }

        // DELETE: api/ProjectLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectLog = await _context.ProjectLog.SingleOrDefaultAsync(m => m.ProjectLogId == id);
            if (projectLog == null)
            {
                return NotFound();
            }

            _context.ProjectLog.Remove(projectLog);
            await _context.SaveChangesAsync();

            return Ok(projectLog);
        }

        private bool ProjectLogExists(int id)
        {
            return _context.ProjectLog.Any(e => e.ProjectLogId == id);
        }
    }
}