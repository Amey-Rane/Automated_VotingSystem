﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Automated_VotingSystem.Models;

namespace Automated_VotingSystem.Controllers.Admin
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventTablesController : ControllerBase
    {
        private readonly VotingSystemContext _context;

        public EventTablesController(VotingSystemContext context)
        {
            _context = context;
        }

        //// GET: api/EventTables
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EventTable>>> GetEventTables()
        //{
        //    return await _context.EventTables.ToListAsync();
        //}

        // GET: api/EventTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTable>> GetEventTable(int id)
        {
            var eventTable = await _context.EventTables.FindAsync(id);

            if (eventTable == null)
            {
                return NotFound();
            }

            return eventTable;
        }

        //// PUT: api/EventTables/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEventTable(int id, EventTable eventTable)
        //{
        //    if (id != eventTable.EventId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(eventTable).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EventTableExists(id))
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

        // POST: api/EventTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventTable>> PostEventTable(EventTable eventTable)
        {
            _context.EventTables.Add(eventTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventTable", new { id = eventTable.EventId }, eventTable);
        }

        // DELETE: api/EventTables/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEventTable(int id)
        //{
        //    var eventTable = await _context.EventTables.FindAsync(id);
        //    if (eventTable == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.EventTables.Remove(eventTable);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool EventTableExists(int id)
        {
            return _context.EventTables.Any(e => e.EventId == id);
        }
    }
}
