using Microsoft.VisualStudio.TestTools.UnitTesting;
using RallyHolder.Domain.Entities;
using System.Linq;

namespace RallyHolder.Domain.Tests.Seasons
{
    [TestClass]
    public class AddTwoTeamsTest
    {
        Season season;
        Team team1;
        Team team2;

        [TestInitialize]
        public void Initialize()
        {
            season = new Season();
            season.Id = 1;
            season.Name = "Season 2021";

            team1 = new Team();
            team1.Id = 1;
            team1.Name = "TeamTest1";

            team2 = new Team();
            team2.Id = 2;
            team2.Name = "TeamTest2";

            season.AddTeam(team1);
            season.AddTeam(team2);
        }

        [TestMethod]
        public void AddCorrectlyTwoTeams()
        {
            Assert.IsTrue(season.Teams.Count() == 3);
        }
    }
}
