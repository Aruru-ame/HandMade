using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandMade.Server.Data;
using HandMade.Shared.Models;

namespace HandMade.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksSubmitController : ControllerBase
    {
         private readonly AppDbContext worklist;

        public WorksSubmitController(AppDbContext worklist)
        {
            this.worklist = worklist;
        }

        // GET: api/WorksSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorksSearch>>> GetWorksSearch()
        {
          if (this.worklist.WorksSearch == null)
          {
              return NotFound();
          }
            return await this.worklist.WorksSearch.ToListAsync();
        }

        // GET: api/WorksSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorksSearch>> GetWorksSearch(Guid id)
        {
          if (this.worklist.WorksSearch == null)
          {
              return NotFound();
          }
            var worksSearch = await this.worklist.WorksSearch.FindAsync(id);

            if (worksSearch == null)
            {
                return NotFound();
            }

            return worksSearch;
        }

        // POST: api/WorksSearches
        [HttpPost]
        public async Task<ActionResult<WorksSearch>> PostWorksSearch(WorksSearch worksSearch)
        {
          if (this.worklist.WorksSearch == null)
          {
              return Problem("Entity set 'AppDbContext.WorksSearch'  is null.");
          }
            this.worklist.WorksSearch.Add(worksSearch);
            try
            {
                await this.worklist.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorksSearchExists(worksSearch.WorksId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorksSearch", new { id = worksSearch.WorksId }, worksSearch);
        }

        private bool WorksSearchExists(Guid id)
        {
            return (this.worklist.WorksSearch?.Any(e => e.WorksId == id)).GetValueOrDefault();
        }
}
    }
