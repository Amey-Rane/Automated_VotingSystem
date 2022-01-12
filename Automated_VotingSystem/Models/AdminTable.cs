using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class AdminTable
    {
        public int AdminId { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
    }
}
