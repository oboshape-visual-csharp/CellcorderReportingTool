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

        // this is the reference to the Progress bar form
        PDFProgressBarForm pDFProgressBar;

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
                // set the gobal info for the CSV Location
                GlobalData.csvStoragePath = csv_TextBox.Text;
                GlobalData.allTestReadings = new Dictionary<string, TestResult>();  // reset this for new data
                UI.ShowListInGrid(csv_TextBox.Text);
            }
            else
            {
                GlobalData.csvStoragePath = null;
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


        private void ButtonCreateSelectedPDFs_Click(object sender, EventArgs e)
        {
           
            // this will fire the background worker to get the reports generated
            if (backgroundWorkerPDF.IsBusy != true)
            {
                // create a new instance of the alert form
                pDFProgressBar = new PDFProgressBarForm();
                // event handler for the Cancel button in AlertForm
                pDFProgressBar.Canceled += new EventHandler<EventArgs>(Button_cancelPDF_Click);
                pDFProgressBar.Show();
                pDFProgressBar.ButtonText = "Cancel";
                // Start the asynchronous operation.
                backgroundWorkerPDF.RunWorkerAsync();
            }

            
        }

        // This event handler cancels the backgroundworker, fired from Cancel button in AlertForm.
        private void Button_cancelPDF_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerPDF.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorkerPDF.CancelAsync();
                // Close the AlertForm
                pDFProgressBar.Close();
            }
        }

        private void BackgroundWorkerPDF_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            // Get all the CSV files that are checked in the datagrid list view
            List<string> filesToProcess = new List<string>();
            FileList_DataGrid.Rows.OfType<DataGridViewRow>().ToList<DataGridViewRow>().ForEach(
                row =>
                {
                    if ((bool)row.Cells[0].Value == true)
                    {
                        filesToProcess.Add(row.Cells[1].Value.ToString());
                    }
                });

            // just check that there is actually files ticked before going any further
            if (filesToProcess.Count == 0)
            {
                MessageBox.Show("There are no files selected to report on!");
                return;
            }

            // since theres at least one, get the location from that
            string location = GlobalData.allTestReadings[filesToProcess[0]].location;
            string PDFFolderPath = GlobalData.csvStoragePath + "\\" + "PDF Reports";

            // create an outputfolder to write PDFs to, in the folder that contains the CSV Files
            System.IO.Directory.CreateDirectory(PDFFolderPath);
            // set the PDF output path in the global Data class
            GlobalData.pdfOutputFolderPath = PDFFolderPath;


            // counters for the creation loop
            int currentDocNo = 0;
            int totalDocs = filesToProcess.Count;

            // now to create all the PDF reports, see how this goes ;)
            foreach (string fileToProcess in filesToProcess)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    currentDocNo++;
                    CellcorderReporting.CreatePDFReport(fileToProcess);
                    worker.ReportProgress(currentDocNo*100 / totalDocs);
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        private void BackgroundWorkerPDF_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pDFProgressBar.ProgressValue = e.ProgressPercentage;
            pDFProgressBar.Message = (e.ProgressPercentage.ToString() + "%");
        }

        private void BackgroundWorkerPDF_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                pDFProgressBar.Message = "Canceled!";
                WaitAndClose();
            }
            else if (e.Error != null)
            {
                pDFProgressBar.Message = "Error: " + e.Error.Message;
            }
            else
            {
                pDFProgressBar.Message = "Processing Documents Complete!";
                WaitAndClose();
                // now open the folder with the pdf files in it for viewing
                System.Diagnostics.Process.Start(GlobalData.pdfOutputFolderPath);
            }
        
            void WaitAndClose()
            {
                System.Threading.Thread.Sleep(2000);
                pDFProgressBar.Close();
                pDFProgressBar.Dispose();
                pDFProgressBar = null;
            }

        }
    }
}
