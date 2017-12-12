using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SMC_Client_Expanded
{
    /// <summary>
    /// Логика взаимодействия для wpf_doctors.xaml
    /// </summary>
    public partial class wpf_doctors : Window
    {
        string identity;
        DB_Connect dbconn;
        Dictionary<string, string> doctorIdentity;
        public wpf_doctors(string identity)
        {
            InitializeComponent();
            dbconn = new DB_Connect();
            doctorIdentity = new Dictionary<string, string>();
            this.identity = identity;
            init();
            cb_specialist.SelectionChanged += Cb_specialist_SelectionChanged;
            cb_name.SelectionChanged += Cb_name_SelectionChanged;
            cr_doctors.SelectedDatesChanged += Cr_doctors_SelectedDatesChanged;
        }

        private void Cr_doctors_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string[] workingHouse = dbconn.selectFromWhereTwo("WorkingHours", "Schedule", "DoctorIdentity", doctorIdentity[cb_name.SelectedValue.ToString()], "DayOfWork", cr_doctors.SelectedDates[0].ToString("d"));
                string[] cabinetNumber = dbconn.selectFromWhereTwo("CabinetNumber", "Schedule", "DoctorIdentity", doctorIdentity[cb_name.SelectedValue.ToString()], "DayOfWork", cr_doctors.SelectedDates[0].ToString("d"));
                if ((workingHouse.Length > 0) && (cabinetNumber.Length > 0))
                {
                    tb_workingHouse.Text = workingHouse[0];
                    tb_cabinetNumber.Text = cabinetNumber[0];
                }
            }
            catch
            {

            }
        }

        private void Cb_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                tb_cabinetNumber.Text = "";
                tb_workingHouse.Text = "";
                string[] shedule = dbconn.selectFromWhere("DayOfWork", "Schedule", "DoctorIdentity", doctorIdentity[cb_name.SelectedValue.ToString()]);
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
                        else if (day.Length<2)
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
                    cr_doctors.SelectedDates.Add(new DateTime(y, m, da));
                }
            }
            catch
            {

            }
        }

        public void init()
        {
            try
            {
                string[] posts = dbconn.selectFrom("Speciality", "Specialties");
                foreach (string post in posts)
                {
                    cb_specialist.Items.Add(post);
                }
            }
            catch
            {
                MessageBox.Show("Проверьте интернет подключение", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cb_specialist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_cabinetNumber.Text = "";
            tb_workingHouse.Text = "";
            for (int i = 0; i < cb_name.Items.Count; i++)
            {
                cb_name.Items.RemoveAt(i);
            }
            
            string[] doctors = dbconn.takeSpecialistName(cb_specialist.SelectedItem.ToString());
            string[] identity = dbconn.selectFromWhere("Identity", "Doctors", "Post", cb_specialist.SelectedItem.ToString());
            try
            {
                for (int i = 0; i < doctors.Length; i++)
                {
                    doctorIdentity.Add(doctors[i], identity[i]);
                }
            } catch
            {

            }

            foreach (string doctor in doctors)
            {
                cb_name.Items.Add(doctor);
            }
        }

        private void bn_exit_Click(object sender, RoutedEventArgs e)
        {
            wpf_menu wpfmenu = new wpf_menu(identity);
            wpfmenu.Show();
            this.Close();
        }
    }
}
