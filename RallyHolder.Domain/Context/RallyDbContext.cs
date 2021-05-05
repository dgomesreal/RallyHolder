using Microsoft.EntityFrameworkCore;
using RallyHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
