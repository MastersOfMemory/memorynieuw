using MastersofMemory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MastersofMemory.ViewModel
{
    public class PlayerViewModel : BaseViewModel
    {
        private PlayerModel _player;

        public string name { get; private set; }

        public PlayerViewModel(PlayerModel player)
        {
            _player = player;
            name = player.Name;
        }
    }
}
