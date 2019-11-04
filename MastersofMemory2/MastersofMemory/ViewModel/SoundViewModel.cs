using System;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MastersofMemory.ViewModel
{
    class SoundViewModel
    {
        private static MediaPlayer _soundfxPlayer = new MediaPlayer();
        private static MediaPlayer _soundtrackPlayer = new MediaPlayer();

        public static void OpenMusicFile(string relativePath)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _soundtrackPlayer.Open(new Uri(openFileDialog.FileName));
                _soundtrackPlayer.Play();
            }
        }

        public static void MatchCorrect()
        {
            PlayFX("match_correct.mp3");
        }

        public static void MatchIncorrect()
        {
            PlayFX("match_incorrect.mp3");
        }

        public static void TileFlip()
        {
            PlayFX("card_flip.mp3");
        }

        private static void PlayFX(string fileName)
        {
            _soundfxPlayer.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Resources/Audio/SoundFX/" + fileName)));
        }

        public static void PlaySoundTrack()
        {
            _soundtrackPlayer.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Resources/Audio/soundtrack.mp3")));
        }
    }
}
