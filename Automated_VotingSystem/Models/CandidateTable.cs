using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class CandidateTable
    {
        public int CandidateId { get; set; }
        public int? CollegeId { get; set; }
        public string? Manifesto { get; set; }
        public int? EventId { get; set; }
        public int? SymbolId { get; set; }

        public virtual StudentInfo? College { get; set; }
        public virtual EventTable? Event { get; set; }
        public virtual SymbolTable? Symbol { get; set; }
    }
}
