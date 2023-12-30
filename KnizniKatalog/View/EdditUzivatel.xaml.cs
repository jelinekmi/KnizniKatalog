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
    /// Interakční logika pro EdditUzivatel.xaml
    /// </summary>
    public partial class EdditUzivatel : Window
    {
        private Database database = new Database();
        private WinUzivazele winuzivatele;
        private Uzivatel uzivatel;
        public EdditUzivatel(WinUzivazele winuzivatele, Uzivatel uzivatel)
        {
            InitializeComponent();
            this.uzivatel = uzivatel;
            this.winuzivatele = winuzivatele;
            Jmeno.Text = uzivatel.Jmeno;
            Prijmeni.Text = uzivatel.Prijmeni;

        }

        private void ButtonStorno(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                string jmeno = Jmeno.Text;
                string prijmeni = Prijmeni.Text;


                uzivatel.Jmeno = jmeno;
                uzivatel.Prijmeni = prijmeni;


                database.UpdateUzivatel(uzivatel);

                // Přidat knihu do ListView na hlavním okně
                winuzivatele.UpravUzivateleDoListView(uzivatel);


                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při přidávání uzživatele: {ex.Message}");
            }
        }
    }
}
