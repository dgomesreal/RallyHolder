using RallyHolder.Domain.Context;
using RallyHolder.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using RallyHolder.Domain.Interfaces;

namespace RallyHolder.Domain.Repositories
{
    public class TeamRepositorie : ITeamRepositorie
    {
        private readonly RallyDbContext _rallyDbContext;
        public TeamRepositorie(RallyDbContext rallyDbContext)
        {
            _rallyDbContext = rallyDbContext;
        }

        public void Add(Team team)
        {
            _rallyDbContext.Teams.Add(team);
            _rallyDbContext.SaveChanges();
        }

        public void Delete(Team team)
        {
            _rallyDbContext.Teams.Remove(team);
            _rallyDbContext.SaveChanges();
        }

        public bool Exist(int teamId)
        {
            return _rallyDbContext.Teams.Any(p => p.Id == teamId);
        }

        public Team Get(int teamId)
        {
            return _rallyDbContext.Teams.FirstOrDefault(p => p.Id == teamId);
        }

        public IEnumerable<Team> GetAll()
        {
            return _rallyDbContext.Teams.ToList();
        }

        public void Update(Team team)
        {
            if (_rallyDbContext.Entry(team).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _rallyDbContext.Attach(team);
                _rallyDbContext.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _rallyDbContext.Update(team);
            }
            _rallyDbContext.SaveChanges();
        }
    }
}
