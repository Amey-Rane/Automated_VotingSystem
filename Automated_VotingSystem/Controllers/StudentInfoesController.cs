#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Automated_VotingSystem.Models;

namespace Automated_VotingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoesController : ControllerBase
    {
        private readonly VotingSystemContext _context;

        public StudentInfoesController(VotingSystemContext context)
        {
            _context = context;
        }

        //// GET: api/StudentInfoes
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StudentInfo>>> GetStudentInfos()
        //{
        //    return await _context.StudentInfos.ToListAsync();
        //}

        // GET: api/StudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfo(int id)
        {
            var studentInfo = await _context.StudentInfos.FindAsync(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return studentInfo;
        }

        //// PUT: api/StudentInfoes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStudentInfo(int id, StudentInfo studentInfo)
        //{
        //    if (id != studentInfo.CollegeId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(studentInfo).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentInfoExists(id))
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

        //// POST: api/StudentInfoes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<StudentInfo>> PostStudentInfo(StudentInfo studentInfo)
        //{
        //    _context.StudentInfos.Add(studentInfo);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (StudentInfoExists(studentInfo.CollegeId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetStudentInfo", new { id = studentInfo.CollegeId }, studentInfo);
        //}

        //// DELETE: api/StudentInfoes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStudentInfo(int id)
        //{
        //    var studentInfo = await _context.StudentInfos.FindAsync(id);
        //    if (studentInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.StudentInfos.Remove(studentInfo);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool StudentInfoExists(int id)
        {
            return _context.StudentInfos.Any(e => e.CollegeId == id);
        }
    }
}
