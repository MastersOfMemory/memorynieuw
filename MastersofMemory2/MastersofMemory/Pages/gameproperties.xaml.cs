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
using mastersofmemory.Classes;
using Microsoft.Win32;

namespace mastersofmemory.Pages
{
    public partial class gameproperties : Page
    {
      
        public gameproperties()
        {
            InitializeComponent();
        }

        //Developer: Dirk van Houten
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new Pages.playfield()); //Developer: Dirk van Houten
        }

        //Developer: Dirk van Houten
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new Pages.menu()); //Developer: Dirk van Houten
        }
    }
}
