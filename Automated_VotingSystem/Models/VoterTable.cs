using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class VoterTable
    {
        public int VoterId { get; set; }
        public int? CollegeId { get; set; }
        public int? EventId { get; set; }

        public virtual StudentInfo? College { get; set; }
        public virtual EventTable? Event { get; set; }
    }
}
