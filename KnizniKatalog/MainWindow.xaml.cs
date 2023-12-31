﻿using System;
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

namespace KnizniKatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonKatalog(object sender, RoutedEventArgs e)
        {
            Katalog Katalog = new Katalog();
            Katalog.Show();
            this.Close(); // Zavře stávající okno
        }

        private void ButtonUzivatele(object sender, RoutedEventArgs e)
        {
            WinUzivazele Uzivazele = new WinUzivazele();
            Uzivazele.Show();
            this.Close();
        }
    }
}
