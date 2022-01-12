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
    public class SymbolTablesController : ControllerBase
    {
        private readonly VotingSystemContext _context;

        public SymbolTablesController(VotingSystemContext context)
        {
            _context = context;
        }

        // GET: api/SymbolTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SymbolTable>>> GetSymbolTables()
        {
            return await _context.SymbolTables.ToListAsync();
        }

        // GET: api/SymbolTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SymbolTable>> GetSymbolTable(int id)
        {
            var symbolTable = await _context.SymbolTables.FindAsync(id);

            if (symbolTable == null)
            {
                return NotFound();
            }

            return symbolTable;
        }

        //// PUT: api/SymbolTables/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSymbolTable(int id, SymbolTable symbolTable)
        //{
        //    if (id != symbolTable.SymbolId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(symbolTable).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SymbolTableExists(id))
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

        //// POST: api/SymbolTables
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<SymbolTable>> PostSymbolTable(SymbolTable symbolTable)
        //{
        //    _context.SymbolTables.Add(symbolTable);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (SymbolTableExists(symbolTable.SymbolId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetSymbolTable", new { id = symbolTable.SymbolId }, symbolTable);
        //}

        //// DELETE: api/SymbolTables/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSymbolTable(int id)
        //{
        //    var symbolTable = await _context.SymbolTables.FindAsync(id);
        //    if (symbolTable == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SymbolTables.Remove(symbolTable);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool SymbolTableExists(int id)
        {
            return _context.SymbolTables.Any(e => e.SymbolId == id);
        }
    }
}
