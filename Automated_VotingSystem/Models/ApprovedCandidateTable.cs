using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class ApprovedCandidateTable
    {
        public int? CandidateId { get; set; }
        public bool? Approval { get; set; }

        public virtual CandidateTable? Candidate { get; set; }
    }
}
