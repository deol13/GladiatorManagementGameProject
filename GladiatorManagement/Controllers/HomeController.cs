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

        public IActionResult Test()
        {
            //Test123();

            return View();
        }

        public void Test123()
        {
            ///PVP Test
            //Player player = _playerService.GetCurrentPlayer();
            //Player OpponentPlayer = _playerService.GetPlayer(2);

            //PlayerGladiator playerGladiate = player.Gladiators.FirstOrDefault();
            //_playerService.CreateDefaultGladiator(player, "Hars1");
            //PlayerGladiator opponent = OpponentPlayer.Gladiators.FirstOrDefault();

            //PlayerGladiator opponent = _playerService.CreateOpponent(playerGladiate);

            //_gameService.LaunchCombat(playerGladiate, opponent, true);



            ///Everything else test
            //Player player = _playerService.GetCurrentPlayer();

            //PlayerGladiator playerGladiate = _playerService.CreateDefaultGladiator(player, "Hars1");
            //PlayerGladiator playerGladiate = player.Gladiators.FirstOrDefault();

            //ShopInventory inventory = _gameService.FindShopInventory(playerGladiate.Id, true);

            //ShopInventory inventory2 = _gameService.CreateAShop(playerGladiate.Level, playerGladiate.Id);
            //playerGladiate.InventoryId = inventory2.Id;

            //bool succeeded = _gameService.BuyAPieceOfGear(inventory, playerGladiate, true, 0);
            //bool succeeded2 = _gameService.BuyAPieceOfGear(inventory, playerGladiate, false, 0);

            _gameService.RemoveShopInventory(inventory.Id);

            //PlayerGladiator opponent = _playerService.CreateOpponent(playerGladiate);

            //_gameService.LaunchCombat(playerGladiate, opponent, false);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
