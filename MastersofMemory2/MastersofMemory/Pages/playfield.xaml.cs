using mastersofmemory.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mastersofmemory.Pages;
using System.Windows.Threading;

namespace mastersofmemory.Pages
{
    public partial class playfield : Page
    {
        private MemoryGrid mgrid;

        public playfield()
        {
            InitializeComponent();
            mgrid = new MemoryGrid(GameGrid);

            //Developer: Marco Giessing
            //Aanmaken van de DispatcherTimer
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1); //Aantal seconden waar de timer 1 af telt (Bij 3zou het 3 seconden duren voor hij van 1 naar 2 gaat)
            dt.Tick += dtClock; 
            dt.Start(); //Timer start wanneer je de game start
        }

        //Initele waarden voor de timer (Seconden - Minuten - Uren
        private int TimerTime = 0;
        private int TimerTimeMin = 0;
        private int TimerTimeHr = 0;

        private void dtClock(object sender, EventArgs e)
        {
            //Timer loopt op
            TimerTime++;
            
            //De Timer als string in de XAML file laten zien

            Timer.Content = TimerTime.ToString();
            TimerMin.Content = TimerTimeMin.ToString();
            TimerHr.Content = TimerTimeHr.ToString();

            //Als 59 seconden aan word getikt gaan de secondes naar -1 en de minuten +1
            if(TimerTime == 59)
            {
                TimerTime = -1;
                TimerTimeMin += 1;
            }

            //Als de minuten op 60 gaat gaan de minuten op 0 en de uren +1
            if (TimerTimeMin == 60)
            {
                TimerTimeMin = 0;
                TimerTimeHr += 1;
            }
        }
    
        //Developer: Dirk van Houten
        private void PlayFieldMenu_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new playfield_menu()); //Developer: Dirk van Houten
        }

        //Developer: Dirk van Houten
        private void PlayFieldRetry_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new playfield()); //Developer: Dirk van Houten
        }
    }
}
