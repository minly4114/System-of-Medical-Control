using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;

namespace SMC_Client_Expanded
{
    class DB_Connect
    {
        MySqlConnectionStringBuilder builder; // Билдер для настройки подключения
        MySqlConnection conn; // Соединение

        public DB_Connect()
        {
            builder = new MySqlConnectionStringBuilder();
            conn = new MySqlConnection();
            builder.Database = "mscDB"; // Сюда надо записать правильные значения потом
            builder.UserID = "root";
            builder.Password = "";
            builder.Server = "localhost";
            conn.ConnectionString = builder.GetConnectionString(true);
            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {

            }
        }
        public void addDirections(string PolicyNumber, string DoctorIdentity)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"INSERT INTO Directions (DoctorIdentity, PolicyNumber) values('{DoctorIdentity}', '{PolicyNumber}')";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (MySqlException e)
            {

            }
        }
        public string[] selectFrom(string column, string tableName)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"SELECT {column} FROM {tableName};";
                    MySqlDataReader reader = command.ExecuteReader();
                    
                    List<string> list_result = new List<string>();

                    while (reader.Read())
                    {
                        TextReader tr = reader.GetTextReader(0);
                        list_result.Add(tr.ReadLine());
                    }
                    reader.Close();
                    string[] result = list_result.ToArray();
                    return result;
                }
            }
         catch (MySqlException e)
         {
            return null;
         }
        }
        public string[] selectFromWhere(string columnSearch, string tablename, string column, string meaning)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"SELECT {columnSearch} FROM {tablename} WHERE {column} = '{meaning}';";
                    MySqlDataReader reader = command.ExecuteReader();
                    List<string> list_result = new List<string>();

                    while (reader.Read())
                    {
                        TextReader tr = reader.GetTextReader(0);
                        list_result.Add(tr.ReadLine());
                    }
                    reader.Close();
                    return list_result.ToArray();
                }
                
            }
            catch (MySqlException e)
            {
                return null;
            }
        }
        public string[] selectFromWhereTwo(string columnSearch, string tablename,string column1, string meaning1,  string column2, string meaning2)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"SELECT {columnSearch} FROM {tablename} WHERE {column1} = '{meaning1}' AND {column2} = '{meaning2}';";
                    MySqlDataReader reader = command.ExecuteReader();
                    List<string> list_result = new List<string>();

                    while (reader.Read())
                    {
                        TextReader tr = reader.GetTextReader(0);
                        list_result.Add(tr.ReadLine());
                    }
                    reader.Close();
                    return list_result.ToArray();
                }
            }
            catch(MySqlException e)
            {
                return null;
            }
        }
        public void addAccountDoctor(string LastName, string FirstName, string MiddleName, string BirthdayDate, string Post, string Priority, string Identity, string Password, string PasportInfo, string PolyclinicName) // Добавление аккаунта
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"INSERT INTO Doctors (LastName, FirstName, MiddleName, BirthdayDate, Post, Priority, Identity, Password, PasportInfo, PolyclinicName, Confirmation) values('{LastName}', '{FirstName}', '{MiddleName}', '{BirthdayDate}', '{Post}', '{Priority}', '{Identity}', '{Password}', '{PasportInfo}', '{PolyclinicName}', '0')";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (MySqlException e)
            {

            }
        }
        public void addAccountPatient(string LastName, string FirstName, string MiddleName, string BirthdayDate, string PolicyNumber, string PasportInfo, string PoliclinicName, string Phone) // Добавление аккаунта
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"INSERT INTO Patients (LastName, FirstName, MiddleName, BirthdayDate, PolicyNumber, PasportInfo, PolyclinicName, Phone) values('{LastName}', '{FirstName}', '{MiddleName}', '{BirthdayDate}', '{PolicyNumber}', '{PasportInfo}', '{PoliclinicName}', '{Phone}')";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (MySqlException e)
            {

            }
        }
        public string choicetime(string policy, string identity, string date)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"SELECT AppointmentTime FROM Appointments WHERE PolicyNumber = '{policy}' AND AppointmentDate = '{date}' AND DoctorIdentity = '{identity}';";
                    MySqlDataReader reader = command.ExecuteReader();
                    string result = "";
                    while (reader.Read())
                    {
                        result = reader.GetValue(0).ToString();
                    }
                    reader.Close();
                    return result;

                }
            }
            catch (MySqlException e)
            {
                return null;
            }
        }
        public string takeName(string identity)
        {
            string[] lastName = selectFromWhere("LastName", "Patients", "PolicyNumber", identity);
            string[] firstName = selectFromWhere("FirstName", "Patients", "PolicyNumber", identity);
            string[] middleName = selectFromWhere("MiddleName", "Patients", "PolicyNumber", identity);
            
            string name = "";
            if((lastName.Length>0) && (firstName.Length>0) && (middleName.Length>0))
            {
                name = lastName[0] + " " + firstName[0] + " " + middleName[0];
            }
            return name;
        }
        public bool saveAdmission(string PolicyNumber, string AdmissionDate, string AdmissionTime, string DoctorIdentity, string Symptoms, string Analyzes, string Diagnosis, string Instructions, string Hospital, string Term)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"INSERT INTO Admission (PolicyNumber, AdmissionDate, AdmissionTime, DoctorIdentity, Symptoms, Analyzes, Diagnosis, Instructions, Hospital, Term) values('{PolicyNumber}', '{AdmissionDate}', '{AdmissionTime}', '{DoctorIdentity}', '{Symptoms}', '{Analyzes}', '{Diagnosis}', '{Instructions}', '{Hospital}', '{Term}')";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
        public string[] takeSpecialistName(string post)
        {
            try
            {
                string[] result;
                string[] lastname;
                string[] firstname;
                string[] middlename;
                lastname = selectFromWhere("LastName", "Doctors", "Post", post);
                firstname = selectFromWhere("FirstName", "Doctors", "Post", post);
                middlename = selectFromWhere("MiddleName", "Doctors", "Post", post);
                result = new string[firstname.Length];
                for (int i = 0; i < firstname.Length; i++)
                {
                    result[i] = lastname[i] + " " + firstname[i] + " " + middlename[i];
                }
                return result;
            }
            catch (MySqlException e)
            {
                return null;
            }
        }

    }
}
