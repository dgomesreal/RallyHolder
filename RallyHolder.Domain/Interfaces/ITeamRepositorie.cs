using RallyHolder.Domain.Entities;
using System.Collections.Generic;

namespace RallyHolder.Domain.Interfaces
{
    public interface ITeamRepositorie
    {
        void Add(Team team);
        IEnumerable<Team> GetAll();
        Team Get(int teamId);
        bool Exist(int teamId);
        void Update(Team team);
        void Delete(Team team);
    }
}
