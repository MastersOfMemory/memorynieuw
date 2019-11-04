using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace MastersofMemory.ViewModel
{
    public enum TileSkins
    {
        PixelArt,
        Mozaïek
    }

    public class GameViewModel : BaseViewModel
    {
        public PlayerViewModel Player { get; private set; }
        public PlayFieldViewModel Tiles { get; private set; } //Kenmerkt alle tiles 
        public GamePropertiesViewModel GameProperties { get; private set; } //Pairs, Scores, etc.
        public TimerViewModel Timer { get; private set; } //Timer Countdown
        public TileSkins Skins { get; private set; } //De skin die geselecteerd is 

        public GameViewModel(TileSkins skins)
        {
            Skins = skins;
            SetupGame(skins);
        }

        private void SetupGame(TileSkins skins)
        {
            Timer = new TimerViewModel(new TimeSpan(0, 0, 1));
            Tiles = new PlayFieldViewModel();
            GameProperties = new GamePropertiesViewModel();
           
            GameProperties.ClearProperties();

            Tiles.CreateTiles("Resources/" + skins.ToString());
            Tiles.Memorize();

            Timer.Start();

            OnPropertyChanged("Tiles");
            OnPropertyChanged("Timer");
            OnPropertyChanged("GameProperties");
        }

        public void TileClicked(object tile) //Als de speler op een tile clickt
        {
            if(Tiles.Select)
            {
                var selectedTile = tile as TilesViewModel; //selectedTile kan viewed, matched and failed zijn
                Tiles.SelectTile(selectedTile);
            }
            if(!Tiles.TilesActive)
            {
                if (Tiles.MatchedCheck())        
                    GameProperties.AddScore(); //Als de tiles matchen, dan worden er punten aan de score toegevoegd
                else
                    GameProperties.DecScore(); //Als de tiles niet matchen, dan worden er punten van de score afgehaald
            }

            GameStatus(); //Hier wordt gecontroleerd of alle tiles zijn gematcht of dat het spel doorgaat en of alle tries zijn gebruikt
        }

        public void Restart()
        {
            SetupGame(Skins); //Herstart het spel en laadt opnieuw de tile designs in
        }

        private void GameStatus()
        {
            if (GameProperties.MatchTries < 0) //Als alle tries zijn gebruikt, dan voert de statement deze code uit
            {
                GameProperties.GameStatus(false); //Reset het aantal tries 
                Tiles.UnmatchedReveal(); //Laat alle tiles zijn die nog niet gematched zijn
                Timer.Stop(); //Stopt de timer
            }

            if(Tiles.TilesAllMatched) //Als alle tiles gematched zijn, dan voert de statement deze code uit
            {
                GameProperties.GameStatus(true); 
                Timer.Stop(); //Stopt de timer
            }
        }
    }
}

    
