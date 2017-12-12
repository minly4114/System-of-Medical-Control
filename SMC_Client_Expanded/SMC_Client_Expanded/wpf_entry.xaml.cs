using System.Windows;

namespace SMC_Client_Expanded
{
    /// <summary>
    /// Логика взаимодействия для wpf_entry.xaml
    /// </summary>
    public partial class wpf_entry : Window
    {
        DB_Connect dbconn;
        public wpf_entry()
        {
            InitializeComponent();
            dbconn = new DB_Connect();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void bt_entry_Click_(object sender, RoutedEventArgs e)
        {

            string[] confirmation = dbconn.selectFromWhere("Confirmation", "Doctors", "Identity", tb_login.Text);
            string[] pass = dbconn.selectFromWhere("Password", "Doctors", "Identity", tb_login.Text);
            if (confirmation.Length>0&&pass.Length>0)
            {
                if (confirmation[0].Equals("1") && pass[0].Equals(tb_pass.Text))
                {
                    wpf_menu menu = new wpf_menu(tb_login.Text);
                    menu.Show();
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
