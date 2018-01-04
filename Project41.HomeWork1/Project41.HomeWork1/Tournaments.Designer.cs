namespace Project41.HomeWork1
{
    partial class Tournaments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBankroll = new System.Windows.Forms.TextBox();
            this.btnHands = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Started = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buy_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpeedEnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(162, 221);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "When did the session begin?";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bankroll in begin of session: ";
            // 
            // textBoxBankroll
            // 
            this.textBoxBankroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxBankroll.Location = new System.Drawing.Point(162, 247);
            this.textBoxBankroll.Name = "textBoxBankroll";
            this.textBoxBankroll.Size = new System.Drawing.Size(92, 20);
            this.textBoxBankroll.TabIndex = 10;
            this.textBoxBankroll.Text = "0,00";
            this.textBoxBankroll.TextChanged += new System.EventHandler(this.textBoxBankroll_TextChanged);
            // 
            // btnHands
            // 
            this.btnHands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHands.Location = new System.Drawing.Point(456, 221);
            this.btnHands.Name = "btnHands";
            this.btnHands.Size = new System.Drawing.Size(136, 35);
            this.btnHands.TabIndex = 11;
            this.btnHands.Text = "Start getting hands";
            this.btnHands.UseVisualStyleBackColor = true;
            this.btnHands.Click += new System.EventHandler(this.btnHands_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrent.Location = new System.Drawing.Point(14, 270);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(336, 20);
            this.lblCurrent.TabIndex = 12;
            this.lblCurrent.Text = "Now you have $0.00 and $0.00 in tournaments";
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.Location = new System.Drawing.Point(494, 262);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(98, 25);
            this.btnPath.TabIndex = 13;
            this.btnPath.Text = "Change directory";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // Data
            // 
            this.Data.AllowUserToAddRows = false;
            this.Data.AllowUserToDeleteRows = false;
            this.Data.AllowUserToResizeRows = false;
            this.Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Started,
            this.Buy_in,
            this.SpeedEnum,
            this.Players,
            this.Duration,
            this.Place});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.Data.Location = new System.Drawing.Point(12, 12);
            this.Data.MultiSelect = false;
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.RowHeadersVisible = false;
            this.Data.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Data.Size = new System.Drawing.Size(580, 203);
            this.Data.TabIndex = 14;
            // 
            // Id
            // 
            this.Id.HeaderText = "#";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Started
            // 
            this.Started.FillWeight = 143.1051F;
            this.Started.HeaderText = "Started";
            this.Started.MinimumWidth = 30;
            this.Started.Name = "Started";
            this.Started.ReadOnly = true;
            // 
            // Buy_in
            // 
            this.Buy_in.FillWeight = 78.43691F;
            this.Buy_in.HeaderText = "Buy-in";
            this.Buy_in.MinimumWidth = 30;
            this.Buy_in.Name = "Buy_in";
            this.Buy_in.ReadOnly = true;
            // 
            // SpeedEnum
            // 
            this.SpeedEnum.FillWeight = 143.1472F;
            this.SpeedEnum.HeaderText = "Speed";
            this.SpeedEnum.MinimumWidth = 30;
            this.SpeedEnum.Name = "SpeedEnum";
            this.SpeedEnum.ReadOnly = true;
            // 
            // Players
            // 
            this.Players.HeaderText = "Players";
            this.Players.Name = "Players";
            this.Players.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.FillWeight = 78.43691F;
            this.Duration.HeaderText = "Duration";
            this.Duration.MinimumWidth = 30;
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            // 
            // Place
            // 
            this.Place.FillWeight = 78.43691F;
            this.Place.HeaderText = "Place";
            this.Place.MinimumWidth = 30;
            this.Place.Name = "Place";
            this.Place.ReadOnly = true;
            // 
            // Tournaments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 299);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.btnHands);
            this.Controls.Add(this.textBoxBankroll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.MinimumSize = new System.Drawing.Size(530, 250);
            this.Name = "Tournaments";
            this.Text = "Tournaments";
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBankroll;
        private System.Windows.Forms.Button btnHands;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.DataGridView Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Started;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buy_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedEnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
    }
}