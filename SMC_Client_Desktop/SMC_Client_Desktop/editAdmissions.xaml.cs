using SMC_Client_Expanded;
using System.Windows;

namespace SMC_Client_Desktop
{
    /// <summary>
    /// Логика взаимодействия для editAdmissions.xaml
    /// </summary>
    public partial class editAdmissions : Window
    {
        DB_Connect connect;
        public editAdmissions()
        {
            InitializeComponent();
            try
            {
                connect = new DB_Connect();
            } catch
            {
                MessageBox.Show("Не удаётся подключиться к серверу!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            initList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window menu = new mainMenu();
            menu.Show();
            Close();
        }

        private void initList()
        {
            try
            {
                string[] list = connect.getAppointments(CurrentSession.PolicyNumber);

                for(int i = 2; i < list.Length; i = i + 4)
                {
                    list[i] = connect.takeNameDoctors(list[i]);
                }

                string temp = "";
                foreach (string s in list)
                {
                    if(s.Equals("|"))
                    {
                        admissionsList.Items.Add(temp + "  ");
                        temp = "";
                    }
                    else
                    {
                        temp += s + "  ";
                    }
                }

            } catch
            {
                MessageBox.Show("Не удаётся загрузить информацию о записях", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connect.deleteAppointment(admissionsList.SelectedIndex, CurrentSession.PolicyNumber);
                admissionsList.Items.RemoveAt(admissionsList.SelectedIndex);
            } catch
            {
                MessageBox.Show("Не удаётся отменить запись, повторите позже", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
