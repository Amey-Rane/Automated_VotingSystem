using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Automated_VotingSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Automated_VotingSystem.Controllers.Voter
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayCandidatesController : ControllerBase
    {
        private readonly VotingSystemContext _context;
        public DisplayCandidatesController(VotingSystemContext context)
        {
            _context = context;
        }
        // GET: api/<DisplayCandidatesController>

        public Task<DisplayCandidates> DisplayCandidateslist { get; set; }
        [HttpGet]

        public async Task<List<DisplayCandidates>> DisplayAllCandidates()
        {
            return await (from c in _context.CandidateTables
                          join ac in _context.ApprovedCandidateTables on c.CandidateId equals ac.CandidateId
                          join s in _context.SymbolTables on c.SymbolId equals s.SymbolId
                          where ac.Approval == true
                          select new DisplayCandidates
                          {
                              CandidateId = ac.CandidateId,
                              Manifesto = c.Manifesto,
                              Symbol_path = s.Symbol_path
                          }).ToListAsync();
        }

        //// GET api/<DisplayCandidatesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<DisplayCandidatesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<DisplayCandidatesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DisplayCandidatesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
