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

        public int Create(Player player)
        {

            _dbContext.Add(player);
            _dbContext.SaveChanges();

            return player.PlayerId ;
        }

        public int Update(Player player )
        {
            Player existingplayer = _dbContext.Players.Find(player.PlayerId );

            existingplayer.FirstName = player.FirstName;
            existingplayer.LastName = player.LastName;
            existingplayer.Age = player.Age;
            existingplayer.Team = player.Team;
            existingplayer.Position = player.Position;



            _dbContext.SaveChanges();

            return existingplayer.PlayerId;
        }

        public bool Delete(int PlayerId)
        {
            Player player = _dbContext.Players.Find(PlayerId);
            _dbContext.Remove(player);
            _dbContext.SaveChanges();

            return true;
        }

        public List<Player> GetAllPlayer()
        {
            List<Player> PlayerList = _dbContext.Players.ToList();

            return PlayerList;
        }

        public Player GetPlayerByID(int PlayerId)
        {
            Player player = _dbContext.Players.Find(PlayerId);

            return player;
        }
    }

}
