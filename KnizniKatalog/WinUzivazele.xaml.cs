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
using System.Windows.Shapes;

namespace KnizniKatalog
{
    /// <summary>
    /// Interakční logika pro WinUzivazele.xaml
    /// </summary>
    public partial class WinUzivazele : Window
    {
        public WinUzivazele()
        {
            InitializeComponent();

        }

        private void buttnZpet(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }

        private void ButtenAdd(object sender, RoutedEventArgs e)
        {
            AddUzivatel add = new AddUzivatel();
            add.Show();
        }

        private void ButtenEdit(object sender, RoutedEventArgs e)
        {
            EdditUzivatel add = new EdditUzivatel();
            add.Show();
        }

        private void ButtenOdstran(object sender, RoutedEventArgs e)
        {

        }
    }
}
