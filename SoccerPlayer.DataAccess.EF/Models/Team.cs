using System;
using System.Collections.Generic;

#nullable disable

namespace SoccerPlayer.DataAccess.EF.Models
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamCoach { get; set; }
        public string TeamBestPlayer { get; set; }
        public string TeamCaptain { get; set; }
        public string TeamStadiumName { get; set; }
        public int TeamStadiumCapacity { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
