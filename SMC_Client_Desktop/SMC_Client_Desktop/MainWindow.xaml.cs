using SMC_Client_Expanded;
using System.Windows;

namespace SMC_Client_Desktop
{
    public partial class MainWindow : Window
    {
        DB_Connect connect;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                connect = new DB_Connect();
            } catch
            {
                MessageBox.Show("Не удаётся подключиться к серверу, проверьте подключение к сети. Перезапустите программу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Слушатель для кнопки "Войти"
        /// Если аккаунт найден, то вызывает метод, заполняющий
        /// данные о текующей сессии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] result = connect.getPatientInfo(tb_policynumber.Text, tb_birthday.Text);
                if(result.Length > 0)
                {
                    setCurrentSessionValues(result);
                    Window mainWindow = new mainMenu();
                    mainWindow.Show();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Такой комбинации не найдено!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        /// <summary>
        /// Данный метод заполняет данные в статический класс CurrentSession
        /// </summary>
        /// <param name="values"></param>
        private void setCurrentSessionValues(string[] values)
        {
            CurrentSession.LastName = values[0];
            CurrentSession.FirstName = values[1];          
            CurrentSession.MiddleName = values[2];
            CurrentSession.BirthdayDate = values[3];
            CurrentSession.PolicyNumber = values[4];
            CurrentSession.PasportInfo = values[5];
            CurrentSession.PolyclinicName = values[6];
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
