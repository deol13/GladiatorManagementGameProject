using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Models.Game_logic.GameService;

namespace GladiatorManagement.Controllers
{
    public class ShopController : Controller
    {
        IGameService _gameService;

        public ShopController(IGameService gameService)
        {
            _gameService = gameService;
        }
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
