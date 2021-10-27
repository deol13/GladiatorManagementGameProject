using GladiatorManagement.Models.Service;
using GladiatorManagement.Models.ViewModel;
using GladiatorManagement.Models.Game_logic.GameService;
using GladiatorManagement.Models.Game_logic.GameRepo;
using GladiatorManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Controllers
{
    public class PlayerController : Controller
    {
        IPlayerService _playerService;
        IGameService _gameService;
        IGameRepo _gameRepo;

         public PlayerController(IPlayerService playerService, IGameService gameService, IGameRepo gameRepo)
        {
            _playerService = playerService;
            _gameService = gameService;
            _gameRepo = gameRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowPlayer(int id)
        {
            PlayerViewModel player = _playerService.FindPlayerById(id);
            return PartialView("_PlayerView", player);
        }

        public IActionResult GladiatorDetails(int id)
        {
            PlayerGladiator glad = _playerService.FindById(id);
            return PartialView("_GladiatorDetails", glad);
        }

        public IActionResult Shop()
        {
            //    PlayerGladiator gladiator = _playerService.FindById(3);
            //    ShopInventory inventory = _gameService.CreateAShop(gladiator.Level, gladiator.Id);
            //    ShopViewModel shopView = new ShopViewModel() { 
            //        Gladiator = gladiator,
            //        Inventory = inventory
            //    };
            ShopViewModel shopView = new ShopViewModel();

         
            return View(shopView);
        }

    }
}
