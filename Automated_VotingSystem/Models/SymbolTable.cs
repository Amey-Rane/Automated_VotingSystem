using System;
using System.Collections.Generic;

namespace Automated_VotingSystem.Models
{
    public partial class SymbolTable
    {
        public SymbolTable()
        {
            CandidateTables = new HashSet<CandidateTable>();
        }

        public int SymbolId { get; set; }
        public byte[]? Symbol { get; set; }
        public string? Symbol_path { get; set; }

        public virtual ICollection<CandidateTable> CandidateTables { get; set; }
    }
}
