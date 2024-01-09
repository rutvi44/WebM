using Microsoft.EntityFrameworkCore;

namespace MidTerm.Entities
{
    public class TimesheetDbContext : DbContext
    {
        public TimesheetDbContext(DbContextOptions<TimesheetDbContext> options) : base(options) { }

        public DbSet<Timesheet> Timesheets { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timesheet>().HasData(
                new Timesheet
                {
                    ProjectId = 1,
                    ProjectDate = new DateTime(2023, 10, 21),
                    ProjectName = "New Build",
                    ProjectDuration = 10
                },
                new Timesheet
                {
                    ProjectId = 2,
                    ProjectDate = new DateTime(2023, 10, 21),
                    ProjectName = "Bug Fix",
                    ProjectDuration = 5
                }
                );
        }
    }
}
