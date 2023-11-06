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
    /// Interakční logika pro Katalog.xaml
    /// </summary>
    public partial class Katalog : Window
    {
        public Katalog()
        {
            InitializeComponent();

        }

        private void ButtenZpet(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }

        private void ButtenPridat(object sender, RoutedEventArgs e)
        {
            AddKniha add = new AddKniha();
            add.Show();
        }

        private void ButtenEdit(object sender, RoutedEventArgs e)
        {
            EdditKniha add = new EdditKniha();
            add.Show();
        }

        private void ButtenOdebrat(object sender, RoutedEventArgs e)
        {

        }
    }
}
