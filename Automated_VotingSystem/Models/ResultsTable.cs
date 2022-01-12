using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class ResultsTable
    {
        public int? EventId { get; set; }
        public int? CandidateId { get; set; }
        public int? VoteCount { get; set; }

        public virtual CandidateTable? Candidate { get; set; }
        public virtual EventTable? Event { get; set; }
    }
}
