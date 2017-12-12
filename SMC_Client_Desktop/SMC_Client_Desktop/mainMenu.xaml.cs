using System.Windows;

namespace SMC_Client_Desktop
{
    /// <summary>
    /// Логика взаимодействия для mainMenu.xaml
    /// </summary>
    public partial class mainMenu : Window
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window main = new MainWindow();
            main.Show();
            Close();
        }

        private void AdmissionButton_Click(object sender, RoutedEventArgs e)
        {
            Window admission = new myAdmissions();
            admission.Show();
            Close();
        }

        private void createAdmission_Click(object sender, RoutedEventArgs e)
        {
            Window create = new createAppoinment();
            create.Show();
            Close();
        }

        private void editAdmissions_Click(object sender, RoutedEventArgs e)
        {
            Window wind = new editAdmissions();
            wind.Show();
            Close();
        }
    }
}
