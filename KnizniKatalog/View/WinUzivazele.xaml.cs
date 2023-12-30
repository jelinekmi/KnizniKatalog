using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KnizniKatalog
{
    public partial class WinUzivazele : Window
    {
        private Database database = new Database();

        public WinUzivazele()
        {
            InitializeComponent();
            NacistDataDoListView();
        }

        private void NacistDataDoListView()
        {
            List<Uzivatel> uzivatelEntries = database.SelectAllUzivatel();

            // Clear existing items in the ListView
            uzivatelListView.Items.Clear();

            // Populate the ListView with the retrieved data
            foreach (var uzivatelEntry in uzivatelEntries)
            {
                uzivatelListView.Items.Add(uzivatelEntry);
            }
        }
        public void PridejUzivateleDoListView(Uzivatel novyUzivatel)
        {
            uzivatelListView.Items.Add(novyUzivatel);
        }
        public void UpravUzivateleDoListView(Uzivatel uzivatel)
        {
            foreach (object item in uzivatelListView.Items)
            {
                if (item is Uzivatel uzivatelInListView && uzivatelInListView.Id == uzivatel.Id)
                {
                    int index = uzivatelListView.Items.IndexOf(uzivatelInListView);
                    uzivatelListView.Items.Remove(uzivatelInListView);
                    uzivatelListView.Items.Insert(index, uzivatel);
                    break;
                }
            }
        }

        private void buttnZpet(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }

        private void ButtenAdd(object sender, RoutedEventArgs e)
        {
            AddUzivatel add = new AddUzivatel(this);
            add.Show();
        }

        private void ButtenEdit(object sender, RoutedEventArgs e)
        {
            if (uzivatelListView.SelectedItems.Count == 1)
            {
                Uzivatel uzivatel = uzivatelListView.SelectedItem as Uzivatel;
                EdditUzivatel edit = new EdditUzivatel(this, uzivatel);
                edit.Show();
            }
        }

        private void ButtenOdstran(object sender, RoutedEventArgs e)
        {
            Uzivatel selectedUzivatel = uzivatelListView.SelectedItem as Uzivatel;

            if (selectedUzivatel != null)
            {

                database.DeleteUzivatel(selectedUzivatel.Id);


                NacistDataDoListView();
            }
            else
            {
                MessageBox.Show("Vyberte uživatele k odebrání.");
            }
        }
    }
}
