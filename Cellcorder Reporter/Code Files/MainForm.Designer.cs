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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_Form));
            this.csv_TextBox = new System.Windows.Forms.TextBox();
            this.browseForCsv_Button = new System.Windows.Forms.Button();
            this.SelectCsvFolder_label = new System.Windows.Forms.Label();
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
            this.testResults_DataGrid = new System.Windows.Forms.DataGridView();
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
            this.tag_text = new System.Windows.Forms.Label();
            this.label_Tag = new System.Windows.Forms.Label();
            this.groupbox_DataPreview = new System.Windows.Forms.GroupBox();
            this.groupBox_fileListing = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.FileList_DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testResults_DataGrid)).BeginInit();
            this.groupbox_DataPreview.SuspendLayout();
            this.groupBox_fileListing.SuspendLayout();
            this.SuspendLayout();
            // 
            // csv_TextBox
            // 
            this.csv_TextBox.Location = new System.Drawing.Point(52, 68);
            this.csv_TextBox.Name = "csv_TextBox";
            this.csv_TextBox.ReadOnly = true;
            this.csv_TextBox.Size = new System.Drawing.Size(242, 20);
            this.csv_TextBox.TabIndex = 0;
            this.csv_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // browseForCsv_Button
            // 
            this.browseForCsv_Button.Location = new System.Drawing.Point(300, 68);
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
            this.SelectCsvFolder_label.Location = new System.Drawing.Point(52, 52);
            this.SelectCsvFolder_label.Name = "SelectCsvFolder_label";
            this.SelectCsvFolder_label.Size = new System.Drawing.Size(265, 13);
            this.SelectCsvFolder_label.TabIndex = 2;
            this.SelectCsvFolder_label.Text = "Select folder that contains CSV files..";
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
            this.FileList_DataGrid.Location = new System.Drawing.Point(24, 25);
            this.FileList_DataGrid.Name = "FileList_DataGrid";
            this.FileList_DataGrid.ReadOnly = true;
            this.FileList_DataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.FileList_DataGrid.RowHeadersVisible = false;
            this.FileList_DataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FileList_DataGrid.Size = new System.Drawing.Size(307, 311);
            this.FileList_DataGrid.TabIndex = 0;
            this.FileList_DataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileList_DataGrid_CellClick);
            // 
            // ColCheckBox
            // 
            this.ColCheckBox.HeaderText = "Print";
            this.ColCheckBox.Name = "ColCheckBox";
            this.ColCheckBox.ReadOnly = true;
            this.ColCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColCheckBox.Width = 50;
            // 
            // ColFileName
            // 
            this.ColFileName.HeaderText = "Filename";
            this.ColFileName.Name = "ColFileName";
            this.ColFileName.ReadOnly = true;
            this.ColFileName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColFileName.Width = 150;
            // 
            // ColViewDataButton
            // 
            this.ColViewDataButton.HeaderText = "View Data";
            this.ColViewDataButton.Name = "ColViewDataButton";
            this.ColViewDataButton.ReadOnly = true;
            this.ColViewDataButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColViewDataButton.Text = "SHOW";
            this.ColViewDataButton.Width = 80;
            // 
            // ButtonExtractData
            // 
            this.ButtonExtractData.Location = new System.Drawing.Point(70, 523);
            this.ButtonExtractData.Name = "ButtonExtractData";
            this.ButtonExtractData.Size = new System.Drawing.Size(201, 23);
            this.ButtonExtractData.TabIndex = 6;
            this.ButtonExtractData.Text = "DEBUG : Test Parse and PDF one File";
            this.ButtonExtractData.UseVisualStyleBackColor = true;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(41, 22);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(57, 13);
            this.label_location.TabIndex = 7;
            this.label_location.Text = "Location : ";
            // 
            // label_battery
            // 
            this.label_battery.AutoSize = true;
            this.label_battery.Location = new System.Drawing.Point(41, 77);
            this.label_battery.Name = "label_battery";
            this.label_battery.Size = new System.Drawing.Size(49, 13);
            this.label_battery.TabIndex = 8;
            this.label_battery.Text = "Battery : ";
            // 
            // label_strings
            // 
            this.label_strings.AutoSize = true;
            this.label_strings.Location = new System.Drawing.Point(273, 47);
            this.label_strings.Name = "label_strings";
            this.label_strings.Size = new System.Drawing.Size(62, 13);
            this.label_strings.TabIndex = 10;
            this.label_strings.Text = "No Strings :";
            // 
            // label_datetested
            // 
            this.label_datetested.AutoSize = true;
            this.label_datetested.Location = new System.Drawing.Point(273, 22);
            this.label_datetested.Name = "label_datetested";
            this.label_datetested.Size = new System.Drawing.Size(71, 13);
            this.label_datetested.TabIndex = 9;
            this.label_datetested.Text = "Date tested : ";
            // 
            // label_cellcount
            // 
            this.label_cellcount.AutoSize = true;
            this.label_cellcount.Location = new System.Drawing.Point(273, 77);
            this.label_cellcount.Name = "label_cellcount";
            this.label_cellcount.Size = new System.Drawing.Size(55, 13);
            this.label_cellcount.TabIndex = 11;
            this.label_cellcount.Text = "No Cells : ";
            // 
            // CellCount_text
            // 
            this.CellCount_text.AutoSize = true;
            this.CellCount_text.Location = new System.Drawing.Point(355, 77);
            this.CellCount_text.Name = "CellCount_text";
            this.CellCount_text.Size = new System.Drawing.Size(40, 13);
            this.CellCount_text.TabIndex = 16;
            this.CellCount_text.Text = "-----------";
            // 
            // Strings_text
            // 
            this.Strings_text.AutoSize = true;
            this.Strings_text.Location = new System.Drawing.Point(355, 47);
            this.Strings_text.Name = "Strings_text";
            this.Strings_text.Size = new System.Drawing.Size(40, 13);
            this.Strings_text.TabIndex = 15;
            this.Strings_text.Text = "-----------";
            // 
            // dateTested_text
            // 
            this.dateTested_text.AutoSize = true;
            this.dateTested_text.Location = new System.Drawing.Point(355, 22);
            this.dateTested_text.Name = "dateTested_text";
            this.dateTested_text.Size = new System.Drawing.Size(40, 13);
            this.dateTested_text.TabIndex = 14;
            this.dateTested_text.Text = "-----------";
            // 
            // Battery_text
            // 
            this.Battery_text.AutoSize = true;
            this.Battery_text.Location = new System.Drawing.Point(104, 77);
            this.Battery_text.Name = "Battery_text";
            this.Battery_text.Size = new System.Drawing.Size(40, 13);
            this.Battery_text.TabIndex = 13;
            this.Battery_text.Text = "-----------";
            // 
            // Location_text
            // 
            this.Location_text.AutoSize = true;
            this.Location_text.Location = new System.Drawing.Point(104, 22);
            this.Location_text.Name = "Location_text";
            this.Location_text.Size = new System.Drawing.Size(40, 13);
            this.Location_text.TabIndex = 12;
            this.Location_text.Text = "-----------";
            // 
            // testResults_DataGrid
            // 
            this.testResults_DataGrid.AllowUserToAddRows = false;
            this.testResults_DataGrid.AllowUserToDeleteRows = false;
            this.testResults_DataGrid.AllowUserToResizeColumns = false;
            this.testResults_DataGrid.AllowUserToResizeRows = false;
            this.testResults_DataGrid.BackgroundColor = System.Drawing.Color.White;
            this.testResults_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testResults_DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_StringNumber,
            this.col_CellNumber,
            this.col_Volts,
            this.col_Resistance,
            this.col_Icr1,
            this.col_Icr2,
            this.col_Icr3,
            this.col_Icr4,
            this.col_SG});
            this.testResults_DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.testResults_DataGrid.Location = new System.Drawing.Point(44, 103);
            this.testResults_DataGrid.Name = "testResults_DataGrid";
            this.testResults_DataGrid.ReadOnly = true;
            this.testResults_DataGrid.RowHeadersVisible = false;
            this.testResults_DataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.testResults_DataGrid.Size = new System.Drawing.Size(432, 311);
            this.testResults_DataGrid.TabIndex = 17;
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
            this.progressBar.Location = new System.Drawing.Point(400, 530);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(369, 23);
            this.progressBar.TabIndex = 18;
            // 
            // progressBar_Label
            // 
            this.progressBar_Label.BackColor = System.Drawing.Color.Transparent;
            this.progressBar_Label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBar_Label.Location = new System.Drawing.Point(397, 504);
            this.progressBar_Label.Name = "progressBar_Label";
            this.progressBar_Label.Size = new System.Drawing.Size(372, 23);
            this.progressBar_Label.TabIndex = 19;
            this.progressBar_Label.Text = "Task that is being progresed";
            this.progressBar_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tag_text
            // 
            this.tag_text.AutoSize = true;
            this.tag_text.Location = new System.Drawing.Point(104, 47);
            this.tag_text.Name = "tag_text";
            this.tag_text.Size = new System.Drawing.Size(40, 13);
            this.tag_text.TabIndex = 21;
            this.tag_text.Text = "-----------";
            // 
            // label_Tag
            // 
            this.label_Tag.AutoSize = true;
            this.label_Tag.Location = new System.Drawing.Point(41, 47);
            this.label_Tag.Name = "label_Tag";
            this.label_Tag.Size = new System.Drawing.Size(32, 13);
            this.label_Tag.TabIndex = 20;
            this.label_Tag.Text = "Tag :";
            // 
            // groupbox_DataPreview
            // 
            this.groupbox_DataPreview.BackColor = System.Drawing.Color.White;
            this.groupbox_DataPreview.Controls.Add(this.tag_text);
            this.groupbox_DataPreview.Controls.Add(this.label_Tag);
            this.groupbox_DataPreview.Controls.Add(this.testResults_DataGrid);
            this.groupbox_DataPreview.Controls.Add(this.CellCount_text);
            this.groupbox_DataPreview.Controls.Add(this.Strings_text);
            this.groupbox_DataPreview.Controls.Add(this.dateTested_text);
            this.groupbox_DataPreview.Controls.Add(this.Battery_text);
            this.groupbox_DataPreview.Controls.Add(this.Location_text);
            this.groupbox_DataPreview.Controls.Add(this.label_cellcount);
            this.groupbox_DataPreview.Controls.Add(this.label_strings);
            this.groupbox_DataPreview.Controls.Add(this.label_datetested);
            this.groupbox_DataPreview.Controls.Add(this.label_battery);
            this.groupbox_DataPreview.Controls.Add(this.label_location);
            this.groupbox_DataPreview.Location = new System.Drawing.Point(415, 28);
            this.groupbox_DataPreview.Name = "groupbox_DataPreview";
            this.groupbox_DataPreview.Size = new System.Drawing.Size(504, 444);
            this.groupbox_DataPreview.TabIndex = 22;
            this.groupbox_DataPreview.TabStop = false;
            this.groupbox_DataPreview.Text = "Review Test Data";
            // 
            // groupBox_fileListing
            // 
            this.groupBox_fileListing.Controls.Add(this.FileList_DataGrid);
            this.groupBox_fileListing.Location = new System.Drawing.Point(28, 106);
            this.groupBox_fileListing.Name = "groupBox_fileListing";
            this.groupBox_fileListing.Size = new System.Drawing.Size(354, 365);
            this.groupBox_fileListing.TabIndex = 23;
            this.groupBox_fileListing.TabStop = false;
            this.groupBox_fileListing.Text = "CSV Test Files (Uncheck Files that are not to be reported on)";
            // 
            // main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(949, 558);
            this.Controls.Add(this.groupBox_fileListing);
            this.Controls.Add(this.groupbox_DataPreview);
            this.Controls.Add(this.progressBar_Label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ButtonExtractData);
            this.Controls.Add(this.SelectCsvFolder_label);
            this.Controls.Add(this.browseForCsv_Button);
            this.Controls.Add(this.csv_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main_Form";
            this.Text = "Cellcorder Reporting Tool";
            this.Load += new System.EventHandler(this.main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FileList_DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testResults_DataGrid)).EndInit();
            this.groupbox_DataPreview.ResumeLayout(false);
            this.groupbox_DataPreview.PerformLayout();
            this.groupBox_fileListing.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox csv_TextBox;
        private System.Windows.Forms.Button browseForCsv_Button;
        private System.Windows.Forms.Label SelectCsvFolder_label;
        public System.Windows.Forms.DataGridView FileList_DataGrid;
        private System.Windows.Forms.Button ButtonExtractData;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.Label label_battery;
        private System.Windows.Forms.Label label_strings;
        private System.Windows.Forms.Label label_datetested;
        private System.Windows.Forms.Label label_cellcount;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFileName;
        private System.Windows.Forms.DataGridViewButtonColumn ColViewDataButton;
        public System.Windows.Forms.Label CellCount_text;
        public System.Windows.Forms.Label Strings_text;
        public System.Windows.Forms.Label dateTested_text;
        public System.Windows.Forms.Label Battery_text;
        public System.Windows.Forms.Label Location_text;
        public System.Windows.Forms.DataGridView testResults_DataGrid;
        public System.Windows.Forms.Label tag_text;
        private System.Windows.Forms.Label label_Tag;
        private System.Windows.Forms.GroupBox groupbox_DataPreview;
        private System.Windows.Forms.GroupBox groupBox_fileListing;
    }
}

