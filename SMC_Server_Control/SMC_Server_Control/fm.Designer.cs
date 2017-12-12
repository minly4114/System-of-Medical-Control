namespace SMC_Server_Control
{
    partial class fm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gp_dbInfo = new System.Windows.Forms.GroupBox();
            this.bt_Connect = new System.Windows.Forms.Button();
            this.cb_local = new System.Windows.Forms.CheckBox();
            this.lb_3 = new System.Windows.Forms.Label();
            this.tb_ipAddress = new System.Windows.Forms.TextBox();
            this.gp_customRequest = new System.Windows.Forms.GroupBox();
            this.bt_execute = new System.Windows.Forms.Button();
            this.tb_customRequest = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_addNewRow = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.cb_tableName = new System.Windows.Forms.ComboBox();
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.gp_dbInfo.SuspendLayout();
            this.gp_customRequest.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.SuspendLayout();
            // 
            // gp_dbInfo
            // 
            this.gp_dbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_dbInfo.Controls.Add(this.bt_Connect);
            this.gp_dbInfo.Controls.Add(this.cb_local);
            this.gp_dbInfo.Controls.Add(this.lb_3);
            this.gp_dbInfo.Controls.Add(this.tb_ipAddress);
            this.gp_dbInfo.Location = new System.Drawing.Point(9, 10);
            this.gp_dbInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gp_dbInfo.Name = "gp_dbInfo";
            this.gp_dbInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gp_dbInfo.Size = new System.Drawing.Size(989, 69);
            this.gp_dbInfo.TabIndex = 0;
            this.gp_dbInfo.TabStop = false;
            this.gp_dbInfo.Text = "Информация о БД";
            // 
            // bt_Connect
            // 
            this.bt_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Connect.Location = new System.Drawing.Point(877, 35);
            this.bt_Connect.Margin = new System.Windows.Forms.Padding(2);
            this.bt_Connect.Name = "bt_Connect";
            this.bt_Connect.Size = new System.Drawing.Size(108, 27);
            this.bt_Connect.TabIndex = 9;
            this.bt_Connect.Text = "Присоединиться";
            this.bt_Connect.UseVisualStyleBackColor = true;
            this.bt_Connect.Click += new System.EventHandler(this.bt_Connect_Click);
            // 
            // cb_local
            // 
            this.cb_local.AutoSize = true;
            this.cb_local.Location = new System.Drawing.Point(30, 20);
            this.cb_local.Margin = new System.Windows.Forms.Padding(2);
            this.cb_local.Name = "cb_local";
            this.cb_local.Size = new System.Drawing.Size(101, 17);
            this.cb_local.TabIndex = 8;
            this.cb_local.Text = "Локальная БД";
            this.cb_local.UseVisualStyleBackColor = true;
            this.cb_local.CheckedChanged += new System.EventHandler(this.cb_local_CheckedChanged);
            // 
            // lb_3
            // 
            this.lb_3.AutoSize = true;
            this.lb_3.Location = new System.Drawing.Point(10, 20);
            this.lb_3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_3.Name = "lb_3";
            this.lb_3.Size = new System.Drawing.Size(17, 13);
            this.lb_3.TabIndex = 5;
            this.lb_3.Text = "IP";
            // 
            // tb_ipAddress
            // 
            this.tb_ipAddress.Location = new System.Drawing.Point(13, 39);
            this.tb_ipAddress.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ipAddress.Name = "tb_ipAddress";
            this.tb_ipAddress.Size = new System.Drawing.Size(113, 20);
            this.tb_ipAddress.TabIndex = 4;
            // 
            // gp_customRequest
            // 
            this.gp_customRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_customRequest.Controls.Add(this.bt_execute);
            this.gp_customRequest.Controls.Add(this.tb_customRequest);
            this.gp_customRequest.Location = new System.Drawing.Point(9, 76);
            this.gp_customRequest.Margin = new System.Windows.Forms.Padding(2);
            this.gp_customRequest.Name = "gp_customRequest";
            this.gp_customRequest.Padding = new System.Windows.Forms.Padding(2);
            this.gp_customRequest.Size = new System.Drawing.Size(989, 44);
            this.gp_customRequest.TabIndex = 1;
            this.gp_customRequest.TabStop = false;
            this.gp_customRequest.Text = "Пользовательский запрос в БД";
            // 
            // bt_execute
            // 
            this.bt_execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_execute.Location = new System.Drawing.Point(877, 15);
            this.bt_execute.Margin = new System.Windows.Forms.Padding(2);
            this.bt_execute.Name = "bt_execute";
            this.bt_execute.Size = new System.Drawing.Size(108, 22);
            this.bt_execute.TabIndex = 1;
            this.bt_execute.Text = "Выполнить";
            this.bt_execute.UseVisualStyleBackColor = true;
            this.bt_execute.Click += new System.EventHandler(this.bt_execute_Click);
            // 
            // tb_customRequest
            // 
            this.tb_customRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_customRequest.Location = new System.Drawing.Point(13, 17);
            this.tb_customRequest.Margin = new System.Windows.Forms.Padding(2);
            this.tb_customRequest.Name = "tb_customRequest";
            this.tb_customRequest.Size = new System.Drawing.Size(860, 20);
            this.tb_customRequest.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bt_delete);
            this.groupBox1.Controls.Add(this.bt_addNewRow);
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Controls.Add(this.cb_tableName);
            this.groupBox1.Controls.Add(this.dgv_table);
            this.groupBox1.Location = new System.Drawing.Point(9, 116);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(989, 397);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "База данных";
            // 
            // bt_delete
            // 
            this.bt_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_delete.Location = new System.Drawing.Point(764, 17);
            this.bt_delete.Margin = new System.Windows.Forms.Padding(2);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(108, 22);
            this.bt_delete.TabIndex = 5;
            this.bt_delete.Text = "Удалить запись";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_addNewRow
            // 
            this.bt_addNewRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_addNewRow.Location = new System.Drawing.Point(877, 17);
            this.bt_addNewRow.Margin = new System.Windows.Forms.Padding(2);
            this.bt_addNewRow.Name = "bt_addNewRow";
            this.bt_addNewRow.Size = new System.Drawing.Size(108, 22);
            this.bt_addNewRow.TabIndex = 2;
            this.bt_addNewRow.Text = "Добавить запись";
            this.bt_addNewRow.UseVisualStyleBackColor = true;
            this.bt_addNewRow.Click += new System.EventHandler(this.bt_addNewRow_Click);
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(2, 373);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.status.Size = new System.Drawing.Size(985, 22);
            this.status.TabIndex = 4;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(151, 17);
            this.statusLabel.Text = "Подключение отсутствует";
            // 
            // cb_tableName
            // 
            this.cb_tableName.FormattingEnabled = true;
            this.cb_tableName.Items.AddRange(new object[] {
            "Doctors",
            "Appointments",
            "Patients",
            "Polyclinics",
            "Admission",
            "Specialties",
            "Schedule",
            "Directions"});
            this.cb_tableName.Location = new System.Drawing.Point(4, 17);
            this.cb_tableName.Margin = new System.Windows.Forms.Padding(2);
            this.cb_tableName.Name = "cb_tableName";
            this.cb_tableName.Size = new System.Drawing.Size(121, 21);
            this.cb_tableName.TabIndex = 3;
            this.cb_tableName.SelectedIndexChanged += new System.EventHandler(this.cb_tableName_SelectedIndexChanged);
            // 
            // dgv_table
            // 
            this.dgv_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_table.Location = new System.Drawing.Point(4, 41);
            this.dgv_table.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.RowTemplate.Height = 24;
            this.dgv_table.Size = new System.Drawing.Size(980, 331);
            this.dgv_table.TabIndex = 0;
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 523);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gp_customRequest);
            this.Controls.Add(this.gp_dbInfo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gp_dbInfo.ResumeLayout(false);
            this.gp_dbInfo.PerformLayout();
            this.gp_customRequest.ResumeLayout(false);
            this.gp_customRequest.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp_dbInfo;
        private System.Windows.Forms.Label lb_3;
        private System.Windows.Forms.TextBox tb_ipAddress;
        private System.Windows.Forms.CheckBox cb_local;
        private System.Windows.Forms.Button bt_Connect;
        private System.Windows.Forms.GroupBox gp_customRequest;
        private System.Windows.Forms.Button bt_execute;
        private System.Windows.Forms.TextBox tb_customRequest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_table;
        private System.Windows.Forms.ComboBox cb_tableName;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button bt_addNewRow;
        private System.Windows.Forms.Button bt_delete;
    }
}

