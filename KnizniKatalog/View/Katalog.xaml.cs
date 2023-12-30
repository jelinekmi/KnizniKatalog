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
    /// Interakční logika pro Katalog.xaml
    /// </summary>
    public partial class Katalog : Window
    {
        private Database database = new Database();
        public Katalog()
        {
            InitializeComponent();
            NacistDataDoListView();

        }
        private void NacistDataDoListView()
        {
            List<Kniha> knihaEntries = database.SelectAllKniha();

            // Clear existing items in the ListView
            knihaListView.Items.Clear();

            // Populate the ListView with the retrieved data
            foreach (var knihaEntry in knihaEntries)
            {
                knihaListView.Items.Add(knihaEntry);
            }

        }
        public void PridejKnihuDoListView(Kniha novaKniha)
        {
            knihaListView.Items.Add(novaKniha);
        }
        public void UpravKnihuDoListView(Kniha kniha)
        {
            foreach (object item in knihaListView.Items)
            {
                if (item is Kniha knihaInListView && knihaInListView.Id == kniha.Id)
                {
                    int index = knihaListView.Items.IndexOf(knihaInListView);
                    knihaListView.Items.Remove(knihaInListView);
                    knihaListView.Items.Insert(index, kniha);
                    break;
                }
            }
        }

        private void ButtenZpet(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }

        private void ButtenPridat(object sender, RoutedEventArgs e)
        {
            AddKniha add = new AddKniha(this);
            add.Show();
        }

        private void ButtenEdit(object sender, RoutedEventArgs e)
        {
            if (knihaListView.SelectedItems.Count == 1)
            {
                Kniha kniha = knihaListView.SelectedItem as Kniha;
                EdditKniha add = new EdditKniha(this, kniha);
                add.Show();
            }

        }

        private void ButtenOdebrat(object sender, RoutedEventArgs e)
        {
            Kniha selectedKniha = knihaListView.SelectedItem as Kniha;

            if (selectedKniha != null)
            {

                database.DeleteKniha(selectedKniha.Id);


                NacistDataDoListView();
            }
            else
            {
                MessageBox.Show("Vyberte knihu k odebrání.");
            }
        }
    }
}

