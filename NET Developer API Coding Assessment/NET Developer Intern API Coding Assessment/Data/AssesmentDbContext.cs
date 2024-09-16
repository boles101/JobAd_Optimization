using Microsoft.EntityFrameworkCore;
using NET_Developer_Intern_API_Coding_Assessment.Model;

namespace NET_Developer_Intern_API_Coding_Assessment.Data
{
    public class AssesmentDbContext : DbContext
    {
        public AssesmentDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobRequest>()
                .HasOne(j => j.Platforminfo)
                .WithMany(p => p.jobRequests)
                .HasForeignKey(j => j.PlatformInfoId);

            modelBuilder.Entity<JobRequest>()
           .Property(e => e.Keywords)
           .HasConversion(
            v => string.Join(',', v),                                         // Convert List to string when saving to DB
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() // Convert string back to List when reading from DB
        );


        }





        public DbSet<PlatformInfo> platformInfos { get; set; }
        public DbSet<JobRequest> jobRequests { get; set; }
    }
}
