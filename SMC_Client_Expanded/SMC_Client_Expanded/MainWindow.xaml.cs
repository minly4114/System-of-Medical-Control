using System.Windows;

namespace SMC_Client_Expanded
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_register_Click(object sender, RoutedEventArgs e)
        {
            wpf_register wpfregister = new wpf_register();
            wpfregister.Show();
            this.Close();
        }

        private void bt_entry_Click(object sender, RoutedEventArgs e)
        {
            wpf_entry wpfentry = new wpf_entry();
            wpfentry.Show();
            this.Close();
        }
    }
}
