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

namespace GladiatorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IPlayerRepo _playerRepo;
        IGameService _gameService;
        IPlayerService _playerService;

        public HomeController(ILogger<HomeController> logger, IGameService gameService, IPlayerService playerService, IPlayerRepo playerRepo)
        {
            _logger = logger;
            _gameService = gameService;
            _playerService = playerService;
            _playerRepo = playerRepo;
        }

        public IActionResult Index()
        {
            XPAndGoldFormula.Setup();

            Player player = null;

            player = _playerRepo.Read(1);

            

            //_playerService.EditAmountOfGold(player, 101);

            PlayerGladiator playerGladiate = _playerService.FindById(4);

            //PlayerGladiator opponent = _playerService.CreateOpponent(playerGladiate);

            //_gameService.LaunchCombat(playerGladiate.Id, opponent.Id, false);

            _playerService.RemoveGladiator(playerGladiate);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
