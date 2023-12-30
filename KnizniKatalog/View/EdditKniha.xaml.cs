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
    /// Interakční logika pro EdditKniha.xaml
    /// </summary>
    public partial class EdditKniha : Window
    {
        private Database database = new Database();
        private Katalog katalog;
        private Kniha kniha;
        public EdditKniha(Katalog katalog, Kniha kniha)
        {
            InitializeComponent();
            this.katalog = katalog;
            this.kniha = kniha;
            TextBoxNazev.Text = kniha.Nazev;
            TextBoxAutor.Text = kniha.Autor;
            TextBoxRokVYdani.Text = kniha.RokVydani.ToString();
            TextBoxPopis.Text = kniha.Popis;

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
                int rokVydani = Convert.ToInt32(TextBoxRokVYdani.Text);
                string popis = TextBoxPopis.Text;


                kniha.Nazev = nazev;
                kniha.Autor = autor;
                kniha.RokVydani = rokVydani;
                kniha.Popis = popis;

                database.UpdateKniha(kniha);


                katalog.UpravKnihuDoListView(kniha);


                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při přidávání knihy: {ex.Message}");
            }
        }
    }
}

