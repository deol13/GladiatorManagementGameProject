using GladiatorManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Service
{
    
    public class PlayerService
    {
        PlayerRepo _playerRepo;

        public PlayerService(PlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }


    }
}
