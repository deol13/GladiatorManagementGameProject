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
            //Test();

            return View();
        }

        public void Test123()
        {
            Player player = _playerService.GetCurrentPlayer();
            //PlayerGladiator playerGladiate = player.Gladiators.First();
            //PlayerGladiator playerGladiate = _playerService.FindById(1);

            ////Create shop + inventory

            ////Find Shop, both with right id and a wrong id
            //ShopInventory inventory = _gameService.FindShopInventory(1);

            ////Buy a piece and send it wrong id
            //bool succeeded2 = _gameService.BuyAPieceOfGear(inventory, playerGladiate, true, 2);
            //bool succeeded3 = _gameService.BuyAPieceOfGear(inventory, playerGladiate, false, 1);

            //_gameService.RemoveShopInventory(inventory.Id);



            //Player player = null;

            //player = _playerService.GetPlayer(1);

            ////_playerService.EditAmountOfGold(player, 101);

            ////PlayerGladiator playerGladiate = _playerService.CreateDefaultGladiator(player, "Harris");
            //PlayerGladiator playerGladiate = _playerService.FindById(14);

            //PlayerGladiator opponent = _playerService.FindById(12);
            ////PlayerGladiator opponent1 = _playerService.CreateOpponent(playerGladiate);

            //_gameService.LaunchCombat(playerGladiate.Id, opponent.Id, false);

            ////_playerService.RemoveGladiator(playerGladiate   
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
