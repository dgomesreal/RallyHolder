using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RallyHolder.Domain.Entities;
using System;

namespace RallyHolder.Domain.Context
{
    public class DatasBase
    {
        public static void InitialLoad(IServiceProvider serviceProvider)
        {
            using(var context = new RallyDbContext(serviceProvider.GetRequiredService<DbContextOptions<RallyDbContext>>()))
            {
                var season = new Season();
                season.Id = 1;
                season.Name = "Season 2021";
                //season.BeginningDate = DateTime.Now.AddDays(20);
                season.BeginningDate = DateTime.Now;

                var team = new Team
                {
                    Id = 1,
                    Name = "Blue",
                    IdCode = "AZL"
                };

                var pilotCarlos = new Pilot();
                pilotCarlos.Id = 1;
                pilotCarlos.Name = "Carlos";

                team.AddPilot(pilotCarlos);

                season.AddTeam(team);

                context.Seasons.Add(season);
                context.SaveChanges();

            }
        }
    }
}
