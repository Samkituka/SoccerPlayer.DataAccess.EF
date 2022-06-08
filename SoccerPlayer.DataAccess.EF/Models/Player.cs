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
        public int? TeamId { get; set; }

        public virtual Team TeamNavigation { get; set; }
    }
}
