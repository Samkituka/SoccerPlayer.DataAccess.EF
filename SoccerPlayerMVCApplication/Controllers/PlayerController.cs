using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerPlayer.DataAccess.EF.Context;
using SoccerPlayer.DataAccess.EF.Repositories;
using SoccerPlayer.DataAccess.EF;
using SoccerPlayerMVCApplication.Models;
using SoccerPlayer.DataAccess.EF.Models;

namespace SoccerPlayerMVCApplication.Controllers
{
    public class PlayerController : Controller 
    {
       
        private readonly SoccerPlayerContext _context;

        public PlayerController(SoccerPlayerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            PlayerViewModel model = new PlayerViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int PlayerID, string FirstName, string LastName, int age, int TeamId, string Position)
        {
            PlayerViewModel model = new PlayerViewModel(_context);

            Player player = new()
            {
                PlayerId = PlayerID,
                FirstName = FirstName,
                LastName = LastName,
                Age = age,
                //Team = Team,
                TeamId = TeamId,
                Position = Position
            };

            model.SavePlayer(player);
            model = new PlayerViewModel(_context);


            model.IsActionSuccess = true;
            model.ActionMessage = "Player has been saved successfully";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            PlayerViewModel model = new PlayerViewModel(_context, id);

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            PlayerViewModel model = new PlayerViewModel(_context);
          
            if (id > 0)
            {
                model.RemovePlayer(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "player has been deleted successfully";
            return View("index", model);
        }

    }
}
