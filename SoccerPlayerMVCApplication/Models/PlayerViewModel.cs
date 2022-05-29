using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoccerPlayer.DataAccess.EF.Context;
using SoccerPlayer.DataAccess.EF.Repositories;
using SoccerPlayer.DataAccess.EF.Models;

namespace SoccerPlayerMVCApplication.Models
{
    public class PlayerViewModel
    {
        private PlayerRepository _repo;

        public List<Player> PlayerList { get; set; }

        public Player CurrentPlayer { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public PlayerViewModel(SoccerPlayerContext context)
        {
            _repo = new PlayerRepository(context);
            PlayerList = GetAllPlayer();
            CurrentPlayer = PlayerList.FirstOrDefault();
        }

        public PlayerViewModel(SoccerPlayerContext context, int playerId)
        {
            _repo = new PlayerRepository(context);


            PlayerList = GetAllPlayer();

            if (playerId > 0)
            {
                CurrentPlayer = GetPlayer(playerId );
            }
            else
            {
                CurrentPlayer= new Player();
            }
        }

        public void SavePlayer(Player player)
        {
            if (player.PlayerId  > 0)
            {
                _repo.Update(player );
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
    }
}
