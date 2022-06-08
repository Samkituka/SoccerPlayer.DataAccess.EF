using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerPlayer.DataAccess.EF.Context;
using SoccerPlayer.DataAccess.EF.Models;

namespace SoccerPlayer.DataAccess.EF.Repositories
{
    public class TeamRepository
    {
        private SoccerPlayerContext _dbContext;

        public TeamRepository (SoccerPlayerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create (Team team)
        {

            _dbContext.Add(team);
            _dbContext.SaveChanges();
            return team.TeamId;
        }

        public int Update ( Team team )
        {
            Team existingteam = _dbContext.Teams.Find(team.TeamId);
            existingteam.TeamName = team.TeamName;
            existingteam.TeamCoach = team.TeamCoach;
            existingteam.TeamBestPlayer = team.TeamBestPlayer;
            existingteam.TeamCaptain = team.TeamCaptain;
            existingteam.TeamStadiumName = team.TeamStadiumName;
            existingteam.TeamStadiumCapacity = team.TeamStadiumCapacity;

            _dbContext.SaveChanges();
            return existingteam.TeamId;

        }

        public bool Delete ( int TeamId)
        {
            Team team = _dbContext.Teams.Find(TeamId);

            _dbContext.Remove(team);
            _dbContext.SaveChanges();

            return true;

            
        }

        public List<Team> GetAllTeam ()
        {
            List<Team> TeamList = _dbContext.Teams.ToList();
            return TeamList;
        }

        public Team GetTeamById (int TeamId)
        {
            Team team = _dbContext.Teams.Find(TeamId);
            return team;
        }
    }
}
