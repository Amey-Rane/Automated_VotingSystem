namespace Automated_VotingSystem.Models
{
    public partial class DisplayCandidates
    {
        public int VoterId { get; set; }
        public int? CollegeId { get; set; }
        public int? EventId { get; set; }
        public int? CandidateId { get; set; }
        public string? Manifesto { get; set; }
        public byte[]? Symbol { get; set; }
        public string? Symbol_path { get; set; }

    }
}