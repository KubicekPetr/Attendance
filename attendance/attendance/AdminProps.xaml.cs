using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace attendance
{
    /// <summary>
    /// Interaction logic for AdminProps.xaml
    /// </summary>
    public partial class AdminProps : Window
    {
        Connection con = new Connection();
        Export ex = new Export();

        public List<Record> RecordsList { get; set; }

        public AdminProps()
        {
            InitializeComponent();
            UpdateUsers();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FirstNameTextBox.Text) & !string.IsNullOrWhiteSpace(LastNameTextBox.Text) & !string.IsNullOrWhiteSpace(UserNameTextBox.Text) & !string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                if (!IsDuplicate())
                {
                    if (con.IsRegister(FirstNameTextBox.Text, LastNameTextBox.Text, UserNameTextBox.Text, PasswordTextBox.Text))
                    {
                        UpdateUsers();
                        con.CreateTrack(con.GetUserID(UserNameTextBox.Text));
                    }
                }
                else
                {
                    MessageBox.Show($"Uživatel {UserNameTextBox.Text} již existuje.");
                }

            }
            else
            {
                MessageBox.Show("Některá pole jsou stále prázdná.");
            }
        }

        private void ExportButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ex.IsExportedToExcel(con.GetRecords(UsersComboBox, MonthComboBox, YearComboBox)))
            {
                MessageBox.Show("Export neproběhl úspěšně");
            }
        }

        private void DisplayButtonClick(object sender, RoutedEventArgs e)
        {
            RecordsList = con.GetRecords(UsersComboBox, MonthComboBox, YearComboBox);
            //Musí být přnastaven až po všech změnách, nejdřív vynuluji, jinak bude fungovat jen poprvé
            DataContext = null;
            DataContext = this;
        }


        /// <summary>
        /// Aktualizuje combobox s uživateli.
        /// </summary>
        private void UpdateUsers()
        {
            UsersComboBox.Items.Clear();
            foreach (string s in con.GetUsers())
            {
                UsersComboBox.Items.Add(s);
            }
        }

        //vrací true pokud uživatel již existuje
        private bool IsDuplicate()
        {
            if (con.GetUsers().Contains(UserNameTextBox.Text))
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
