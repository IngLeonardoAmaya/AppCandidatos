using AppCandidatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCandidatos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación uno a muchos entre Candidate y CandidateExperience con eliminación en cascada
            modelBuilder.Entity<Candidate>()
                .HasMany(c => c.CandidateExperiences)
                .WithOne(e => e.Candidate)
                .HasForeignKey(e => e.IdCandidate)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
