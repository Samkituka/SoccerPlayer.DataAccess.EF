using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerPlayer.DataAccess.EF.Context;
using SoccerPlayer.DataAccess.EF.Repositories;
using SoccerPlayer.DataAccess.EF;
using SoccerTeamMVCApplication.Models;
using SoccerPlayer.DataAccess.EF.Models;


namespace SoccerTeamMVCApplication.Controllers
{
    public class TeamController : Controller
    {
        private readonly SoccerPlayerContext _context;

        public TeamController(SoccerPlayerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            TeamViewModel model = new TeamViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int TeamId, string TeamName, string TeamCoach, string TeamBestPlayer, string TeamCaptain, string TeamStadiumName, int TeamStadiumCapacity)
        {
            TeamViewModel model = new TeamViewModel(_context);


            Team team = new()
            {
                TeamId = TeamId,
                TeamName  = TeamName,
                TeamCoach  = TeamCoach,
                TeamBestPlayer  = TeamBestPlayer,
                TeamCaptain  = TeamCaptain,
                TeamStadiumName  = TeamStadiumName,
                TeamStadiumCapacity = TeamStadiumCapacity
            };

            model.SaveTeam(team);
            model.IsActionSuccess = true;
            model.ActionMessage = "Team has been saved successfully";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            TeamViewModel model = new TeamViewModel(_context, id);

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TeamViewModel model = new TeamViewModel(_context);

            if (id > 0)
            {
                model.RemoveTeam(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Team has been deleted successfully";
            return View("index", model);
        }
    }
}
