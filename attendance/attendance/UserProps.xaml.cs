using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace attendance
{
    /// <summary>
    /// Interaction logic for UserProps.xaml
    /// </summary>
    public partial class UserProps : Window
    {
        Connection con = new Connection();

        public List<Record> RecordsList { get; set; }

        public UserProps()
        {
            InitializeComponent();
            RecordsList = con.GetRecords();
            RecordsList.Reverse();


            //Musí být nastaven až po všech změnách
            DataContext = this;
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
    }
}
