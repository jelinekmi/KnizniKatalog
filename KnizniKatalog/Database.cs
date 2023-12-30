using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnizniKatalog
{

    internal class Database
    {

        private string connectionString = "Data Source=C:\\Users\\misaj\\source\\repos\\projekt\\KnizniKatalog\\KnizniKatalog\\bin\\Debug\\database.db;Version=3;";

        public List<Kniha> SelectAllKniha()
        {
            return SelectKniha("SELECT * FROM Kniha");
        }

        private List<Kniha> SelectKniha(string query)
        {
            List<Kniha> knihaEntries = new List<Kniha>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kniha knihaEntry = new Kniha
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nazev = reader["nazev"].ToString(),
                                Autor = reader["autor"].ToString(),
                                RokVydani = Convert.ToInt32(reader["rokvydani"]),
                                Popis = reader["popis"].ToString()
                            };

                            knihaEntries.Add(knihaEntry);
                        }
                    }
                }

                connection.Close();
            }

            return knihaEntries;
        }
        public List<KatalogBase> SelectAllKatalogBase()
        {
            return SelectKatalogBase("SELECT * FROM KatalogBase");
        }

        private List<KatalogBase> SelectKatalogBase(string query)
        {
            List<KatalogBase> katalogEntries = new List<KatalogBase>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KatalogBase katalogEntry = new KatalogBase
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                KnihaId = Convert.ToInt32(reader["knihaid"]),
                                UzivatelId = Convert.ToInt32(reader["uzivatelid"]),
                                DatumPridani = Convert.ToDateTime(reader["datumpridani"]),
                                Poznamka = reader["poznamka"].ToString()
                            };

                            katalogEntries.Add(katalogEntry);
                        }
                    }
                }

                connection.Close();
            }

            return katalogEntries;
        }
        public List<Uzivatel> SelectAllUzivatel()
        {
            return SelectUzivatel("SELECT * FROM Uzivatel");
        }

        private List<Uzivatel> SelectUzivatel(string query)
        {
            List<Uzivatel> uzivatelEntries = new List<Uzivatel>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Uzivatel uzivatelEntry = new Uzivatel
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Jmeno = reader["jmeno"].ToString(),
                                Prijmeni = reader["prijmeni"].ToString()
                            };

                            uzivatelEntries.Add(uzivatelEntry);
                        }
                    }
                }

                connection.Close();
            }

            return uzivatelEntries;
        }
        public void InsertKniha(Kniha kniha)
        {
            string query = "INSERT INTO Kniha (nazev, autor, rokvydani, popis) VALUES (@Nazev, @Autor, @RokVydani, @Popis)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nazev", kniha.Nazev);
                    command.Parameters.AddWithValue("@Autor", kniha.Autor);
                    command.Parameters.AddWithValue("@RokVydani", kniha.RokVydani);
                    command.Parameters.AddWithValue("@Popis", kniha.Popis);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void InsertKatalogBase(KatalogBase katalogEntry)
        {
            string query = "INSERT INTO KatalogBase (knihaid, uzivatelid, datumpridani, poznamka) VALUES (@KnihaId, @UzivatelId, @DatumPridani, @Poznamka)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KnihaId", katalogEntry.KnihaId);
                    command.Parameters.AddWithValue("@UzivatelId", katalogEntry.UzivatelId);
                    command.Parameters.AddWithValue("@DatumPridani", katalogEntry.DatumPridani.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Poznamka", katalogEntry.Poznamka);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void InsertUzivatel(Uzivatel uzivatel)
        {
            string query = "INSERT INTO Uzivatel (jmeno, prijmeni) VALUES (@Jmeno, @Prijmeni)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Jmeno", uzivatel.Jmeno);
                    command.Parameters.AddWithValue("@Prijmeni", uzivatel.Prijmeni);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void UpdateKniha(Kniha kniha)
        {
            string query = "UPDATE Kniha SET nazev = @Nazev, autor = @Autor, rokvydani = @RokVydani, popis = @Popis WHERE id = @Id";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nazev", kniha.Nazev);
                    command.Parameters.AddWithValue("@Autor", kniha.Autor);
                    command.Parameters.AddWithValue("@RokVydani", kniha.RokVydani);
                    command.Parameters.AddWithValue("@Popis", kniha.Popis);
                    command.Parameters.AddWithValue("@Id", kniha.Id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void UpdateKatalogBase(KatalogBase katalogEntry)
        {
            string query = "UPDATE KatalogBase SET knihaid = @KnihaId, uzivatelid = @UzivatelId, datumpridani = @DatumPridani, poznamka = @Poznamka WHERE id = @Id";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KnihaId", katalogEntry.KnihaId);
                    command.Parameters.AddWithValue("@UzivatelId", katalogEntry.UzivatelId);
                    command.Parameters.AddWithValue("@DatumPridani", katalogEntry.DatumPridani.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Poznamka", katalogEntry.Poznamka);
                    command.Parameters.AddWithValue("@Id", katalogEntry.Id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void UpdateUzivatel(Uzivatel uzivatel)
        {
            string query = "UPDATE Uzivatel SET jmeno = @Jmeno, prijmeni = @Prijmeni WHERE id = @Id";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Jmeno", uzivatel.Jmeno);
                    command.Parameters.AddWithValue("@Prijmeni", uzivatel.Prijmeni);
                    command.Parameters.AddWithValue("@Id", uzivatel.Id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void DeleteKniha(int knihaId)
        {
            string query = "DELETE FROM Kniha WHERE id = @Id";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", knihaId);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void DeleteKatalogBase(int katalogEntryId)
        {
            string query = "DELETE FROM KatalogBase WHERE id = @Id";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", katalogEntryId);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void DeleteUzivatel(int uzivatelId)
        {
            string query = "DELETE FROM Uzivatel WHERE id = @Id";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", uzivatelId);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }



    }

}

