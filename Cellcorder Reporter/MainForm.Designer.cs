namespace Cellcorder_Reporter
{
    partial class main_Form
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
            this.csv_TextBox = new System.Windows.Forms.TextBox();
            this.browseForCsv_Button = new System.Windows.Forms.Button();
            this.SelectCsvFolder_label = new System.Windows.Forms.Label();
            this.FileList_groupBox = new System.Windows.Forms.GroupBox();
            this.FileList_DataGrid = new System.Windows.Forms.DataGridView();
            this.ColCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColViewDataButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ButtonExtractData = new System.Windows.Forms.Button();
            this.label_location = new System.Windows.Forms.Label();
            this.label_battery = new System.Windows.Forms.Label();
            this.label_strings = new System.Windows.Forms.Label();
            this.label_datetested = new System.Windows.Forms.Label();
            this.label_cellcount = new System.Windows.Forms.Label();
            this.CellCount_text = new System.Windows.Forms.Label();
            this.Strings_text = new System.Windows.Forms.Label();
            this.dateTested_text = new System.Windows.Forms.Label();
            this.Battery_text = new System.Windows.Forms.Label();
            this.Location_text = new System.Windows.Forms.Label();
            this.datagrid_testResults = new System.Windows.Forms.DataGridView();
            this.col_StringNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CellNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Volts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Resistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Icr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Icr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Icr3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Icr4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressBar_Label = new System.Windows.Forms.Label();
            this.FileList_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileList_DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_testResults)).BeginInit();
            this.SuspendLayout();
            // 
            // csv_TextBox
            // 
            this.csv_TextBox.Location = new System.Drawing.Point(12, 34);
            this.csv_TextBox.Name = "csv_TextBox";
            this.csv_TextBox.ReadOnly = true;
            this.csv_TextBox.Size = new System.Drawing.Size(265, 20);
            this.csv_TextBox.TabIndex = 0;
            // 
            // browseForCsv_Button
            // 
            this.browseForCsv_Button.Location = new System.Drawing.Point(284, 30);
            this.browseForCsv_Button.Name = "browseForCsv_Button";
            this.browseForCsv_Button.Size = new System.Drawing.Size(75, 23);
            this.browseForCsv_Button.TabIndex = 1;
            this.browseForCsv_Button.Text = "Browse";
            this.browseForCsv_Button.UseVisualStyleBackColor = true;
            this.browseForCsv_Button.Click += new System.EventHandler(this.Browse_for_CSV_Button_Click);
            // 
            // SelectCsvFolder_label
            // 
            this.SelectCsvFolder_label.BackColor = System.Drawing.Color.Transparent;
            this.SelectCsvFolder_label.Location = new System.Drawing.Point(12, 18);
            this.SelectCsvFolder_label.Name = "SelectCsvFolder_label";
            this.SelectCsvFolder_label.Size = new System.Drawing.Size(265, 13);
            this.SelectCsvFolder_label.TabIndex = 2;
            this.SelectCsvFolder_label.Text = "Select folder that contains CSV files..";
            // 
            // FileList_groupBox
            // 
            this.FileList_groupBox.Controls.Add(this.FileList_DataGrid);
            this.FileList_groupBox.Location = new System.Drawing.Point(12, 93);
            this.FileList_groupBox.Name = "FileList_groupBox";
            this.FileList_groupBox.Size = new System.Drawing.Size(347, 311);
            this.FileList_groupBox.TabIndex = 5;
            this.FileList_groupBox.TabStop = false;
            this.FileList_groupBox.Text = "File Listing";
            // 
            // FileList_DataGrid
            // 
            this.FileList_DataGrid.AllowUserToAddRows = false;
            this.FileList_DataGrid.AllowUserToDeleteRows = false;
            this.FileList_DataGrid.AllowUserToResizeColumns = false;
            this.FileList_DataGrid.AllowUserToResizeRows = false;
            this.FileList_DataGrid.BackgroundColor = System.Drawing.Color.White;
            this.FileList_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileList_DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheckBox,
            this.ColFileName,
            this.ColViewDataButton});
            this.FileList_DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.FileList_DataGrid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FileList_DataGrid.Location = new System.Drawing.Point(21, 19);
            this.FileList_DataGrid.Name = "FileList_DataGrid";
            this.FileList_DataGrid.ReadOnly = true;
            this.FileList_DataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.FileList_DataGrid.RowHeadersVisible = false;
            this.FileList_DataGrid.Size = new System.Drawing.Size(307, 286);
            this.FileList_DataGrid.TabIndex = 0;
            this.FileList_DataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileList_DataGrid_CellClick);
            // 
            // ColCheckBox
            // 
            this.ColCheckBox.HeaderText = "Print";
            this.ColCheckBox.Name = "ColCheckBox";
            this.ColCheckBox.ReadOnly = true;
            this.ColCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColCheckBox.Width = 50;
            // 
            // ColFileName
            // 
            this.ColFileName.HeaderText = "Filename";
            this.ColFileName.Name = "ColFileName";
            this.ColFileName.ReadOnly = true;
            this.ColFileName.Width = 150;
            // 
            // ColViewDataButton
            // 
            this.ColViewDataButton.HeaderText = "View Data";
            this.ColViewDataButton.Name = "ColViewDataButton";
            this.ColViewDataButton.ReadOnly = true;
            this.ColViewDataButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColViewDataButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColViewDataButton.Text = "SHOW";
            this.ColViewDataButton.Width = 80;
            // 
            // ButtonExtractData
            // 
            this.ButtonExtractData.Location = new System.Drawing.Point(15, 472);
            this.ButtonExtractData.Name = "ButtonExtractData";
            this.ButtonExtractData.Size = new System.Drawing.Size(201, 23);
            this.ButtonExtractData.TabIndex = 6;
            this.ButtonExtractData.Text = "DEBUG : Test Parse and PDF one File";
            this.ButtonExtractData.UseVisualStyleBackColor = true;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(440, 9);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(57, 13);
            this.label_location.TabIndex = 7;
            this.label_location.Text = "Location : ";
            // 
            // label_battery
            // 
            this.label_battery.AutoSize = true;
            this.label_battery.Location = new System.Drawing.Point(440, 22);
            this.label_battery.Name = "label_battery";
            this.label_battery.Size = new System.Drawing.Size(49, 13);
            this.label_battery.TabIndex = 8;
            this.label_battery.Text = "Battery : ";
            // 
            // label_strings
            // 
            this.label_strings.AutoSize = true;
            this.label_strings.Location = new System.Drawing.Point(440, 48);
            this.label_strings.Name = "label_strings";
            this.label_strings.Size = new System.Drawing.Size(62, 13);
            this.label_strings.TabIndex = 10;
            this.label_strings.Text = "No Strings :";
            // 
            // label_datetested
            // 
            this.label_datetested.AutoSize = true;
            this.label_datetested.Location = new System.Drawing.Point(440, 35);
            this.label_datetested.Name = "label_datetested";
            this.label_datetested.Size = new System.Drawing.Size(71, 13);
            this.label_datetested.TabIndex = 9;
            this.label_datetested.Text = "Date tested : ";
            // 
            // label_cellcount
            // 
            this.label_cellcount.AutoSize = true;
            this.label_cellcount.Location = new System.Drawing.Point(440, 61);
            this.label_cellcount.Name = "label_cellcount";
            this.label_cellcount.Size = new System.Drawing.Size(55, 13);
            this.label_cellcount.TabIndex = 11;
            this.label_cellcount.Text = "No Cells : ";
            // 
            // CellCount_text
            // 
            this.CellCount_text.AutoSize = true;
            this.CellCount_text.Location = new System.Drawing.Point(522, 61);
            this.CellCount_text.Name = "CellCount_text";
            this.CellCount_text.Size = new System.Drawing.Size(40, 13);
            this.CellCount_text.TabIndex = 16;
            this.CellCount_text.Text = "-----------";
            // 
            // Strings_text
            // 
            this.Strings_text.AutoSize = true;
            this.Strings_text.Location = new System.Drawing.Point(522, 48);
            this.Strings_text.Name = "Strings_text";
            this.Strings_text.Size = new System.Drawing.Size(40, 13);
            this.Strings_text.TabIndex = 15;
            this.Strings_text.Text = "-----------";
            // 
            // dateTested_text
            // 
            this.dateTested_text.AutoSize = true;
            this.dateTested_text.Location = new System.Drawing.Point(522, 35);
            this.dateTested_text.Name = "dateTested_text";
            this.dateTested_text.Size = new System.Drawing.Size(40, 13);
            this.dateTested_text.TabIndex = 14;
            this.dateTested_text.Text = "-----------";
            // 
            // Battery_text
            // 
            this.Battery_text.AutoSize = true;
            this.Battery_text.Location = new System.Drawing.Point(522, 22);
            this.Battery_text.Name = "Battery_text";
            this.Battery_text.Size = new System.Drawing.Size(40, 13);
            this.Battery_text.TabIndex = 13;
            this.Battery_text.Text = "-----------";
            // 
            // Location_text
            // 
            this.Location_text.AutoSize = true;
            this.Location_text.Location = new System.Drawing.Point(522, 9);
            this.Location_text.Name = "Location_text";
            this.Location_text.Size = new System.Drawing.Size(40, 13);
            this.Location_text.TabIndex = 12;
            this.Location_text.Text = "-----------";
            // 
            // datagrid_testResults
            // 
            this.datagrid_testResults.AllowUserToAddRows = false;
            this.datagrid_testResults.AllowUserToDeleteRows = false;
            this.datagrid_testResults.AllowUserToResizeColumns = false;
            this.datagrid_testResults.AllowUserToResizeRows = false;
            this.datagrid_testResults.BackgroundColor = System.Drawing.SystemColors.Window;
            this.datagrid_testResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_testResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_StringNumber,
            this.col_CellNumber,
            this.col_Volts,
            this.col_Resistance,
            this.col_Icr1,
            this.col_Icr2,
            this.col_Icr3,
            this.col_Icr4,
            this.col_SG});
            this.datagrid_testResults.Location = new System.Drawing.Point(375, 93);
            this.datagrid_testResults.Name = "datagrid_testResults";
            this.datagrid_testResults.ReadOnly = true;
            this.datagrid_testResults.RowHeadersVisible = false;
            this.datagrid_testResults.Size = new System.Drawing.Size(432, 311);
            this.datagrid_testResults.TabIndex = 17;
            this.datagrid_testResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_testResults_CellContentClick);
            // 
            // col_StringNumber
            // 
            this.col_StringNumber.HeaderText = "String";
            this.col_StringNumber.Name = "col_StringNumber";
            this.col_StringNumber.ReadOnly = true;
            this.col_StringNumber.Width = 45;
            // 
            // col_CellNumber
            // 
            this.col_CellNumber.HeaderText = "Cell";
            this.col_CellNumber.Name = "col_CellNumber";
            this.col_CellNumber.ReadOnly = true;
            this.col_CellNumber.Width = 45;
            // 
            // col_Volts
            // 
            this.col_Volts.HeaderText = "Volts";
            this.col_Volts.Name = "col_Volts";
            this.col_Volts.ReadOnly = true;
            this.col_Volts.Width = 45;
            // 
            // col_Resistance
            // 
            this.col_Resistance.HeaderText = "Res";
            this.col_Resistance.Name = "col_Resistance";
            this.col_Resistance.ReadOnly = true;
            this.col_Resistance.Width = 45;
            // 
            // col_Icr1
            // 
            this.col_Icr1.HeaderText = "ICR1";
            this.col_Icr1.Name = "col_Icr1";
            this.col_Icr1.ReadOnly = true;
            this.col_Icr1.Width = 45;
            // 
            // col_Icr2
            // 
            this.col_Icr2.HeaderText = "ICR2";
            this.col_Icr2.Name = "col_Icr2";
            this.col_Icr2.ReadOnly = true;
            this.col_Icr2.Width = 45;
            // 
            // col_Icr3
            // 
            this.col_Icr3.HeaderText = "ICR3";
            this.col_Icr3.Name = "col_Icr3";
            this.col_Icr3.ReadOnly = true;
            this.col_Icr3.Width = 45;
            // 
            // col_Icr4
            // 
            this.col_Icr4.HeaderText = "ICR4";
            this.col_Icr4.Name = "col_Icr4";
            this.col_Icr4.ReadOnly = true;
            this.col_Icr4.Width = 45;
            // 
            // col_SG
            // 
            this.col_SG.HeaderText = "SG";
            this.col_SG.Name = "col_SG";
            this.col_SG.ReadOnly = true;
            this.col_SG.Width = 45;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.progressBar.Location = new System.Drawing.Point(260, 472);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(369, 23);
            this.progressBar.TabIndex = 18;
            // 
            // progressBar_Label
            // 
            this.progressBar_Label.BackColor = System.Drawing.Color.Transparent;
            this.progressBar_Label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBar_Label.Location = new System.Drawing.Point(257, 446);
            this.progressBar_Label.Name = "progressBar_Label";
            this.progressBar_Label.Size = new System.Drawing.Size(372, 23);
            this.progressBar_Label.TabIndex = 19;
            this.progressBar_Label.Text = "Task that is being progresed";
            this.progressBar_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(852, 507);
            this.Controls.Add(this.progressBar_Label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.datagrid_testResults);
            this.Controls.Add(this.CellCount_text);
            this.Controls.Add(this.Strings_text);
            this.Controls.Add(this.dateTested_text);
            this.Controls.Add(this.Battery_text);
            this.Controls.Add(this.Location_text);
            this.Controls.Add(this.label_cellcount);
            this.Controls.Add(this.label_strings);
            this.Controls.Add(this.label_datetested);
            this.Controls.Add(this.label_battery);
            this.Controls.Add(this.label_location);
            this.Controls.Add(this.ButtonExtractData);
            this.Controls.Add(this.FileList_groupBox);
            this.Controls.Add(this.SelectCsvFolder_label);
            this.Controls.Add(this.browseForCsv_Button);
            this.Controls.Add(this.csv_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "main_Form";
            this.Text = "Cellcorder Reporting Tool";
            this.FileList_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileList_DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_testResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox csv_TextBox;
        private System.Windows.Forms.Button browseForCsv_Button;
        private System.Windows.Forms.Label SelectCsvFolder_label;
        public System.Windows.Forms.GroupBox FileList_groupBox;
        public System.Windows.Forms.DataGridView FileList_DataGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFileName;
        private System.Windows.Forms.DataGridViewButtonColumn ColViewDataButton;
        private System.Windows.Forms.Button ButtonExtractData;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.Label label_battery;
        private System.Windows.Forms.Label label_strings;
        private System.Windows.Forms.Label label_datetested;
        private System.Windows.Forms.Label label_cellcount;
        private System.Windows.Forms.Label CellCount_text;
        private System.Windows.Forms.Label Strings_text;
        private System.Windows.Forms.Label dateTested_text;
        private System.Windows.Forms.Label Battery_text;
        private System.Windows.Forms.Label Location_text;
        private System.Windows.Forms.DataGridView datagrid_testResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_StringNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CellNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Volts;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Resistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Icr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Icr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Icr3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Icr4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SG;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressBar_Label;
    }
}

