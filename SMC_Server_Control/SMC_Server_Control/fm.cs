using System;
using System.Threading;
using System.Windows.Forms;

namespace SMC_Server_Control
{
    public partial class fm : Form
    {

        /*  CONSTS  */
        private const string DATABASE_NAME = "mscdb";
        private int rowsCountLoaded = 0;
        DBConnect connect;

        public fm()
        {
            InitializeComponent();
            dgv_table.CellValueChanged += changedValueInTable;
        }

        void connectToDB()
        {
            statusLabel.Text = "Соединение устанавливается...";
            connect = new DBConnect(DATABASE_NAME, tb_ipAddress.Text, dgv_table);
            statusLabel.Text = "Соединение успешно установлено";
        }

        private void cb_local_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_local.Checked)
            {
                tb_ipAddress.Text = "127.0.0.1";
                tb_ipAddress.ReadOnly = true;
            }
            else
            {
                tb_ipAddress.Text = "";
                tb_ipAddress.ReadOnly = false;
            }
        }

        private void bt_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_ipAddress.Text.Length > 0)
                {
                    statusLabel.Text = "Установка соединения...";
                    connectToDB();
                }
                else
                {
                    statusLabel.Text = "Ошибка подключения к базе данных! Не заполнены все поля!";
                    MessageBox.Show("Сначала заполните все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                statusLabel.Text = "Базы данных не найдено!";
                if (tb_ipAddress.Text == "127.0.0.1")
                {     
                    var response = MessageBox.Show("Похоже такой базы данных не существует... Вы хотите создать новую БД?", "Ошибка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if(response == DialogResult.OK)
                    {
                        setupNewDB();
                    }
                }
                else
                {
                    var response = MessageBox.Show("Похоже такой базы данных не существует... К сожалению, создать БД на удалённом сервере нельзя :с", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void setupNewDB()
        {
            try
            {
                statusLabel.Text = "Инициализация новой базы данных...";
                connect = new DBConnect(DATABASE_NAME);  
                statusLabel.Text = "Успешно!";
                MessageBox.Show("База данных успешно создана, выполните переподключение...", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception error)
            {
                statusLabel.Text = $"Ошибка при создании базы данных: {error.Message}";
            }
        }
        private void bt_execute_Click(object sender, EventArgs e)
        {
            try
            {
                statusLabel.Text = "Выполнение пользовательского запроса...";
                connect.customRequest(tb_customRequest.Text);

            } catch (NullReferenceException)
            {
                statusLabel.Text = "Ошибка! Отсутствует подключение...";
                MessageBox.Show("Вы не подключены к базе данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } catch (Exception error)
            {
                statusLabel.Text = "Ошибка!";
                MessageBox.Show(error.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_tableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {    
                connect.reloadInfo(cb_tableName.Text);
                statusLabel.Text = $"Список {cb_tableName.Text} загружен, отображается {dgv_table.RowCount - 1} записей";
                rowsCountLoaded = dgv_table.RowCount;
            }
            catch (NullReferenceException)
            {
                statusLabel.Text = "Ошибка! Отсутствует подключение к базе данных!";
                MessageBox.Show("Вы не подключены к базе данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void changedValueInTable(object sender, EventArgs e)
        {
            if (rowsCountLoaded > 1 && rowsCountLoaded - 1 != dgv_table.CurrentRow.Index)
            {
                try
                {
                    switch (cb_tableName.Text)
                    {
                        case "Doctors":
                            connect.updateValue_Doctors(dgv_table.CurrentCell.Value.ToString(), dgv_table.Columns[dgv_table.CurrentCell.ColumnIndex].Name, dgv_table.Rows[dgv_table.CurrentCell.RowIndex].Cells[6].Value.ToString());
                            break;
                        case "Appointments":
                            MessageBox.Show("Нельзя обновить информацию о записи к врачу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case "Polyclinics":
                            connect.updateValue_Polyclinics(dgv_table.CurrentCell.Value.ToString(), dgv_table.Columns[dgv_table.CurrentCell.ColumnIndex].Name, dgv_table.Rows[dgv_table.CurrentCell.RowIndex].Cells[0].Value.ToString());
                            break;
                        case "Patients":
                            connect.updateValue_Patients(dgv_table.CurrentCell.Value.ToString(), dgv_table.Columns[dgv_table.CurrentCell.ColumnIndex].Name, dgv_table.Rows[dgv_table.CurrentCell.RowIndex].Cells[4].Value.ToString());
                            break;
                        default:
                            throw new Exception("Данное поле изменить нельзя!");
                    }
                    statusLabel.Text = "Запись успешно изменена";
                }
                catch (Exception error)
                {
                    statusLabel.Text = "Ошибка при изменении записи";
                    MessageBox.Show(error.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bt_addNewRow_Click(object sender, EventArgs e)
        {
            try
            {
                string[] values = new string[dgv_table.ColumnCount];
                for(int i = 0; i < values.Length; i++)
                {
                    values[i] = dgv_table.Rows[dgv_table.NewRowIndex - 1].Cells[i].Value.ToString();

                    if(values[i] == "")
                    {
                        throw new Exception("Заполните все поля!");
                    }
                }

                switch (cb_tableName.Text)
                {
                    case "Doctors":
                        connect.createValue_Doctors(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10]);
                        break;
                    case "Appointments":
                        connect.createValue_Appointments(values[0], values[1], values[2], values[3]);
                        break;
                    case "Polyclinics":
                        connect.createValue_Polyclinics(values[0], values[1]);
                        break;
                    case "Patients":
                        connect.createValue_Patients(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
                        break;
                    case "Schedule":
                        connect.createValue_Schedule(values[0], values[1], values[2], values[3], values[4]);
                            break;
                    case "Specialties":
                        connect.createValue_Specialties(values[0]);
                        break;
                    case "Directions":
                        connect.createValue_Directions(values[0], values[1]);
                        break;
                    default:
                        throw new Exception("Данное поле нельзя добавить!");
                }
                statusLabel.Text = "Запись успешно создана";
            } catch(Exception error)
            {
                statusLabel.Text = "Ошибка при создании записи";
                MessageBox.Show(error.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                try
                {
                    switch (cb_tableName.Text)
                    {
                        case "Doctors":
                            connect.deleteValue_Doctors(dgv_table.CurrentRow.Cells[6].Value.ToString());
                            break;
                        case "Appointments":
                            connect.deleteValue_Appoinments(dgv_table.CurrentRow.Cells[0].Value.ToString(), dgv_table.CurrentRow.Cells[1].Value.ToString(), dgv_table.CurrentRow.Cells[2].Value.ToString());
                            break;
                        case "Polyclinics":
                            connect.deleteValue_Polyclinics(dgv_table.CurrentRow.Cells[0].Value.ToString());
                            break;
                        case "Patients":
                            connect.deleteValue_Patients(dgv_table.CurrentRow.Cells[5].Value.ToString());
                            break;
                        case "Schedule":
                            connect.deleteValue_Schedule(dgv_table.CurrentRow.Cells[0].Value.ToString(), dgv_table.CurrentRow.Cells[1].Value.ToString(), dgv_table.CurrentRow.Cells[2].Value.ToString(), dgv_table.CurrentRow.Cells[3].Value.ToString());
                            break;
                        case "Specialties":
                            connect.deleteValue_Specialties(dgv_table.CurrentRow.Cells[0].Value.ToString());
                            break;
                        case "Directions":
                            connect.deleteValue_Directions(dgv_table.CurrentRow.Cells[0].Value.ToString(), dgv_table.CurrentRow.Cells[1].Value.ToString());
                            break;
                        default:
                            throw new Exception("Данное поле запрещено удалять!");
                    }
                    statusLabel.Text = "Запись успешно удалена";
                    connect.reloadInfo(cb_tableName.Text);
                }
                catch (Exception error)
                {
                    statusLabel.Text = "Ошибка при удалении записи";
                    MessageBox.Show(error.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
