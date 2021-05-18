using Microsoft.EntityFrameworkCore;
using RallyHolder.Domain.Entities;

namespace RallyHolder.Domain.Context
{
    public class RallyDbContext : DbContext
    {
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Telemetry> Telemetry { get; set; }
        public RallyDbContext(DbContextOptions<RallyDbContext>options) : base(options)
        {

        }
    }
}
