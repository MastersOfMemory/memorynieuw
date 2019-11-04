using System;
using MastersofMemory.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Threading;

namespace MastersofMemory.ViewModel
{
    public class PlayFieldViewModel : BaseViewModel
    {
        public ObservableCollection<TilesViewModel> TileCards { get; private set; }

        private TilesViewModel FirstTileSelected; //1ste geselecteerde tile
        private TilesViewModel SecondTileSelected; //2de geselecteerde tile

        private DispatcherTimer _openTimer;
        private DispatcherTimer _viewTimer;

        private const int _openSeconds = 2;  //Timer waarbij aan het begin van het spel de kaarten opengaan
        private const int _viewSeconds = 3;  //Hoe lang de kaartjes open blijven nadat je een paar geselecteerd hebt

        public bool TilesActive //Checkt of een tile geselecteerd is
        {
            get
            {
                if (FirstTileSelected == null || SecondTileSelected == null)
                    return true; //Tiles zijn active als één van de 2 Select kansen nog null zijn

                return false; //Zo niet, dan kunnen spelers niet meer tiles selecteren
            }
        }

        public bool TilesAllMatched
        {
            get
            {
                foreach(var tile in TileCards) //Checkt of alle tiles in de List (ObservableCollection) is matched
                {
                    if (!tile.Matched) //Zo niet, dan return false
                        return false;
                }

                return true; //Anders, return true
            }
        }

        public bool Select { get; private set; }

        public PlayFieldViewModel()
        {
            _viewTimer = new DispatcherTimer();
            _viewTimer.Interval = new TimeSpan(0, 0, _viewSeconds);
            _viewTimer.Tick += ViewTimer_Tick;

            _openTimer = new DispatcherTimer();
            _openTimer.Interval = new TimeSpan(0, 0, _openSeconds);
            _openTimer.Tick += OpenTimer_Tick;
        }

        public void CreateTiles(string imagePath)
        {
            TileCards = new ObservableCollection<TilesViewModel>();
            var models = GetModelsFrom(imagePath);

            for (int i = 0; i < 8; i++)
            {
                var newTile = new TilesViewModel(models[i]);
                var newMatchTile = new TilesViewModel(models[i]);
                TileCards.Add(newTile);
                TileCards.Add(newMatchTile);
                newTile.TileView();
                newMatchTile.TileView();
            }

            TileShuffle();
            OnPropertyChanged("TileCards");
        }

        public void SelectTile(TilesViewModel tile)
        {
            tile.TileView();

            if (FirstTileSelected == null)
                FirstTileSelected = tile;
            else if (SecondTileSelected == null)
            {
                SecondTileSelected = tile;
                UnmatchedHide();
            }

            SoundViewModel.TileFlip();
            OnPropertyChanged("TilesActive");
        }

        public bool MatchedCheck()
        {
            if (FirstTileSelected.Id == SecondTileSelected.Id)
            {
                CorrectMatch();
                return true;
            }
            else
            {
                IncorrectMatch();
                return false;
            }
        }

        private void IncorrectMatch()
        {
            FirstTileSelected.LabelFailed();
            SecondTileSelected.LabelFailed();
            ClearSelectedTiles();
        }

        private void CorrectMatch()
        {
            FirstTileSelected.LabelMatched();
            SecondTileSelected.LabelMatched();
            ClearSelectedTiles();
        }

        private void ClearSelectedTiles()
        {
            FirstTileSelected = null;
            SecondTileSelected = null;
            Select = false;
        }

        public void UnmatchedReveal()
        {
            foreach(var tile in TileCards)
            {
                if(!tile.Matched)
                {
                    _viewTimer.Stop();
                    tile.LabelFailed();
                    tile.TileView();
                }
            }
        } 

        public void UnmatchedHide()
        {
            _viewTimer.Start();
        }

        public void Memorize()
        {
            _openTimer.Start();
        }

       
        private List<TilesModel> GetModelsFrom(string relativePath)
        {
            var models = new List<TilesModel>();
            var images = Directory.GetFiles(@relativePath, "*.jpg", SearchOption.AllDirectories);

            var id = 0;

            foreach(string i in images)
            {
                models.Add(new TilesModel() { ID = id, ImageSource = "/MastersofMemory;component/" + i });
                id++;
            }

            return models;
        }

        private void TileShuffle()
        {
            var random = new Random();

            for (int i = 0; i < 128; i++)
            {
                TileCards.Reverse();
                TileCards.Move(random.Next(0, TileCards.Count), random.Next(0, TileCards.Count));
            }
        }

        private void OpenTimer_Tick(object sender, EventArgs e)
        {
            foreach (var tile in TileCards)
            {
                tile.CloseView();
                Select = true;
            }
            OnPropertyChanged("TilesActive");
        }

        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            foreach (var tile in TileCards)
            {
                if (!tile.Matched)
                {
                    tile.CloseView();
                    Select = true;
                }
            }
            OnPropertyChanged("TilesActive");
            _viewTimer.Stop();
        }
    }
}
