using SMC_Client_Expanded;
using System;
using System.Windows;

namespace SMC_Client_Desktop
{
    /// <summary>
    /// Логика взаимодействия для myAdmissions.xaml
    /// </summary>
    public partial class myAdmissions : Window
    {
        DB_Connect connect;
        public myAdmissions()
        {
            InitializeComponent();
            initDirectionsList();
        }

        private void initDirectionsList()
        {
            try
            {
                connect = new DB_Connect();
            } catch
            {
                MessageBox.Show("Не удаётся подключиться к серверу, проверьте подключение к сети, затем перезайдите в данную вкладку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                string[] directions = connect.getDirectionsList(CurrentSession.PolicyNumber);
                foreach(string dir in directions)
                {
                    admissionsList.Items.Add(connect.getDocSpeciality(dir));
                }
            } catch
            {
                MessageBox.Show("Не удаётся загрузить информацию о записях к врачу, пожалуйста, повторите позже.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Действия при нажатии на кнопку записи к врачу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Window addAppointment = new createAppoinment(admissionsList.SelectedItem.ToString());
            addAppointment.Show();
            Close();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window menu = new mainMenu();
            menu.Show();
            Close();
        }

    }
}
