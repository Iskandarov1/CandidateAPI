using CandidateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateApi.Data{
    public class ApplicationDbContext:DbContext{

        public DbSet<Candidate> Candidates {get;set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options  )
            :base(options){}

            protected override void OnModelCreating(ModelBuilder modelBuilder){
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Candidate>()
                    .HasIndex(c=>c.Email)
                    .IsUnique();
            }


    }
}