using DataGridView.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataGridView.Context
{
    public class ApplicantContext : DbContext
    {
        public DbSet<ApplicantModel> Applicants { get; set; }

        public ApplicantContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=StudentDb;Username=postgres;Password=Csharpunity1!#");
    }
}
