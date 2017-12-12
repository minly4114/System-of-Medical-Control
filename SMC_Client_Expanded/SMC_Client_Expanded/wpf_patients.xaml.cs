using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace SMC_Client_Expanded
{
    /// <summary>
    /// Логика взаимодействия для wpf_patients.xaml
    /// </summary>
    public partial class wpf_patients : Window
    {
        string identity;
        string date;
        DB_Connect dbconn;
        Dictionary<string, string> specialties = new Dictionary<string, string>();
        public wpf_patients(string identity)
        {
            InitializeComponent();
            this.identity = identity;
            date = DateTime.Today.ToString("d");
            dbconn = new DB_Connect();
            init();
            cb_policyNumber.SelectionChanged += Cb_policyNumber_SelectionChanged;
        }

        private void Cb_policyNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_admissionTime.Text = dbconn.choicetime(cb_policyNumber.SelectedItem.ToString(), identity, date);
            tb_name.Text = dbconn.takeName(cb_policyNumber.SelectedItem.ToString());
            string[] birthdayDate = dbconn.selectFromWhere("BirthdayDate", "Patients", "PolicyNumber", cb_policyNumber.SelectedItem.ToString());
            if (!(birthdayDate.Length<0))
            {
                tb_birthday.Text = birthdayDate[0];
            } 
        }
        
        
        private void init()
        {
            string[] patients = dbconn.selectFromWhereTwo("PolicyNumber", "Appointments", "DoctorIdentity", identity, "AppointmentDate", date);
            foreach (string patient in patients)
            {
                cb_policyNumber.Items.Add(patient);
            }
            cb_hospital.Items.Add("Да");
            cb_hospital.Items.Add("Нет");

            string[] speciality = dbconn.selectFrom("Speciality", "Specialties");
            foreach(string s in speciality)
            {
                cb_directions.Items.Add(s);
            }
        }
        private void bn_exit_Click(object sender, RoutedEventArgs e)
        {
            wpf_menu wpfmenu = new wpf_menu(identity);
            wpfmenu.Show();
            this.Close();
        }

        private void bn_save_Click(object sender, RoutedEventArgs e)
        {
            if (dbconn.saveAdmission(cb_policyNumber.Text, date, tb_admissionTime.Text, identity, tb_symptoms.Text, tb_analyzes.Text, tb_diagnosis.Text, tb_instructions.Text, cb_hospital.Text, tb_term.Text))
            {
                MessageBox.Show("Данные успешно сохранены", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Проверьте интернет подключение", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bn_detalis_Click(object sender, RoutedEventArgs e)
        {
            wpf_patientDetalis wpfpatientdetalis = new wpf_patientDetalis(identity);
            wpfpatientdetalis.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] speciality = dbconn.selectFrom("Speciality", "Specialties");
            for (int i=0; i < speciality.Length; i++)
            {
                specialties.Add(speciality[i], Convert.ToString(i));
            }
            dbconn.addDirections(cb_policyNumber.SelectedValue.ToString(), specialties[cb_directions.SelectedValue.ToString()]);

        }
    }
}
