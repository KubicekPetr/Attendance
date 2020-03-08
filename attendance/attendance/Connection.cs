using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;

namespace attendance
{
    public class Connection
    {
        ActiveUser au = ActiveUser.Au;

        MySqlConnection conn;
        string ConnectionString { get; }

        public Connection()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        }

        #region LOGIN REGISTER
        public bool IsLogin()
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"SELECT * FROM users WHERE username = '{au.UserName}' AND password = '{au.Password}';", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool IsRegister(string firstname, string lastname, string username, string password)
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO users (firstname, lastname, username, password) VALUES ('{firstname}','{lastname}','{username}', '{password}');", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Úspěšně jste registrovali uživatele {username}");
                    return true;
                }

            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        #endregion

        #region GET
        public List<Record> GetRecords()
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    List<Record> list = new List<Record>();
                    MySqlCommand cmd = new MySqlCommand($"SELECT r.beginning, r.end FROM users AS u JOIN records AS r WHERE u.user_id = r.user_id and u.username = '{au.UserName}';", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        list.Clear(); //pro jistotu

                        while (reader.Read())
                        {
                            DateTime end = new DateTime();
                            int colIndex = reader.GetOrdinal("end");
                            if (!reader.IsDBNull(colIndex))
                                end = reader.GetDateTime(colIndex);  //postará se o exception kvůli null hodnotám u datetime

                            list.Add(new Record(reader.GetDateTime(0), end));
                        }

                        return list;
                    }
                }

            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public List<Record> GetRecords(ComboBox userCB, ComboBox monthCB, ComboBox yearCB)
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    List<Record> list = new List<Record>();
                    MySqlCommand cmd = new MySqlCommand($"SELECT u.firstname, u.lastname, r.beginning, r.end FROM users AS u JOIN records AS r WHERE u.user_id = r.user_id and u.username = '{userCB.Text}' and r.month = '{monthCB.Text}' and r.year = '{yearCB.Text}';", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        list.Clear(); //pro jistotu

                        while (reader.Read())
                        {
                            DateTime end = new DateTime();
                            int colIndex = reader.GetOrdinal("end");
                            if (!reader.IsDBNull(colIndex))
                                end = reader.GetDateTime(colIndex);  //postará se o exception kvůli null hodnotám u datetime

                            //reader.getSth nenajde přímo datetime na pozici v argumentu
                            //pouze prochází pole v tabulce a parsuje prvek na této pozici
                            list.Add(new Record(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), end));
                        }

                        return list;
                    }
                }

            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public List<string> GetUsers()
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    List<string> list = new List<string>();
                    MySqlCommand cmd = new MySqlCommand($"SELECT username FROM users;", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }
                        return list;
                    }
                }
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public string GetMonth(int month)
        {
            switch (month)
            {
                case 1: return "Leden";
                case 2: return "Únor";
                case 3: return "Březen";
                case 4: return "Duben";
                case 5: return "Květen";
                case 6: return "Červen";
                case 7: return "Červenec";
                case 8: return "Srpen";
                case 9: return "Září";
                case 10: return "Říjen";
                case 11: return "Listopad";
                case 12: return "Prosinec";
                default: return "";
            }
        }

        public int GetUserID()
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    List<string> list = new List<string>();
                    MySqlCommand cmd = new MySqlCommand($"SELECT user_id FROM users WHERE username = '{au.UserName}';", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                        else
                        {
                            return -1;
                        }

                    }
                }
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
                return -1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }

        public int GetUserID(string username)
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    List<string> list = new List<string>();
                    MySqlCommand cmd = new MySqlCommand($"SELECT user_id FROM users WHERE username = '{username}';", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                        else
                        {
                            return -1;
                        }

                    }
                }
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
                return -1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }
        #endregion

        #region POST
        public void Begin()
        {
            if (au.UserID >= 0)
            {
                try
                {
                    using (conn = new MySqlConnection(ConnectionString))
                    {
                        conn.Open();
                        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData(); //teoreticky to ošetří změny časových pásem
                        au.Beginning = DateTime.Now;
                        string formatted = au.Beginning.ToString("yyyy-MM-dd HH:mm:ss");
                        MySqlCommand cmd = new MySqlCommand($"INSERT INTO records (user_id, month, year, beginning) VALUES ('{au.UserID}','{GetMonth(au.Beginning.Month)}','{au.Beginning.Year}','{formatted}');", conn);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (MySqlException e)
                {
                    switch (e.Number)
                    {
                        case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                        default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Vypršela platnost přihlášení.");
            }
           
        }

        public void End()
        {
            if (au.UserID >= 0)
            {
                try
                {
                    using (conn = new MySqlConnection(ConnectionString))
                    {
                        conn.Open();
                        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData(); //teoreticky to ošetří změny časových pásem
                        string formatted = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        MySqlCommand cmd = new MySqlCommand($"UPDATE records SET end = '{formatted}' WHERE user_id={au.UserID} AND end IS NULL;", conn);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (MySqlException e)
                {
                    switch (e.Number)
                    {
                        case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                        default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Vypršela platnost přihlášení.");
            }

        }
        #endregion

        #region BACKUP
        public void CreateTrack(int user_id)
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO backup (user_id, end, beginning) VALUES ('{user_id}', 1, NULL);", conn);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Musí existovat stopa uživatele (createtrack())
        /// Musí následovat po funkci Begin()!
        /// </summary>
        public void StartTrack()
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string formatted = au.Beginning.ToString("yyyy-MM-dd HH:mm:ss");
                    MySqlCommand cmd = new MySqlCommand($"UPDATE backup SET end = 0, beginning = '{formatted}' WHERE user_id = {au.UserID};", conn);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void EndTrack()
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"UPDATE backup SET end = 1, beginning = NULL WHERE user_id = {au.UserID};", conn);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Bude rozšířena o datum :))
        public bool TrackStatus()
        {
            try
            {
                using (conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"SELECT end, beginning FROM backup WHERE user_id = '{au.UserID}';", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetBoolean(0);
                        }
                        else
                        {
                            MessageBox.Show("Stopa nebyla nalezena, bude automaticky vytvořena.");
                            //Kdyby náhodou nebyla stopa vytvořena, což by jako měla bejt, vytvoří se až zde
                            CreateTrack(au.UserID);

                            reader.Close();
                            using (MySqlDataReader saveReader = cmd.ExecuteReader())
                            {
                                if (saveReader.Read())
                                {
                                    return saveReader.GetBoolean(0);
                                }
                                else
                                {
                                    MessageBox.Show("Stopa nebyla nalezena ani automaticky vytvořena.");
                                    return true;
                                }
                            }                           
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042: MessageBox.Show(e.Number.ToString() + " - Připojení k databázi se nezdařilo.", "Database Exception"); break;
                    default: MessageBox.Show(e.Number.ToString() + $" {e.Message}"); break;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return true;
            }
        }
        #endregion
    }
}
