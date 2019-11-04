using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mastersofmemory.Classes
{

    //Developers: Joeke de Graaf, Ynte Kuipers, Dirk van Houten
    class HighScores
    {
        public int Score;
        public int addScore = 50;
        public int decScore = 15;

        public void AddScore()
        {
            Score += addScore;
        }

        public void DecScore()
        {
            Score -= decScore;
        }

        public void Highscore()
        {
            string[] ScoreArray = new string[30];
            string[] InleesArray = new string[30]; //Voor het testen van tekstbestand inlezen naar array, een aparte array 
            string[] NamenArray = new string[30];
            string[] TileCountArray = new string[30];

            ScoreArray[0] = "123";
            ScoreArray[1] = "456";
            ScoreArray[2] = "789";

            TileCountArray[0] = "16";
            TileCountArray[1] = "64";
            TileCountArray[2] = "16";

            NamenArray[0] = "naam1";
            NamenArray[1] = "naam2";
            NamenArray[2] = "naam3";


            File.WriteAllLines(@"C:\Users\Public\MastersOfMemory.scores", ScoreArray);
            File.WriteAllLines(@"C:\Users\Public\MastersOfMemory.names", NamenArray);
            File.WriteAllLines(@"C:\Users\Public\MastersOfMemory.tiles", TileCountArray);

            InleesArray = File.ReadAllLines(@"C:\Users\Public\MastersOfMemory.sav");


            //Loop om TileAmount uit TileAmountbestand in te lezen

            //Loop om Highscores uit Highscoresbestand in te lezen
        }

        //Methode om behaalde score naar leaderboard te schrijven ----- moet aangeroepen worden als spel gewonnen is
        public void WriteToLeaderboard(string name, int tileamount, int score)
        {
            //Door de al behaalde scores loopen vanaf de laagste of hoogste waarde (kijken of het groter / kleiner is dan ... en zodoende op goede plek zetten
            //if (score > <variabelevanscore1inleaderboard>)
            //{
            //    name naar naamvariabele vak 1
            //    tileamount naar tilevariabele vak 1
            //    score naar scorevariabele vak 1
            //}
            //else if (score > <variabelevanscore2inleaderboard >)
            //{
            //    name naar naamvariabele vak 2
            //    tileamount naar tilevariabele vak 2
            //    score naar scorevariabele vak 2
            //}
            //else if (score > <variabelevanscore3inleaderboard>)
            //{
            //    name naar naamvariabele vak 3
            //    tileamount naar tilevariabele vak 3
            //    score naar scorevariabele vak 3
            //}
            //else if (score > < variabelevanscore4inleaderboard >)
            //{
            //    name naar naamvariabele vak 4
            //    tileamount naar tilevariabele vak 4
            //    score naar scorevariabele vak 4
            //}
            //else if (score > < variabelevanscore5inleaderboard >)
            //{
            //    name naar naamvariabele vak 5
            //    tileamount naar tilevariabele vak 5
            //    score naar scorevariabele vak 5
            //}

        }
    }
}
