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
    /// Interakční logika pro AddKniha.xaml
    /// </summary>
    public partial class AddKniha : Window
    {
        public AddKniha()
        {
            InitializeComponent();
        }

        private void ButtonStorno(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
