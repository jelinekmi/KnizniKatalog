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
    /// Interakční logika pro AddKniha.xaml
    /// </summary>
    public partial class AddKniha : Window
    {
        private Database database = new Database();
        private Katalog katalog;
        public AddKniha(Katalog katalog)
        {
            InitializeComponent();
            this.katalog = katalog;
        }
        private void ClearTextBoxes()
        {
            TextBoxNazev.Text = string.Empty;
            TextBoxAutor.Text = string.Empty;
            TextBoxRokVydani.Text = string.Empty;
            TextBoxPopis.Text = string.Empty;
        }

        private void ButtonStorno(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                string nazev = TextBoxNazev.Text;
                string autor = TextBoxAutor.Text;
                int rokVydani = Convert.ToInt32(TextBoxRokVydani.Text);
                string popis = TextBoxPopis.Text;

                Kniha novaKniha = new Kniha
                {
                    Nazev = nazev,
                    Autor = autor,
                    RokVydani = rokVydani,
                    Popis = popis
                };

                // Přidat knihu do databáze
                database.InsertKniha(novaKniha);

                // Přidat knihu do ListView na hlavním okně
                katalog.PridejKnihuDoListView(novaKniha);

                ClearTextBoxes();
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při přidávání knihy: {ex.Message}");
            }
        }
    }
}


