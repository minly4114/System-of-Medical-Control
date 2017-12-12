using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;

namespace SMC_Client_Expanded
{
    class DB_Connect
    {
        MySqlConnectionStringBuilder builder; // Билдер для настройки подключения
        MySqlConnection conn; // Соединение
        List<string> deleteValues;
        List<string> list_result;

        public DB_Connect()
        {
            builder = new MySqlConnectionStringBuilder();
            conn = new MySqlConnection();
            builder.Database = "mscDB"; // Сюда надо записать правильные значения потом
            builder.UserID = "root";
            builder.Password = "";
            builder.Server = "localhost";
            conn.ConnectionString = builder.GetConnectionString(true);
            conn.Open();
        }
        public void deleteShedule(string DoctorIdentity, string WorkingHours, string DayOfWork)
        {
            using (MySqlCommand command = new MySqlCommand("", conn))
            {
                command.CommandText = $"DELETE FROM Schedule WHERE DoctorIdentity = '{DoctorIdentity}' AND WorkingHours = '{WorkingHours}' AND DayOfWork = '{DayOfWork}';";
                command.ExecuteNonQuery();
            }
        }
        public void insertAppointments(string DoctorIdentity, string PolicyNumber,string AppointmentDate,string AppointmentTime)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"INSERT INTO Appointments (DoctorIdentity, PolicyNumber, AppointmentDate, AppointmentTime) values('{DoctorIdentity}', '{PolicyNumber}', '{AppointmentDate}', '{AppointmentTime}');";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException e)
            {

            }
        }
        public string[] getAppointments(string PolicyNumber)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"SELECT * FROM Appointments WHERE PolicyNumber = '{PolicyNumber}';";
                    MySqlDataReader reader = command.ExecuteReader();
                    list_result = new List<string>();
                    deleteValues = new List<string>();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (i == 3)
                            {
                                TextReader tr = reader.GetTextReader(i);
                                string s = tr.ReadLine();
                                list_result.Add(s);
                                deleteValues.Add(s);
                            }
                            else if(i == 0)
                            {
                                
                            }
                            else
                            {
                                TextReader tr = reader.GetTextReader(i);
                                string s = tr.ReadLine();
                                list_result.Add(s);
                                deleteValues.Add(s);
                            }
                        }
                        list_result.Add("|");
                        deleteValues.Add("|");
                    }
                    reader.Close();
                    return list_result.ToArray();
                }

            }
            catch
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
            catch(Exception er)
            {
                return null;
            }
        }
        public string[] selectFromWhereTwo(string columnSearch, string tablename, string column1, string meaning1, string column2, string meaning2)
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
            catch
            {
                return null;
            }
        }
        public void deleteAppointment(int index, string id)
        {
            List<string> list = new List<string>();
            int temp = 0;
            foreach(string s in deleteValues)
            {
                if (s == "|")
                {
                    temp++;
                }
                else if (temp == index)
                {
                    list.Add(s);
                }
            }
            string[] result = list.ToArray();
            using (MySqlCommand command = new MySqlCommand("", conn))
            {
                command.CommandText = $"DELETE FROM Appointments WHERE DoctorIdentity = '{result[2]}' AND AppointmentDate = '{result[0]}' AND AppointmentTime = '{result[1]}' AND PolicyNumber = '{id}';";
                command.ExecuteNonQuery();
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
        public string takeNameDoctors(string identity)
        {
            string[] lastName = selectFromWhere("LastName", "Doctors", "Identity", identity);
            string[] firstName = selectFromWhere("FirstName", "Doctors", "Identity", identity);
            string[] middleName = selectFromWhere("MiddleName", "Doctors", "Identity", identity);

            string name = "";
            if ((lastName.Length > 0) && (firstName.Length > 0) && (middleName.Length > 0))
            {
                name = lastName[0] + " " + firstName[0] + " " + middleName[0];
            }
            return name;
        }
        public string[] getPatientInfo(string id ,string birtdaydate)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("", conn))
                {
                    command.CommandText = $"SELECT * FROM Patients WHERE PolicyNumber = '{id}' AND BirthdayDate = '{birtdaydate}';";
                    MySqlDataReader reader = command.ExecuteReader();
                    List<string> list_result = new List<string>();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            TextReader tr = reader.GetTextReader(i);
                            list_result.Add(tr.ReadLine());
                        }
                    }
                    reader.Close();
                    return list_result.ToArray();
                }
                
            }
            catch
            {
                return null;
            }
        }
        public string[] getDirectionsList(string id)
        {
            using (MySqlCommand command = new MySqlCommand("", conn))
            {
                command.CommandText = $"SELECT DoctorIdentity FROM Directions WHERE PolicyNumber = '{id}';";
                MySqlDataReader reader = command.ExecuteReader();
                List<string> list_result = new List<string>();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        TextReader tr = reader.GetTextReader(i);
                        list_result.Add(tr.ReadLine());
                    }
                }
                reader.Close();
                return list_result.ToArray();
            }
        }
        public string[] getAdmissionInfo()
        {
            return null;
        }

        public string getDocSpeciality(string id)
        {
            using (MySqlCommand command = new MySqlCommand("", conn))
            {
                command.CommandText = $"SELECT Post FROM Doctors WHERE Identity = '{id}';";
                MySqlDataReader reader = command.ExecuteReader();
                string result = "";

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        TextReader tr = reader.GetTextReader(i);
                        result = tr.ReadLine();
                    }
                }
                reader.Close();
                return result;
            }
        }
        public string[] getSpecialties()
        {
            using (MySqlCommand command = new MySqlCommand("", conn))
            {
                command.CommandText = $"SELECT * FROM Specialties;";
                MySqlDataReader reader = command.ExecuteReader();
                List<string> list_result = new List<string>();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        TextReader tr = reader.GetTextReader(i);
                        list_result.Add(tr.ReadLine());
                    }
                }
                reader.Close();
                return list_result.ToArray();
            }
        }
        public string[] getDoctors(string date, string post)
        {
            using (MySqlCommand command = new MySqlCommand("", conn))
            {
                command.CommandText = $"SELECT * FROM Schedule WHERE Post = '{post}' AND DayOfWork = '{date}';";
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

        public void addAccount(string LastName, string FirstName, string MiddleName, string BirthdayDate, string Post, string Priority, string Identity, string Password, string PasportInfo, string PolyclinicName) // Добавление аккаунта
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
            catch
            {

            }
        }

    }
}
