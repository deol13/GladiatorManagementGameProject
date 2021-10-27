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

        public IActionResult Arena()
        {
            //Lägg till i PlayerView vid "Shop" knappen en knapp för att "Go to arena"
            //Här kan du välja PVE eller PVP
            return PartialView("_ArenaPartialView");
        }

        public IActionResult PVECombat()
        {
            //Update player and gladiator after combat


            return View(); //PartialView("_PVECombatViewModel", info);
        }

        /*
        public IActionResult ShowAllEnemyPlayers()
        {
            return PartialView("");
        }
        */

        //public IActionResult PVPCombat()
        //{
        //Lista av andra spelares gladiatorer, kanske använda Player actionen på något sätt?


        //    return View(); //PartialView("_PVPCombatViewModel", info);
        //}

    }
}
