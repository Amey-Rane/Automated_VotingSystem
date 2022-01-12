using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class VotingTable
    {
        public int? VoterId { get; set; }
        public int? CandidateId { get; set; }
        public int? EventId { get; set; }

        public virtual CandidateTable? Candidate { get; set; }
        public virtual EventTable? Event { get; set; }
        public virtual VoterTable? Voter { get; set; }
    }
}
