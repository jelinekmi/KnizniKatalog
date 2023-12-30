using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interakční logika pro AddUzivatel.xaml
    /// </summary>
    public partial class AddUzivatel : Window
    {
        private Database database = new Database();
        private WinUzivazele winUzivazele;

        public AddUzivatel(WinUzivazele winUzivazele)
        {
            InitializeComponent();
            this.winUzivazele = winUzivazele;
        }

        private void ClearTextBoxes()
        {
            TextBoxJmeno.Text = string.Empty;
            TextBoxPrijmeni.Text = string.Empty;
        }

        private void ButtonStorno(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                string jmeno = TextBoxJmeno.Text;
                string prijmeni = TextBoxPrijmeni.Text;

                Uzivatel novyUzivatel = new Uzivatel
                {
                    Jmeno = jmeno,
                    Prijmeni = prijmeni
                };

                // Přidat uživatele do databáze
                database.InsertUzivatel(novyUzivatel);

                // Přidat uživatele do ListView na hlavním okně
                winUzivazele.PridejUzivateleDoListView(novyUzivatel);

                ClearTextBoxes();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při přidávání uživatele: {ex.Message}");
            }
        }
    }
}

