using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoccerPlayer.DataAccess.EF.Context;
using SoccerPlayer.DataAccess.EF.Repositories;
using SoccerPlayer.DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SoccerPlayerMVCApplication.Models
{
    public class PlayerViewModel
    {
        private PlayerRepository _repo;
        private TeamRepository _teamRepo;

        public List<Player> PlayerList { get; set; }

        public Player CurrentPlayer { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public IList<SelectListItem> TeamOptions { get; set; }
        public int TeamId { get; set; }

        public PlayerViewModel(SoccerPlayerContext context)
        {
            _repo = new PlayerRepository(context);
            _teamRepo = new TeamRepository(context);
            PlayerList = GetAllPlayer();
            CurrentPlayer = PlayerList.FirstOrDefault();
            TeamOptions = GetTeamsOptions(0);
        }

        public PlayerViewModel(SoccerPlayerContext context, int playerId)
        {
            _repo = new PlayerRepository(context);
            _teamRepo = new TeamRepository(context);


            PlayerList = GetAllPlayer();

            if (playerId > 0)
            {
                CurrentPlayer = GetPlayer(playerId );
            }
            else
            {
                CurrentPlayer = new Player();
            }

            TeamOptions = GetTeamsOptions(CurrentPlayer.TeamId ?? 0);
        }

        public void SavePlayer(Player player)
        {
            if (player.PlayerId  > 0)
            {
                _repo.Update(player);
            }
            else
            {
                player.PlayerId  = _repo.Create(player );
            }

            PlayerList  = GetAllPlayer();
            CurrentPlayer  = GetPlayer(player.PlayerId);
        }

        public void RemovePlayer(int PlayerId)
        {
            _repo.Delete(PlayerId );
            PlayerList  = GetAllPlayer();
            CurrentPlayer  = PlayerList.FirstOrDefault();
        }

        public List<Player> GetAllPlayer()
        {
            return _repo.GetAllPlayer();
        }

        public Player GetPlayer(int PlayerId)
        {
            return _repo.GetPlayerByID(PlayerId );
        }

        public IList<SelectListItem> GetTeamsOptions( int CurrentTeam )
        {
            var teams = this._teamRepo.GetAllTeam();

            var options = new List<SelectListItem>();

            foreach(var team in teams)
            {
                options.Add(new SelectListItem()
                {
                    Text = team.TeamName,
                    Value = team.TeamId.ToString(),
                    Selected = (CurrentTeam == team.TeamId)
                });
            }

            return options;
        }
    }
}
