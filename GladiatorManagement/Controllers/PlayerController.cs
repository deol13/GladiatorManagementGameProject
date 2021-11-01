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
using System.Net;
using Microsoft.AspNetCore.Authorization;


namespace GladiatorManagement.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class PlayerController : Controller
    {
        IPlayerService _playerService;
        IGameService _gameService;
        IGameRepo _gameRepo;
        static int GladiatorId { get; set; }
        static ShopInventory GladiatorsShop { get; set; }
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

        [HttpGet]
        public IActionResult ShowPlayer()
        {
            PlayerViewModel player = _playerService.FindPlayerById(0);
            return PartialView("_PlayerView", player);
        }

        ///Because in Setup->Endpoints->pattern the paramter is called id, we have to call it id in the action
        ///that wants to use that pattern.
        [HttpPost]
        public IActionResult GladiatorDetails(int id)
        {
            PlayerGladiator glad = null;
            Player currentPlayer = _playerService.GetCurrentPlayer();
            foreach (var item in currentPlayer.Gladiators)
            {
                if (item.Id == id)
                    glad = item;
            }
            if(glad == null)
                glad = _playerService.FindById(id);

            return PartialView("_GladiatorDetails", glad);
        }

        [HttpPost]
        public IActionResult Shop(int id)
        {
            PlayerGladiator gladiator = _playerService.FindById(id);
            GladiatorId = gladiator.Id;

            if (gladiator.InventoryId > 0)
            {
                ShopInventory inventory = _gameService.FindShopInventory(id, true);
                ShopViewModel shopView = new ShopViewModel()
                {
                    Gladiator = gladiator,
                    Inventory = inventory
                };

                GladiatorsShop = inventory;

                return PartialView("Shop", shopView);
            }

            ShopInventory inventory2 = _gameService.CreateAShop(gladiator.Level, id);
            gladiator.InventoryId = inventory2.Id;
            _playerService.UpdateGladiator(gladiator);
            ShopViewModel shopView1 = new ShopViewModel()
            {
                Gladiator = gladiator,
                Inventory = inventory2
            };
            //ShopViewModel shopView = new ShopViewModel();
            GladiatorsShop = inventory2;

            return PartialView("Shop", shopView1);
        }

        //public IActionResult BuyWeapon(ShopViewModel shopView)
        //{
        //    ShopInventory inventory = shopView.Inventory;
        //    PlayerGladiator gladiator = shopView.Gladiator;
        //    int weaponId = 0; //how??

        //    if (_gameService.BuyAPieceOfGear(inventory, gladiator, true, weaponId))
        //    {
        //        int status = Response.StatusCode = (int)HttpStatusCode.OK;
        //        return Json(status + ": Yau have bought a weapon!");
        //    }
        //    else
        //    {
        //        int status = (int)HttpStatusCode.BadRequest;
        //        return Json(status + ": Could not buy weapon :(");
        //    }

        //    //return View(shopView);
        //}

        [HttpPost]
        public IActionResult BuyWeapon(int id)
        {
            //Weapon weapon = _gameService.FindWeapon(id);
            ShopInventory inventory = GladiatorsShop;
            PlayerGladiator gladiator = _playerService.FindById(GladiatorId); ;

            if(id < 0 || id > inventory.WeaponsInShop.Count)
            {
                int status = (int)HttpStatusCode.BadRequest;
                return Json(status + ": id out of bounce :(");
            }

            if (_gameService.BuyAPieceOfGear(inventory, gladiator, true, id))
            {
                int status = Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(status + ": You have bought a weapon!");
            }
            else
            {
                int status = (int)HttpStatusCode.BadRequest;
                return Json(status + ": Could not buy weapon :(");
            }
        }

        [HttpPost]
        public IActionResult BuyArmor(int id)
        {
            //Weapon weapon = _gameService.FindWeapon(id);
            ShopInventory inventory = GladiatorsShop;
            PlayerGladiator gladiator = _playerService.FindById(GladiatorId); ;

            if (id < 0 || id > inventory.WeaponsInShop.Count)
            {
                int status = (int)HttpStatusCode.BadRequest;
                return Json(status + ": id out of bounce :(");
            }

            if (_gameService.BuyAPieceOfGear(inventory, gladiator, false, id))
            {
                int status = Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(status + ": You have bought an armor!");
            }
            else
            {
                int status = (int)HttpStatusCode.BadRequest;
                return Json(status + ": Could not buy armor :(");
            }
        }

        [HttpPost]
        public IActionResult Arena()
        {
            return PartialView("_ArenaPartialView");
        }

        [HttpPost]
        public IActionResult ShowAllEnemyPlayers(int id)
        {
            bool exist = false;
            Player currPlayer = _playerService.GetCurrentPlayer();

            foreach (var item in currPlayer.Gladiators)
            {
                if (item.Id == id)
                    exist = true;
            }

            if (exist)
            {
                GladiatorId = id;
                List<PlayerGladiator> listOfenemyGlad = _playerService.GetListOfEnemyGlad(currPlayer.PlayerId);

                PlayerViewModel player = new PlayerViewModel();
                player.Player = currPlayer;
                player.Gladiators = listOfenemyGlad;

                return PartialView("PVPShowAllEnemiesPartialView", player);
            }

            return PartialView("_ArenaPartialView");
        }

        [HttpPost]
        public IActionResult PVECombat(int id)
        {
            PlayerGladiator playersGladiator = _playerService.FindById(id);

            if (playersGladiator != null)
            {
                PVEGladiatorViewModel info = new PVEGladiatorViewModel();
                PlayerGladiator opponent = _playerService.CreateOpponent(playersGladiator);

                info.PlayerId = _playerService.GetCurrentPlayer().PlayerId;
                info.GladiatorName = playersGladiator.Name;
                info.OpponentName = opponent.Name;

                info.CombatLog = _gameService.LaunchCombat(playersGladiator, opponent, false);

                return PartialView("_PVECombatViewModel", info);
            }

            return PartialView("_ArenaPartialView");
        }

       
        public IActionResult PVPCombat(int id)
        {
            PlayerGladiator opponent = _playerService.FindById(id);

            if (opponent != null)
            {
                if (opponent.Id != GladiatorId)
                {
                    PVEGladiatorViewModel info = new PVEGladiatorViewModel();
                    PlayerGladiator playersGladiator = _playerService.FindById(GladiatorId);

                    info.PlayerId = _playerService.GetCurrentPlayer().PlayerId;
                    info.GladiatorName = playersGladiator.Name;
                    info.OpponentName = opponent.Name;

                    info.CombatLog = _gameService.LaunchCombat(playersGladiator, opponent, true);

                    return PartialView("_PVECombatViewModel", info);
                }
            }

            return PartialView("_ArenaPartialView");
        }

        [HttpGet]
        public IActionResult HighScore()
        {
            HighScoreViewModel highScore = _playerService.GetHighScore();

            return PartialView("_HighScorePartialView", highScore);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Player player = _playerService.GetCurrentPlayer();
            CreateGladiatorViewModel createViewModel = new CreateGladiatorViewModel(player);

            return PartialView("Create", createViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateGladiatorViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                _playerService.CreateGladiator(createViewModel);

                return RedirectToAction(nameof(Index));
            }

            return PartialView("Create", createViewModel);
        }
    }
}
