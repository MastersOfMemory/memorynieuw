﻿using mastersofmemory.Classes;
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

namespace mastersofmemory.Pages
{
    public partial class menu : Page
    {
        public menu()
        {
            InitializeComponent();
        }

        private void StartGame_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App.ParentWindowRef.ParentFrame.Navigate(new gameproperties()); //Developer: Dirk van Houten
        }
    }
}
