using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class StudentInfo
    {
        public StudentInfo()
        {
            CandidateTables = new HashSet<CandidateTable>();
            VoterTables = new HashSet<VoterTable>();
        }

        public int CollegeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<CandidateTable> CandidateTables { get; set; }
        public virtual ICollection<VoterTable> VoterTables { get; set; }
    }
}
