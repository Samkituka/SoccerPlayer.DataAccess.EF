using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoccerPlayer.DataAccess.EF.Context;
using SoccerPlayer.DataAccess.EF.Repositories;
using SoccerPlayer.DataAccess.EF.Models;

namespace SoccerTeamMVCApplication.Models
{
    public class TeamViewModel
    {
        private  TeamRepository _repo;

        public List<Team> TeamList { get; set; }

        public Team CurrentTeam { get; set; }

        public string ActionMessage { get; set; }

        public bool IsActionSuccess { get; set; }


        public TeamViewModel (SoccerPlayerContext context)
        {
            _repo = new TeamRepository(context);
            TeamList = GetAllTeam ();
            CurrentTeam = TeamList.FirstOrDefault();
        }

        public TeamViewModel (SoccerPlayerContext context , int TeamId)
        {
            _repo = new TeamRepository(context);

            TeamList = GetAllTeam();

            if (TeamId>0)
            {
                CurrentTeam = GetTeam(TeamId);

            }
            else
            {
                CurrentTeam = new Team();
            }
        }

        public void SaveTeam (Team team )
        {

            if (team.TeamId >0)
            {
                _repo.Update(team);

            }
            else
            {
                 team.TeamId = _repo.Create(team);
            }
            TeamList = GetAllTeam();
            CurrentTeam = GetTeam(team.TeamId);
        }

        public void RemoveTeam(int TeamId)
        {
            _repo.Delete(TeamId);
            TeamList = GetAllTeam();
            CurrentTeam = TeamList.FirstOrDefault();
        }

        public List<Team> GetAllTeam()
        {
            return _repo.GetAllTeam();
        }

        public Team GetTeam(int TeamId)
        {
            return _repo.GetTeamById(TeamId);
        }





    }
}
