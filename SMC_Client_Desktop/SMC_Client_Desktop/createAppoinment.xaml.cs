using SMC_Client_Expanded;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SMC_Client_Desktop
{
    /// <summary>
    /// Логика взаимодействия для createAppoinment.xaml
    /// </summary>
    public partial class createAppoinment : Window
    {
        DB_Connect connect;
        Dictionary<string, string> doctorIdentity = new Dictionary<string, string>();
        public createAppoinment()
        {
            InitializeComponent();
            try
            {
                connect = new DB_Connect();
            } catch
            {
                MessageBox.Show("Не удаётся подключиться к серверу, проверьте подключение к сети, затем перезайдите в данную вкладку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            initPostList();
        }

        private void Cb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string[] cabinetNumber = connect.selectFromWhereTwo("CabinetNumber", "schedule", "DoctorIdentity", doctorIdentity[cb_Name.SelectedValue.ToString()], "DayOfWork", cr_shedule.SelectedDates[0].ToString("d"));
                string[] workingHours = connect.selectFromWhereTwo("WorkingHours", "schedule", "DoctorIdentity", doctorIdentity[cb_Name.SelectedValue.ToString()], "DayOfWork", cr_shedule.SelectedDates[0].ToString("d"));
                tb_cabinetNumber.Text = cabinetNumber[0];
                foreach(string time in workingHours)
                {
                    tb_workHouse.Items.Add(time);
                }
            }
            catch
            {

            }
        }

        private void Cr_shedule_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string[] identities = connect.selectFromWhereTwo("DoctorIdentity", "Schedule", "Post", admissionsList.Text, "DayOfWork", cr_shedule.SelectedDates[0].ToString("d"));
                cb_Name.Items.Clear();
                foreach (string identity in identities)
                {
                    cb_Name.Items.Add(connect.takeNameDoctors(identity));
                    doctorIdentity.Add(connect.takeNameDoctors(identity), identity); 
                }
            }
            catch
            {

            }
        }
        private void AdmissionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                string[] shedule = connect.selectFromWhere("DayOfWork", "Schedule", "Post", admissionsList.SelectedItem.ToString());
                for (int i = 0; i < shedule.Length; i++)
                {
                    string day = "";
                    string month = "";
                    string year = "";
                    string not = "";
                    char[] date = shedule[i].ToCharArray();
                    foreach (char d in date)
                    {
                        if (d.Equals('.'))
                        {
                            not += d;
                        }
                        else if (day.Length < 2)
                        {
                            day += d;
                        }
                        else if (month.Length < 2)
                        {
                            month += d;
                        }
                        else if (year.Length < 4)
                        {
                            year += d;
                        }
                    }
                    int y = Convert.ToInt32(year);
                    int m = Convert.ToInt32(month);
                    int da = Convert.ToInt32(day);
                    cr_shedule.SelectedDates.Add(new DateTime(y, m, da));
                }
            }
            catch
            {

            }
        }

        public createAppoinment(string post)
        {
            InitializeComponent();
            try
            {
                connect = new DB_Connect();
            }
            catch
            {
                MessageBox.Show("Не удаётся подключиться к серверу, проверьте подключение к сети, затем перезайдите в данную вкладку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            initPostList();
            admissionsList.SelectedItem = post;
        }
        private void initPostList()
        {
            string[] list = connect.getSpecialties();

            foreach(string s in list)
            {
                admissionsList.Items.Add(s);
            }
            
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window menu = new mainMenu();
            menu.Show();
            Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(admissionsList.SelectedValue.ToString().Equals("") || cb_Name.SelectedValue.ToString().Equals("") || tb_workHouse.SelectedValue.ToString().Equals("") || cr_shedule.SelectedDates[0].ToString("d").Equals("")))
                {
                    connect.insertAppointments(doctorIdentity[cb_Name.SelectedValue.ToString()], CurrentSession.PolicyNumber, cr_shedule.SelectedDates[0].ToString("d"), tb_workHouse.SelectedValue.ToString());
                    connect.deleteShedule(doctorIdentity[cb_Name.SelectedValue.ToString()], tb_workHouse.SelectedValue.ToString(), cr_shedule.SelectedDates[0].ToString("d"));
                    MessageBox.Show("Запись успешно создана", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Не удалось записаться к врачу, повторите позже", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {

            }
        }
    }
}
