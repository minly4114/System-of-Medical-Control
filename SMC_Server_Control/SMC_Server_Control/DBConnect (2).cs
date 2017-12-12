﻿using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace SMC_Server_Control
{
    class DBConnect
    {

        #region SETUP_REQUEST
        private string[] setupArray = new string[4] {  // Querry setup for new DB
            "CREATE TABLE Doctors(LastName VARCHAR(20) NOT NULL, FirstName VARCHAR(20) NOT NULL, MiddleName VARCHAR(20) NOT NULL, BirthdayDate VARCHAR(20) NOT NULL, Post VARCHAR(2) NOT NULL, Priority VARCHAR(1) NOT NULL, Identity VARCHAR(12) NOT NULL, Password VARCHAR(20) NOT NULL, PasportInfo VARCHAR(60) NOT NULL, PolyclinicName VARCHAR(60) NOT NULL, Confirmation VARCHAR(1) NOT NULL, PRIMARY KEY(Identity, PasportInfo));",
            "CREATE TABLE Patients(LastName VARCHAR(20) NOT NULL, FirstName VARCHAR(20) NOT NULL, MiddleName VARCHAR(20) NOT NULL, BirthdayDate VARCHAR(10) NOT NULL, PolicyNumber VARCHAR(12) NOT NULL, PasportInfo VARCHAR(60) NOT NULL, PolyclinicName VARCHAR(60) NOT NULL, PRIMARY KEY(PolicyNumber, PasportInfo));",
            "CREATE TABLE Polyclinics(PolyclinicName VARCHAR(60) NOT NULL, Address VARCHAR(100) NOT NULL, PRIMARY KEY(PolyclinicName));",
            "CREATE TABLE Appointments(PolicyNumber VARCHAR(12) NOT NULL, AppointmentDate VARCHAR(20) NOT NULL, AppointmentTime VARCHAR(5) NOT NULL, DoctorIdentity VARCHAR(12) NOT NULL);"};
        #endregion

        private string DATABASE_NAME;
        MySqlConnection con;
        DataGridView table;

        #region CONSTRUCTS
        public DBConnect(string database) // Using for setup new DB
        {
            MySqlConnectionStringBuilder conBuilder = new MySqlConnectionStringBuilder();
            con = new MySqlConnection();
            DATABASE_NAME = database;
            conBuilder.Server = "localhost";
            conBuilder.UserID = "root";
            con.ConnectionString = conBuilder.ConnectionString;
            con.Open();
            string request = $"CREATE DATABASE {database};";
            MySqlCommand command = new MySqlCommand(request, con);
            command.ExecuteNonQuery();
            command.CommandText = $"USE {DATABASE_NAME};";
            command.ExecuteNonQuery();
            setupNewDB();
            con.Close();
        }

        public DBConnect(string database, string ipAddress, DataGridView table) // Using for connect to current DB
        {
            MySqlConnectionStringBuilder conBuilder = new MySqlConnectionStringBuilder();
            con = new MySqlConnection();
            DATABASE_NAME = database;
            this.table = table;
            conBuilder.Database = database;
            conBuilder.Server = ipAddress;
            conBuilder.UserID = "root";
            con.ConnectionString = conBuilder.ConnectionString;
            con.Open();
        }
        #endregion

        #region REQUESTS FOR DB
        public void customRequest(string request) // Custom request! Need try catch!
        {
            using (MySqlCommand command = new MySqlCommand(request, con))
            {
                command.ExecuteNonQuery();
            }
        }
        public void createValue_Doctors(string LastName, string FirstName, string MiddleName, string BirthdayDate, string Post, string Priority, string Identity, string Password, string PasportInfo, string PolyclinicName, string Confirmation)
        {
            using (MySqlCommand command = new MySqlCommand("", con))
            {
                command.CommandText = $"INSERT INTO doctors (LastName, FirstName, MiddleName, BirthdayDate, Post, Priority, Identity, Password, PasportInfo, PolyclinicName, Confirmation) VALUES('{LastName}', '{FirstName}', '{MiddleName}', '{BirthdayDate}', '{Post}', '{Priority}', '{Identity}', '{Password}', '{PasportInfo}', '{PolyclinicName}', '{Confirmation}');";
                command.ExecuteNonQuery();
            }
        }
        public void createValue_Patients(string LastName, string FirstName, string MiddleName, string BirthdayDate, string PolicyNumber, string PasportInfo, string PolyclinicName)
        {
            using (MySqlCommand command = new MySqlCommand("", con))
            {
                command.CommandText = $"INSERT INTO patients (LastName, FirstName, MiddleName, BirthdayDate, PolicyNumber, PasportInfo, PolyclinicName) VALUES('{LastName}', '{FirstName}', '{MiddleName}', '{BirthdayDate}', '{PolicyNumber}', '{PasportInfo}', '{PolyclinicName}');";
                command.ExecuteNonQuery();
            }
        }
        public void createValue_Polyclinics(string PolyclinicName, string Address)
        {
            using (MySqlCommand command = new MySqlCommand("", con))
            {
                command.CommandText = $"INSERT INTO polyclinics (PolyclinicName, Address) VALUES('{PolyclinicName}', '{Address}');";
                command.ExecuteNonQuery();
            }
        }
        public void createValue_Appointments(string PolicyNumber, string AppointmentDate, string AppointmentTime, string DoctorIdentity)
        {
            using (MySqlCommand command = new MySqlCommand("", con))
            {
                command.CommandText = $"INSERT INTO appointments (PolicyNumber, AppointmentDate, AppointmentTime, DoctorIdentity) VALUES('{PolicyNumber}', '{AppointmentDate}', '{AppointmentTime}','{DoctorIdentity}');";
                command.ExecuteNonQuery();
            }
        }
        private void setupNewDB() // Using for create tables in current DB
        {
            using (MySqlCommand command = new MySqlCommand("", con))
            {
                foreach (string querry in setupArray)
                {
                    command.CommandText = querry;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void reloadInfo(string TableName)
        {
            using (MySqlCommand command = new MySqlCommand("", con))
            {
                command.CommandText = $"SELECT * FROM {TableName}";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                table.DataSource = dataTable;
            }
        }
        public void updateValue_Doctors(string value, string valueName, string Identity)
        {
            using (MySqlCommand command = new MySqlCommand($"UPDATE doctors SET {valueName} = '{value}' WHERE identity = '{Identity}';", con))
            {
                command.ExecuteNonQuery();
            }
        }
        public void updateValue_Polyclinics(string value, string valueName, string PolyclinicName)
        {
            using(MySqlCommand command = new MySqlCommand($"UPDATE polyclinics SET {valueName} = '{value}' WHERE PolyclinicName = '{PolyclinicName}';", con))
            {
                command.ExecuteNonQuery();
            }
        }
        public void updateValue_Patients(string value, string valueName, string PolicyNumber)
        {
            using(MySqlCommand command = new MySqlCommand($"UPDATE patients SET {valueName} = '{value}' WHERE PolicyNumber = '{PolicyNumber}';", con))
            {
                command.ExecuteNonQuery();
            }
        }
        public void deleteValue_Doctors(string Identity)
        {
            using (MySqlCommand command = new MySqlCommand($"DELETE FROM doctors WHERE identity = '{Identity}';", con))
            {
                command.ExecuteNonQuery();
            }
        }
        public void deleteValue_Polyclinics(string PolyclinicName)
        {
            using (MySqlCommand command = new MySqlCommand($"DELETE FROM polyclinics WHERE PolyclinicName = '{PolyclinicName}';", con))
            {
                command.ExecuteNonQuery();
            }
        }
        public void deleteValue_Patients(string PolicyNumber)
        {
            using (MySqlCommand command = new MySqlCommand($"DELETE FROM patients WHERE PolicyNumber = '{PolicyNumber}';", con))
            {
                command.ExecuteNonQuery();
            }
        }
        public void deleteValue_Appoinments(string PolicyNumber, string AppointmentDate, string DoctorIdentity)
        {
            using (MySqlCommand command = new MySqlCommand($"DELETE FROM appointments WHERE PolicyNumber = '{PolicyNumber}' AND AppointmentDate = '{AppointmentDate}' AND DoctorIdentity = '{DoctorIdentity}';", con))
            {
                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}