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

namespace GladiatorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IPlayerRepo _playerRepo;
        IGameService _gameService;
        IPlayerService _playerService;
        IArmorRepo _armorRepo;
        IWeaponRepo _weaponRepo;


        public HomeController(ILogger<HomeController> logger, IGameService gameService, IPlayerService playerService, 
            IPlayerRepo playerRepo, IWeaponRepo weaponRepo, IArmorRepo armorRepo)
        {
            _logger = logger;
            _gameService = gameService;
            _playerService = playerService;
            _playerRepo = playerRepo;
            _armorRepo = armorRepo;
            _weaponRepo = weaponRepo;
        }

        public IActionResult Index()
        {
            //Find a better solution
            List<Weapon> w = _weaponRepo.Read();
            List<Armor> a = _armorRepo.Read();

            XPAndGoldFormula.Setup();
            _gameService.Shop = new Shop();
            _gameService.GetInventoryFromdatabase();    


            if(_weaponRepo.Read(2) == null)
            {
                Weapon weapon = _weaponRepo.Create("Fist", 0, 0, 0);
                PlayerGladiatorRepo.DefaultWId = weapon.Id;
                
            }
            if (_armorRepo.Read(2) == null)
            {
                Armor armor = _armorRepo.Create("Skin", 0, 0, 0);
                PlayerGladiatorRepo.DefaultAId = armor.Id;
            }
            
            //Test();

            return View();
        }

        public void Test()
        {
            Player player = _playerRepo.Read(1);
            PlayerGladiator playerGladiate = _playerService.FindById(15);

            ////Create shop + inventory
            ShopInventory inventory = _gameService.CreateAShop(playerGladiate.Level, playerGladiate.Id);

            ////Find Shop, both with right id and a wrong id
            //ShopInventory inventory = _gameService.FindShopInventory(2);

            ////Buy a piece and send it wrong id
            bool succeeded2 = _gameService.BuyAPieceOfGear(inventory, playerGladiate, true, 2);

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

        [HttpPost]
        public IActionResult ShowPlayer(int id)
        {
            PlayerViewModel player = _playerService.FindPlayerById(id);
            return PartialView("_PlayerView", player);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
