﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Cellcorder_Reporter
{
    public partial class main_Form : Form
    {
        public main_Form()
        {
            InitializeComponent();
        }


        //---------------------------------------------------------------------
        // CSV Browse button handler
        //---------------------------------------------------------------------
        private void Browse_for_CSV_Button_Click(object sender, EventArgs e)
        {
            csv_TextBox.Text = UI.GetCsvFolderLocation().Trim();
            if (csv_TextBox.Text != "")
            {
                GlobalData.allTestReadings = new Dictionary<string, TestResult>();  // reset this for new data
                UI.ShowListInGrid(csv_TextBox.Text);
            }
        }


        //---------------------------------------------------------------------
        // DataGrid click handler
        //---------------------------------------------------------------------
        private void FileList_DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) // just to diable clicking on the header having any effect
            UI.ProcessDataGridClicks(sender, e);
        }

        private void main_Form_Load(object sender, EventArgs e)
        {
            // set some of the global references
            GlobalData.fileListDGV = FileList_DataGrid;
            GlobalData.previewDataDGV = testResults_DataGrid;
            GlobalData.mainFormRef = this;
        }


        //---------------------------------------------------------------------
        // Parsing test button handler
        //---------------------------------------------------------------------
        //private void TestParseButton_Click(object sender, EventArgs e)
        //{
        //    // need to grab the file list and pass that to the parsing method
        //   //UI.ProcessParseButtonClick(@"C:\_Work Related_\Work History\Repsol\Saltire\2017\Saltire - April 2017\Cellcorder Results\CSV\7530D1D2.csv");
        //}

    }
}