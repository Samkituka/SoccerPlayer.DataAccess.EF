using System;
using System.Collections.Generic;

#nullable disable

namespace SoccerPlayer.DataAccess.EF.Models
{
    public partial class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamCoach { get; set; }
        public string TeamRecord { get; set; }
    }
}
