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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace attendance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Connection con = new Connection();
        ActiveUser au = ActiveUser.Au;

        private string AdminName { get; set; } = "Admin";

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PropsButtonClick(object sender, RoutedEventArgs e)
        {
            if (au.UserName == AdminName)
            {
                AdminProps ap = new AdminProps();
                ap.Show();
            }
            else
            {
                UserProps up = new UserProps();
                up.Show();
            }
        }

        private void StateButtonClick(object sender, RoutedEventArgs e)
        {
            //když nezačal nebo už ukončil
            if (con.TrackStatus())
            {
                con.Begin();
                con.StartTrack();
                StateButton.Content = "Ukončit";
            }
            //když začal a ještě neukončil
            else
            {
                con.End();
                con.EndTrack();
                StateButton.Content = "Začít";
            }
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            au.UserName = UserNameTextBox.Text;
            au.Password = PasswordTextBox.Password;

            //Přihlášení
            if (con.IsLogin() & UserNameTextBox.IsEnabled & PasswordTextBox.IsEnabled)
            {
                StateButton.IsEnabled = true;
                UserNameTextBox.IsEnabled = false;
                PasswordTextBox.IsEnabled = false;
                TitleLabel.Content = au.UserName.ToString();
                PropsButton.IsEnabled = true;
                LoginButton.Content = $"Odhlásit se";
                au.UserID = con.GetUserID();

                //když nezačal nebo už ukončil
                if (con.TrackStatus())
                {
                    StateButton.Content = "Začít";
                }
                //když začal a ještě neukončil
                else
                {
                    StateButton.Content = "Ukončit";
                }
            }
            //Odhlášení
            else if (con.IsLogin() & !UserNameTextBox.IsEnabled & !PasswordTextBox.IsEnabled)
            {
                StateButton.IsEnabled = false;
                UserNameTextBox.IsEnabled = true;
                PasswordTextBox.IsEnabled = true;
                TitleLabel.Content = "Přihlášení";
                PropsButton.IsEnabled = false;
                LoginButton.Content = $"Přihlásit se";
                au.UserID = 0;
            }
            else
            {
                MessageBox.Show("Uživatelské jméno nebo heslo je nesprávné.");
            }
        }

        /// <summary>
        /// Ošetří více spuštěných oken najednou, kdy by jedno bylo změněno, ale v druhém okně by změna nebyla vidět
        /// MouseMove bude přesně toto hlídat
        /// </summary>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (au.UserID != 0)
            {
                //když nezačal nebo už ukončil
                if (con.TrackStatus())
                {
                    StateButton.Content = "Začít";
                }
                //když začal a ještě neukončil
                else
                {
                    StateButton.Content = "Ukončit";
                }
            }
        }
    }
}
