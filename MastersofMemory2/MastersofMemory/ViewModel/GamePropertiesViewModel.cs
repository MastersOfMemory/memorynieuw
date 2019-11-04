using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MastersofMemory.ViewModel
{
    public class GamePropertiesViewModel : BaseViewModel
    {
        private int _score;
        private int _matchTries;

        private const int _addScore = 75; //Voor iedere paar die match, gaat er 75 punten bij op
        private const int _decScore = 15; //Voor elke paar die niet matcht, gaat er 15 punten af
        private const int _maxTries = 4;  //Maximaal aantal tries voordat het game over is

        private bool _wonGame;
        private bool _lostGame;

        public int Score
        {
            get
            {
                return _score;
            }
            private set
            {
                _score = value;
                OnPropertyChanged("Score"); //Data Binding met PlayFieldView
            }
        }

        public int MatchTries
        {
            get
            {
                return _matchTries;
            }
            private set
            {
                _matchTries = value;
                OnPropertyChanged("MatchTries"); //Data Binding met PlayFieldView
            }
        }

        public Visibility WinGameMessage
        {
            get
            {
                if (_wonGame)
                    return Visibility.Visible;

                return Visibility.Hidden;
            }
        }

        public Visibility LostGameMessage
        {
            get
            {
                if (_lostGame)
                    return Visibility.Visible;

                return Visibility.Hidden;
            }
        }

        public void GameStatus(bool win)
        {
            if (!win)
            {
                _lostGame = true;
                OnPropertyChanged("LostGameMessage");
            }

            if (win)
            {
                _wonGame = true;
                OnPropertyChanged("WinGameMessage");
            }
        }

        public void ClearProperties()
        {
            Score = 0;
            MatchTries = _maxTries;
            _wonGame = false;
            _lostGame = false;
            OnPropertyChanged("WinMessage");
            OnPropertyChanged("LostMessage");
        }

        public void AddScore()
        {
            Score += _addScore;
            SoundViewModel.MatchCorrect();
        }

        public void DecScore()
        {
            Score -= _decScore;
            MatchTries--;
            SoundViewModel.MatchIncorrect();
        }
    }
}
