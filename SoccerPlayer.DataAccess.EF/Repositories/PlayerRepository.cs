using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerPlayer.DataAccess.EF.Context;
using SoccerPlayer.DataAccess.EF.Models;

namespace SoccerPlayer.DataAccess.EF.Repositories
{
    public class PlayerRepository
    {
        private SoccerPlayerContext _dbContext;

        public PlayerRepository(SoccerPlayerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(PlayerModel player)
        {

            _dbContext.Add(player);
            _dbContext.SaveChanges();

            return player.PlayerID ;
        }

        public int Update(PlayerModel player )
        {
            PlayerModel  existingplayer = _dbContext.PlayerModel.Find(player.PlayerID );

            existingplayer.FirstName = player.FirstName;
            existingplayer.LastName = player.LastName;
            existingplayer.Age = player.Age;
            existingplayer.Team = player.Team;
            existingplayer.Position = player.Position;



            _dbContext.SaveChanges();

            return existingplayer.PlayerID;
        }

        public bool Delete(int PlayerID)
        {
            PlayerModel player = _dbContext.PlayerModel.Find(PlayerID);
            _dbContext.Remove(player);
            _dbContext.SaveChanges();

            return true;
        }

        public List<PlayerModel> GetAllPlayer()
        {
            List<PlayerModel> PlayerList = _dbContext.PlayerModel.ToList();

            return PlayerList;
        }

        public PlayerModel GetPlayerByID(int PlayerID)
        {
            PlayerModel player = _dbContext.PlayerModel.Find(PlayerID);

            return player;
        }
    }

}
