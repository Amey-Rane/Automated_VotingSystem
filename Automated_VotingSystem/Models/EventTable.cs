using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class EventTable
    {
        public EventTable()
        {
            CandidateTables = new HashSet<CandidateTable>();
            VoterTables = new HashSet<VoterTable>();
        }

        public int EventId { get; set; }
        public DateTime? CandidateRegStart { get; set; }
        public DateTime? CandidateRegEnd { get; set; }
        public DateTime? VoteStart { get; set; }
        public DateTime? VoteEnd { get; set; }

        public virtual ICollection<CandidateTable> CandidateTables { get; set; }
        public virtual ICollection<VoterTable> VoterTables { get; set; }
    }
}
