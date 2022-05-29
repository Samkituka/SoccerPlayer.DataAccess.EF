using System;
using System.Collections.Generic;

#nullable disable

namespace SoccerPlayer.DataAccess.EF.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }


        public Player (int playerId, string firstName, string lastName, int age, string team, string position)
        {
            PlayerId = playerId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Team =team;
            Position = position;
        }

        public Player()
        {

        }
    }
}
