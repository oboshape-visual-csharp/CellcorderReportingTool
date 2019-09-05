using System;
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
        // view and modify the currently visible test reading thresholds
        //---------------------------------------------------------------------
        private void button_EditThresholds_Click(object sender, EventArgs e)
        {
            // open the thresholds form
            ViewEditThresholds thresholdsForm = new ViewEditThresholds();
            thresholdsForm.ShowDialog();
            // refresh the data on the preview grid
            UI.PreviewFile(GlobalData.currentlyViewingFile);
        }


        //---------------------------------------------------------------------
        // view and modify the currently visible test reading thresholds
        //---------------------------------------------------------------------
        private void SaveComments_button_Click(object sender, EventArgs e)
        {
            GlobalData.allTestReadings[GlobalData.currentlyViewingFile].comments = Comments_textBox.Text.Trim();
        }




        // testing the PDF creation
        private void TestPDF_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine(GlobalData.currentlyViewingFile);
            CellcorderReporting.CreatePDFReport(GlobalData.currentlyViewingFile);
        }

    }
}
