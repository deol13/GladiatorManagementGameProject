﻿using GladiatorManagement.Models.Service;
using GladiatorManagement.Models.ViewModel;
using GladiatorManagement.Models.Game_logic.GameService;
using GladiatorManagement.Models.Game_logic.GameRepo;
using GladiatorManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
