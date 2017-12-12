using System.Windows;

namespace SMC_Client_Expanded
{
    /// <summary>
    /// Логика взаимодействия для wpf_newPolice.xaml
    /// </summary>
    public partial class wpf_newPolice : Window
    {
        string identity;
        DB_Connect dbconn;
        public wpf_newPolice(string identity)
        {
            InitializeComponent();
            this.identity = identity;
            dbconn = new DB_Connect();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            wpf_menu wpfmenu = new wpf_menu(identity);
            wpfmenu.Show();
            this.Close();
        }

        private void bt_register_Click(object sender, RoutedEventArgs e)
        {

            if (tb_lastName.Text.Equals("") || tb_firstName.Text.Equals("") || tb_middleName.Text.Equals("") ||
                tb_birthday.Text.Equals("") || tb_series.Text.Equals("") || tb_number.Text.Equals("") ||
                tb_who.Text.Equals("") || tb_when.Text.Equals("") || tb_policyNumber.Text.Equals("") || tb_phone.Text.Equals("") || tb_policlinicName.Text.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string passport = tb_series.Text + tb_number.Text + tb_who.Text + tb_when.Text;

                if (dbconn.selectFromWhere("PasportInfo", "Patients", "PolicyNumber", tb_policyNumber.Text).Length<=0)
                {
                    dbconn.addAccountPatient(tb_lastName.Text, tb_firstName.Text, tb_middleName.Text,
                    tb_birthday.Text, tb_policyNumber.Text, passport, tb_policlinicName.Text, tb_phone.Text);

                    MessageBox.Show("Пользователь успешно зарегистрирован", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Пользователь с таким Идентификатором уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
