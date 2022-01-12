#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Automated_VotingSystem.Models;

namespace Automated_VotingSystem.Controllers.Candidate
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateTablesController : ControllerBase
    {
        private readonly VotingSystemContext _context;

        public CandidateTablesController(VotingSystemContext context)
        {
            _context = context;
        }

        // GET: api/CandidateTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateTable>>> GetCandidateTables()
        {
            return await _context.CandidateTables.ToListAsync();
        }

        // GET: api/CandidateTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateTable>> GetCandidateTable(int id)
        {
            var candidateTable = await _context.CandidateTables.FindAsync(id);
            

            if (candidateTable == null)
            {
                return NotFound();
            }

            return candidateTable;
        }

        //// PUT: api/CandidateTables/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCandidateTable(int id, CandidateTable candidateTable)
        //{
        //    if (id != candidateTable.CandidateId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(candidateTable).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CandidateTableExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/CandidateTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CandidateTable>> PostCandidateTable(CandidateTable candidateTable)
        {
            _context.CandidateTables.Add(candidateTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CandidateTableExists(candidateTable.CandidateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCandidateTable", new { id = candidateTable.CandidateId }, candidateTable);
        }

        //// DELETE: api/CandidateTables/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCandidateTable(int id)
        //{
        //    var candidateTable = await _context.CandidateTables.FindAsync(id);
        //    if (candidateTable == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CandidateTables.Remove(candidateTable);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CandidateTableExists(int id)
        {
            return _context.CandidateTables.Any(e => e.CandidateId == id);
        }
    }
}
