using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastersofMemory.ViewModel
{
    public class StartViewModel
    {
        public MainWindow _mainWindow;

        public StartViewModel(MainWindow main)
        {
            _mainWindow = main;
            SoundViewModel.PlaySoundTrack();
        }

        public void NewGame(int designIndex)
        {
            var skin = (TileSkins)designIndex;
            GameViewModel newGame = new GameViewModel(skin);
            _mainWindow.DataContext = newGame;
        }
    }   
}
