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

        public List<PlayerModel > PlayerList { get; set; }

        public PlayerModel  CurrentPlayer { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public PlayerViewModel(SoccerPlayerContext context)
        {
            _repo = new PlayerRepository(context);
            PlayerList = GetAllPlayer();
            CurrentPlayer = PlayerList.FirstOrDefault();
        }

        public PlayerViewModel(SoccerPlayerContext context, int PlayerID)
        {
            _repo = new PlayerRepository(context);
            PlayerList = GetAllPlayer();

            if (PlayerID > 0)
            {
                CurrentPlayer = GetPlayer(PlayerID );
            }
            else
            {
                CurrentPlayer= new PlayerModel ();
            }
        }

        public void SavePlayer(PlayerModel  player)
        {
            if (player.PlayerID  > 0)
            {
                _repo.Update(player );
            }
            else
            {
                player.PlayerID  = _repo.Create(player );
            }

            PlayerList  = GetAllPlayer();
            CurrentPlayer  = GetPlayer(player.PlayerID);
        }

        public void RemovePlayer(int PlayerID)
        {
            _repo.Delete(PlayerID );
            PlayerList  = GetAllPlayer();
            CurrentPlayer  = PlayerList.FirstOrDefault();
        }

        public List<PlayerModel> GetAllPlayer()
        {
            return _repo.GetAllPlayer ();
        }

        public PlayerModel  GetPlayer(int PlayerID)
        {
            return _repo.GetPlayerByID(PlayerID );
        }
    }
}
