using System.Windows;

namespace SMC_Client_Expanded
{
    /// <summary>
    /// Логика взаимодействия для wpf_register.xaml
    /// </summary>
    public partial class wpf_register : Window
    {
        DB_Connect dbconn;
        public wpf_register()
        {
            InitializeComponent();
            dbconn = new DB_Connect();
            init();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
        /// <summary>
        /// Инициализация должностей и больниц
        /// </summary>
        public void init()
        {
            string[] posts = dbconn.selectFrom("Speciality", "Specialties");
            foreach (string post in posts)
            {
                cb_post.Items.Add(post);
            }
            string[] policlinics = dbconn.selectFrom("PolyclinicName", "Polyclinics");
            foreach (string policlinic in policlinics)
            {
                cb_polyclinic.Items.Add(policlinic);
            }
        }
        /// <summary>
        /// Регистрация нового аккаунта
        /// </summary>
        private void bt_register_Click(object sender, RoutedEventArgs e)
        {
            if (tb_lastName.Text.Equals("") || tb_firstName.Text.Equals("") || tb_middleName.Text.Equals("") ||
                tb_birthday.Text.Equals("") || tb_series.Text.Equals("") || tb_number.Text.Equals("") ||
                tb_who.Text.Equals("") || tb_when.Text.Equals("") || cb_post.Text.Equals("") || cb_polyclinic.Text.Equals("") || tb_pass.Text.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string passport = tb_series.Text + tb_number.Text + tb_who.Text + tb_when.Text;
                string priority = "0";
                string identity = tb_series.Text + tb_number.Text;

                if (dbconn.selectFromWhere("Confirmation", "Doctors", "Identity", identity).Length==0)
                {
                    dbconn.addAccountDoctor(tb_lastName.Text, tb_firstName.Text, tb_middleName.Text,
                    tb_birthday.Text, cb_post.Text, priority, identity, tb_pass.Text, passport, cb_polyclinic.Text);

                    MessageBox.Show("Дождитесь подтверждения регистрации", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Пользователь с таким Идентификатором уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

