using System.Windows;

namespace SMC_Client_Expanded
{
    /// <summary>
    /// Логика взаимодействия для wpf_menu.xaml
    /// </summary>
    public partial class wpf_menu : Window
    {
        string identity;
        public wpf_menu(string identity)
        {
            InitializeComponent();
            this.identity = identity;
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            wpf_entry wpfentry = new wpf_entry();
            wpfentry.Show();
            this.Close();
        }

        private void bt_patient_Click(object sender, RoutedEventArgs e)
        {
            wpf_patients wpfpatients = new wpf_patients(identity);
            wpfpatients.Show();
            this.Close();
        }

        private void bt_doctors_Click(object sender, RoutedEventArgs e)
        {
            wpf_doctors wpfdoctors = new wpf_doctors(identity);
            wpfdoctors.Show();
            this.Close();
        }

        private void bt_newPolice_Click(object sender, RoutedEventArgs e)
        {
            wpf_newPolice wpfnewpolice = new wpf_newPolice(identity);
            wpfnewpolice.Show();
            this.Close();
        }
    }
}
