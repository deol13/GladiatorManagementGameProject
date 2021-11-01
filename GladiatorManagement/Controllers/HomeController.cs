using GladiatorManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Models.Game_logic;
using GladiatorManagement.Models.Service;
using GladiatorManagement.Models.Repo;
using GladiatorManagement.Data;
using GladiatorManagement.Models.ViewModel;
using GladiatorManagement.Models.Game_logic.GameService;

namespace GladiatorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IGameService _gameService;
        IPlayerService _playerService;


        public HomeController(ILogger<HomeController> logger, IGameService gameService, IPlayerService playerService)
        {
            _logger = logger;
            _gameService = gameService;
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            _gameService.CheckDefaultGear();
            XPAndGoldFormula.Setup();
           
            return View();
        }

        public void Test24()
        {
            //Player player = _playerService.GetCurrentPlayer();
            //_playerService.CreateDefaultGladiator(player, "terminal5");
            //_playerService.CreateDefaultGladiator(player, "terminal6");
            //Player OpponentPlayer = _playerService.GetPlayer(2);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
