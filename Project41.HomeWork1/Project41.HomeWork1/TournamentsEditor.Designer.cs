namespace Project41.HomeWork1
{
    partial class TournamentsEditor
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
            this.lblType = new System.Windows.Forms.Label();
            this.dtPickerStarted = new System.Windows.Forms.DateTimePicker();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblBuy_in = new System.Windows.Forms.Label();
            this.textBuy_in = new System.Windows.Forms.TextBox();
            this.lblFinished = new System.Windows.Forms.Label();
            this.textFinished = new System.Windows.Forms.TextBox();
            this.lblEarnings = new System.Windows.Forms.Label();
            this.textEarnings = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStarted = new System.Windows.Forms.Label();
            this.lblTextBuy_inInputError = new System.Windows.Forms.Label();
            this.lblTextFinishedInputError = new System.Windows.Forms.Label();
            this.lblTextEarningsInputError = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.lblComboBoxTypeInputError = new System.Windows.Forms.Label();
            this.dtPickerDuration = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblType.Location = new System.Drawing.Point(13, 19);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 16);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // dtPickerStarted
            // 
            this.dtPickerStarted.CustomFormat = "dd\'.\'MM\'.\'yyyy HH\':\'mm";
            this.dtPickerStarted.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerStarted.Location = new System.Drawing.Point(115, 49);
            this.dtPickerStarted.Margin = new System.Windows.Forms.Padding(4);
            this.dtPickerStarted.Name = "dtPickerStarted";
            this.dtPickerStarted.RightToLeftLayout = true;
            this.dtPickerStarted.Size = new System.Drawing.Size(204, 22);
            this.dtPickerStarted.TabIndex = 2;
            this.dtPickerStarted.Value = new System.DateTime(2016, 1, 1, 12, 0, 0, 0);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDuration.Location = new System.Drawing.Point(13, 79);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(61, 16);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "Duration:";
            // 
            // lblBuy_in
            // 
            this.lblBuy_in.AutoSize = true;
            this.lblBuy_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBuy_in.Location = new System.Drawing.Point(13, 109);
            this.lblBuy_in.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuy_in.Name = "lblBuy_in";
            this.lblBuy_in.Size = new System.Drawing.Size(48, 16);
            this.lblBuy_in.TabIndex = 0;
            this.lblBuy_in.Text = "Buy-in:";
            // 
            // textBuy_in
            // 
            this.textBuy_in.Location = new System.Drawing.Point(115, 109);
            this.textBuy_in.Margin = new System.Windows.Forms.Padding(4);
            this.textBuy_in.Name = "textBuy_in";
            this.textBuy_in.Size = new System.Drawing.Size(108, 22);
            this.textBuy_in.TabIndex = 1;
            // 
            // lblFinished
            // 
            this.lblFinished.AutoSize = true;
            this.lblFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFinished.Location = new System.Drawing.Point(13, 139);
            this.lblFinished.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(46, 16);
            this.lblFinished.TabIndex = 0;
            this.lblFinished.Text = "Place:";
            // 
            // textFinished
            // 
            this.textFinished.Location = new System.Drawing.Point(115, 139);
            this.textFinished.Margin = new System.Windows.Forms.Padding(4);
            this.textFinished.Name = "textFinished";
            this.textFinished.Size = new System.Drawing.Size(108, 22);
            this.textFinished.TabIndex = 1;
            // 
            // lblEarnings
            // 
            this.lblEarnings.AutoSize = true;
            this.lblEarnings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEarnings.Location = new System.Drawing.Point(13, 169);
            this.lblEarnings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEarnings.Name = "lblEarnings";
            this.lblEarnings.Size = new System.Drawing.Size(64, 16);
            this.lblEarnings.TabIndex = 0;
            this.lblEarnings.Text = "Earnings:";
            // 
            // textEarnings
            // 
            this.textEarnings.Location = new System.Drawing.Point(115, 169);
            this.textEarnings.Margin = new System.Windows.Forms.Padding(4);
            this.textEarnings.Name = "textEarnings";
            this.textEarnings.Size = new System.Drawing.Size(108, 22);
            this.textEarnings.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(16, 199);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(123, 199);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStarted
            // 
            this.lblStarted.AutoSize = true;
            this.lblStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStarted.Location = new System.Drawing.Point(13, 49);
            this.lblStarted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStarted.Name = "lblStarted";
            this.lblStarted.Size = new System.Drawing.Size(54, 16);
            this.lblStarted.TabIndex = 0;
            this.lblStarted.Text = "Started:";
            // 
            // lblTextBuy_inInputError
            // 
            this.lblTextBuy_inInputError.AutoSize = true;
            this.lblTextBuy_inInputError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTextBuy_inInputError.ForeColor = System.Drawing.Color.Red;
            this.lblTextBuy_inInputError.Location = new System.Drawing.Point(98, 109);
            this.lblTextBuy_inInputError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextBuy_inInputError.Name = "lblTextBuy_inInputError";
            this.lblTextBuy_inInputError.Size = new System.Drawing.Size(13, 20);
            this.lblTextBuy_inInputError.TabIndex = 0;
            this.lblTextBuy_inInputError.Text = "!";
            // 
            // lblTextFinishedInputError
            // 
            this.lblTextFinishedInputError.AutoSize = true;
            this.lblTextFinishedInputError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTextFinishedInputError.ForeColor = System.Drawing.Color.Red;
            this.lblTextFinishedInputError.Location = new System.Drawing.Point(98, 139);
            this.lblTextFinishedInputError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextFinishedInputError.Name = "lblTextFinishedInputError";
            this.lblTextFinishedInputError.Size = new System.Drawing.Size(13, 20);
            this.lblTextFinishedInputError.TabIndex = 0;
            this.lblTextFinishedInputError.Text = "!";
            // 
            // lblTextEarningsInputError
            // 
            this.lblTextEarningsInputError.AutoSize = true;
            this.lblTextEarningsInputError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTextEarningsInputError.ForeColor = System.Drawing.Color.Red;
            this.lblTextEarningsInputError.Location = new System.Drawing.Point(98, 169);
            this.lblTextEarningsInputError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextEarningsInputError.Name = "lblTextEarningsInputError";
            this.lblTextEarningsInputError.Size = new System.Drawing.Size(13, 20);
            this.lblTextEarningsInputError.TabIndex = 0;
            this.lblTextEarningsInputError.Text = "!";
            // 
            // comboBoxType
            // 
            this.comboBoxType.AllowDrop = true;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(115, 19);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(204, 24);
            this.comboBoxType.TabIndex = 5;
            // 
            // lblComboBoxTypeInputError
            // 
            this.lblComboBoxTypeInputError.AutoSize = true;
            this.lblComboBoxTypeInputError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblComboBoxTypeInputError.ForeColor = System.Drawing.Color.Red;
            this.lblComboBoxTypeInputError.Location = new System.Drawing.Point(98, 19);
            this.lblComboBoxTypeInputError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComboBoxTypeInputError.Name = "lblComboBoxTypeInputError";
            this.lblComboBoxTypeInputError.Size = new System.Drawing.Size(13, 20);
            this.lblComboBoxTypeInputError.TabIndex = 0;
            this.lblComboBoxTypeInputError.Text = "!";
            // 
            // dtPickerDuration
            // 
            this.dtPickerDuration.CustomFormat = "H\':\'mm";
            this.dtPickerDuration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerDuration.Location = new System.Drawing.Point(115, 79);
            this.dtPickerDuration.Margin = new System.Windows.Forms.Padding(4);
            this.dtPickerDuration.Name = "dtPickerDuration";
            this.dtPickerDuration.RightToLeftLayout = true;
            this.dtPickerDuration.ShowUpDown = true;
            this.dtPickerDuration.Size = new System.Drawing.Size(108, 22);
            this.dtPickerDuration.TabIndex = 2;
            this.dtPickerDuration.Value = new System.DateTime(2016, 8, 30, 0, 0, 0, 0);
            // 
            // TournamentsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 236);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtPickerDuration);
            this.Controls.Add(this.dtPickerStarted);
            this.Controls.Add(this.textEarnings);
            this.Controls.Add(this.textFinished);
            this.Controls.Add(this.textBuy_in);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblEarnings);
            this.Controls.Add(this.lblFinished);
            this.Controls.Add(this.lblBuy_in);
            this.Controls.Add(this.lblStarted);
            this.Controls.Add(this.lblTextEarningsInputError);
            this.Controls.Add(this.lblTextFinishedInputError);
            this.Controls.Add(this.lblTextBuy_inInputError);
            this.Controls.Add(this.lblComboBoxTypeInputError);
            this.Controls.Add(this.lblType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TournamentsEditor";
            this.Text = "Tournaments Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.DateTimePicker dtPickerStarted;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblBuy_in;
        private System.Windows.Forms.TextBox textBuy_in;
        private System.Windows.Forms.Label lblFinished;
        private System.Windows.Forms.TextBox textFinished;
        private System.Windows.Forms.Label lblEarnings;
        private System.Windows.Forms.TextBox textEarnings;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStarted;
        private System.Windows.Forms.Label lblTextBuy_inInputError;
        private System.Windows.Forms.Label lblTextFinishedInputError;
        private System.Windows.Forms.Label lblTextEarningsInputError;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label lblComboBoxTypeInputError;
        private System.Windows.Forms.DateTimePicker dtPickerDuration;
    }
}