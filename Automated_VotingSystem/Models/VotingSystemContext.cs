using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Automated_VotingSystem.Models
{
    public partial class VotingSystemContext : DbContext
    {
        public VotingSystemContext()
        {
        }

        public VotingSystemContext(DbContextOptions<VotingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminTable> AdminTables { get; set; } = null!;
        public virtual DbSet<ApprovedCandidateTable> ApprovedCandidateTables { get; set; } = null!;
        public virtual DbSet<CandidateTable> CandidateTables { get; set; } = null!;
        public virtual DbSet<EventTable> EventTables { get; set; } = null!;
        public virtual DbSet<ResultsTable> ResultsTables { get; set; } = null!;
        public virtual DbSet<StudentInfo> StudentInfos { get; set; } = null!;
        public virtual DbSet<SymbolTable> SymbolTables { get; set; } = null!;
        public virtual DbSet<VoterTable> VoterTables { get; set; } = null!;
        public virtual DbSet<VotingTable> VotingTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=VotingSystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminTable>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__Admin_Ta__4A311D2FD2CD1A97");

                entity.ToTable("Admin_Table");

                entity.HasIndex(e => e.EmailId, "UQ__Admin_Ta__B7946986EB97F3B8")
                    .IsUnique();

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("Admin_id");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApprovedCandidateTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Approved_candidate_table");

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_id");

                entity.HasOne(d => d.Candidate)
                    .WithMany()
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Approved___Candi__35BCFE0A");
            });

            modelBuilder.Entity<CandidateTable>(entity =>
            {
                entity.HasKey(e => e.CandidateId)
                    .HasName("PK__Candidat__67F642D56B0D8A3B");

                entity.ToTable("Candidate_Table");

                entity.Property(e => e.CandidateId)
                    .ValueGeneratedNever()
                    .HasColumnName("Candidate_id");

                entity.Property(e => e.CollegeId).HasColumnName("College_id");

                entity.Property(e => e.EventId).HasColumnName("Event_id");

                entity.Property(e => e.Manifesto)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SymbolId).HasColumnName("Symbol_id");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.CandidateTables)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK__Candidate__Colle__31EC6D26");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.CandidateTables)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Candidate__Event__32E0915F");

                entity.HasOne(d => d.Symbol)
                    .WithMany(p => p.CandidateTables)
                    .HasForeignKey(d => d.SymbolId)
                    .HasConstraintName("FK__Candidate__Symbo__33D4B598");
            });

            modelBuilder.Entity<EventTable>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Event_Ta__FD6AEB9C6B6326D6");

                entity.ToTable("Event_Table");

                entity.Property(e => e.EventId).HasColumnName("Event_id");

                entity.Property(e => e.CandidateRegEnd)
                    .HasColumnType("date")
                    .HasColumnName("Candidate_RegEnd");

                entity.Property(e => e.CandidateRegStart)
                    .HasColumnType("date")
                    .HasColumnName("Candidate_RegStart");

                entity.Property(e => e.VoteEnd)
                    .HasColumnType("date")
                    .HasColumnName("Vote_End");

                entity.Property(e => e.VoteStart)
                    .HasColumnType("date")
                    .HasColumnName("Vote_Start");
            });

            modelBuilder.Entity<ResultsTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Results_Table");

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_id");

                entity.Property(e => e.EventId).HasColumnName("Event_id");

                entity.Property(e => e.VoteCount).HasColumnName("Vote_Count");

                entity.HasOne(d => d.Candidate)
                    .WithMany()
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Results_T__Candi__3C69FB99");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Results_T__Event__3B75D760");
            });

            modelBuilder.Entity<StudentInfo>(entity =>
            {
                entity.HasKey(e => e.CollegeId)
                    .HasName("PK__Student___88F2ECCE15AF9C5F");

                entity.ToTable("Student_Info");

                entity.HasIndex(e => e.Email, "UQ__Student___A9D1053475B72FCE")
                    .IsUnique();

                entity.Property(e => e.CollegeId)
                    .ValueGeneratedNever()
                    .HasColumnName("College_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SymbolTable>(entity =>
            {
                entity.HasKey(e => e.SymbolId)
                    .HasName("PK__Symbol_T__69A35212B48CC478");

                entity.ToTable("Symbol_Table");

                entity.Property(e => e.SymbolId)
                    .ValueGeneratedNever()
                    .HasColumnName("Symbol_id");

                entity.Property(e => e.Symbol).HasColumnType("image");
            });

            modelBuilder.Entity<VoterTable>(entity =>
            {
                entity.HasKey(e => e.VoterId)
                    .HasName("PK__Voter_Ta__E289234D898D5540");

                entity.ToTable("Voter_Table");

                entity.Property(e => e.VoterId)
                    .ValueGeneratedNever()
                    .HasColumnName("Voter_id");

                entity.Property(e => e.CollegeId).HasColumnName("College_id");

                entity.Property(e => e.EventId).HasColumnName("Event_id");

                entity.HasOne(d => d.College)
                    .WithMany(p => p.VoterTables)
                    .HasForeignKey(d => d.CollegeId)
                    .HasConstraintName("FK__Voter_Tab__Colle__2C3393D0");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.VoterTables)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Voter_Tab__Event__2D27B809");
            });

            modelBuilder.Entity<VotingTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Voting_Table");

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_id");

                entity.Property(e => e.EventId).HasColumnName("Event_id");

                entity.Property(e => e.VoterId).HasColumnName("Voter_id");

                entity.HasOne(d => d.Candidate)
                    .WithMany()
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__Voting_Ta__Candi__38996AB5");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Voting_Ta__Event__398D8EEE");

                entity.HasOne(d => d.Voter)
                    .WithMany()
                    .HasForeignKey(d => d.VoterId)
                    .HasConstraintName("FK__Voting_Ta__Voter__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
