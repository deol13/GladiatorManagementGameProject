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

namespace GladiatorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IPlayerRepo _playerRepo;
        IGameService _gameService;
        IPlayerService _playerService;
        ApplicationDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, IGameService gameService, IPlayerService playerService, 
            IPlayerRepo playerRepo, ApplicationDbContext appDbContext)
        {
            _logger = logger;
            _gameService = gameService;
            _playerService = playerService;
            _playerRepo = playerRepo;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            XPAndGoldFormula.Setup();

            if(_appDbContext.Weapons.Find(2) == null)
            {
                Weapon weapon = new Weapon("Fist", 0, 0, 0);
                _appDbContext.Weapons.Add(weapon);
                _appDbContext.SaveChanges();
                PlayerGladiatorRepo.DefaultWId = weapon.Id;
                
            }
            if (_appDbContext.Armors.Find(2) == null)
            {
                Armor armor = new Armor("Skin", 0, 0, 0);
                _appDbContext.Armors.Add(armor);
                _appDbContext.SaveChanges();
                PlayerGladiatorRepo.DefaultAId = armor.Id;
            }
            //Player player = null;

            //player = _playerRepo.Read(1);

            ////_playerService.EditAmountOfGold(player, 101);

            ////PlayerGladiator playerGladiate = _playerService.CreateDefaultGladiator(player, "Harris");
            //PlayerGladiator playerGladiate = _playerService.FindById(14);

            //PlayerGladiator opponent = _playerService.FindById(12);
            ////PlayerGladiator opponent1 = _playerService.CreateOpponent(playerGladiate);

            //_gameService.LaunchCombat(playerGladiate.Id, opponent.Id, false);

            ////_playerService.RemoveGladiator(playerGladiate
            ///



            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
