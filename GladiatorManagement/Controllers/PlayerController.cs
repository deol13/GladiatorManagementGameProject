using GladiatorManagement.Models.Service;
using GladiatorManagement.Models.ViewModel;
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

         public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
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
    }
}
