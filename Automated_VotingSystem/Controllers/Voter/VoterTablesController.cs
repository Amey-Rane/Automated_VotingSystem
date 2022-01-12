#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Automated_VotingSystem.Models;

namespace Automated_VotingSystem.Controllers.Voter
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterTablesController : ControllerBase
    {
        private readonly VotingSystemContext _context;

        public VoterTablesController(VotingSystemContext context)
        {
            _context = context;
        }

        //// GET: api/VoterTables
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VoterTable>>> GetVoterTables()
        //{
        //    return await _context.VoterTables.ToListAsync();
        //}

        // GET: api/VoterTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoterTable>> GetVoterTable(int id)
        {
            var voterTable = await _context.VoterTables.FindAsync(id);

            if (voterTable == null)
            {
                return NotFound();
            }

            return voterTable;
        }

        //// PUT: api/VoterTables/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutVoterTable(int id, VoterTable voterTable)
        //{
        //    if (id != voterTable.VoterId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(voterTable).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VoterTableExists(id))
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

        // POST: api/VoterTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VoterTable>> PostVoterTable(VoterTable voterTable)
        {
            _context.VoterTables.Add(voterTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VoterTableExists(voterTable.VoterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVoterTable", new { id = voterTable.VoterId }, voterTable);
        }

        //// DELETE: api/VoterTables/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteVoterTable(int id)
        //{
        //    var voterTable = await _context.VoterTables.FindAsync(id);
        //    if (voterTable == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.VoterTables.Remove(voterTable);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool VoterTableExists(int id)
        {
            return _context.VoterTables.Any(e => e.VoterId == id);
        }
    }
}
