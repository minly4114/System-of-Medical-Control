using System.Windows;


namespace SMC_Client_Expanded
{
    /// <summary>
    /// Логика взаимодействия для wpf_patientDetalis.xaml
    /// </summary>
    public partial class wpf_patientDetalis : Window
    {
        string identity;
        DB_Connect dbconn;
        public wpf_patientDetalis(string identity)
        {
            InitializeComponent();
            dbconn = new DB_Connect();
            this.identity = identity;

        }

        private void bn_exit_Click(object sender, RoutedEventArgs e)
        {
            wpf_patients wpfpatients = new wpf_patients(identity);
            wpfpatients.Show();
            this.Close();
        }
    }
}
