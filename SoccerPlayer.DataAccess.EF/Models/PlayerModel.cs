using System;
using System.Collections.Generic;

namespace SoccerPlayer.DataAccess.EF.Models
{
    public partial class PlayerModel
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }



        public PlayerModel(int playerid, string firstname, string lastname, int age, string team, string position)
        {
            PlayerID = playerid;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Team = team;
            Position = position;
        }

        public PlayerModel ()
        {

        }
    }

    
}
