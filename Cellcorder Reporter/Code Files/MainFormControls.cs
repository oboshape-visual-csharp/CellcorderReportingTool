// this is the code that will contain all the main form
// interaction code


using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Cellcorder_Reporter
{
    public static class UI
    {

        //---------------------------------------------------------------------
        //Method that gets the folder selected from the browse button
        //---------------------------------------------------------------------
        public static string GetCsvFolderLocation()
        {
            string csvFolderLocation = "";

            FolderBrowserDialog browserDialogue = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = "Select location of folder that contains CSV files."
            };

            DialogResult dialogueResult = browserDialogue.ShowDialog();

            if (dialogueResult == DialogResult.OK && browserDialogue.SelectedPath != null)
            {
                csvFolderLocation = browserDialogue.SelectedPath;
            }

            // empty the object before garbage collection
            browserDialogue = null;

            // save this path in the global data structure
            Console.WriteLine(csvFolderLocation);
            GlobalData.csvStoragePath = csvFolderLocation;
            //return csvFolderLocation;
            return @"C:\_Current Projects\C#\Work CSV Reporting - OLD\CSV Files"; // DEBUGGING
        }


        //---------------------------------------------------------------------
        // get the list of filenames in the specified folder
        //---------------------------------------------------------------------
        public static Array FileListArray(string _path)
        {
            return Directory.GetFiles(_path, "*.CSV");
        }

        //---------------------------------------------------------------------
        //  show the files in the datagrid on the main form
        //---------------------------------------------------------------------
        public static void ShowListInGrid(string _path)
        {
            main_Form form = (main_Form)Application.OpenForms["main_Form"];
            // reset the datagrid view to blank it by clearing rows
            if (form.FileList_DataGrid.Rows.Count > 0)
                form.FileList_DataGrid.Rows.Clear();
            foreach (string item in FileListArray(_path))
            {
                form.FileList_DataGrid.Rows.Add(
                    true,
                    Path.GetFileNameWithoutExtension(item),
                    "Show Data"
                    );
            }

            //---------------------------------------------------------------------
            // Set all the lines to a faint green if checked, then later
            // we can set to a dark lime once they have been checked
            //---------------------------------------------------------------------
            for (int i = 0; i < form.FileList_DataGrid.Rows.Count; i++)
            {
                form.FileList_DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                //if (i % 2 != 0)
                //{
                //    // this colors the whole line
                //    //form.FileList_DataGrid.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                //    // and this does individual cells
                //    //form.FileList_DataGrid.Rows[i].Cells[1].Style.BackColor = Color.Pink;
                //}
            }
        }

        //---------------------------------------------------------------------
        //    Processing of the clicked sections of the datagrid view in main form
        //---------------------------------------------------------------------
        public static void ProcessDataGridClicks(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn ||
                senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow row = senderGrid.Rows[e.RowIndex]; // set clicked row

                if (e.ColumnIndex == 0)  // so if this is the checkbox column on that row
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                    if ((bool)cell.Value == true)
                    {
                        cell.Value = false;
                        row.DefaultCellStyle.BackColor = Color.Crimson; // unselected color
                    }
                    else
                    {
                        cell.Value = true;
                        row.DefaultCellStyle.BackColor = Color.PaleGreen;  // selected color
                    }
                }

            }
        }


        //---------------------------------------------------------------------
        //    handle the test parse button click
        //---------------------------------------------------------------------
        public static void ProcessParseButtonClick(String _fileToParse)
        {
            //TODO : check to see if any of the files are open before going through this.
            try
            {
                TestResult tempResult = Parser.ParseCSV(_fileToParse);

                //Console.WriteLine("File : " + tempResult.fileName);
                //Console.WriteLine("Date Created : " + tempResult.dateFileCreated);
                //Console.WriteLine("Location : " + tempResult.location);
                //Console.WriteLine("Battery Name : " + tempResult.batteryName);
                //Console.WriteLine("Total strings : " + tempResult.totalStrings);
                //Console.WriteLine("Model no : " + tempResult.modelNumber);
                //Console.WriteLine("install date : " + tempResult.installDate);
                //Console.WriteLine("Temperature scale : " + tempResult.temperatureScale.ToString());
                //Console.WriteLine("highVoltage_threshold : " + tempResult.highVoltage_threshold);
                //Console.WriteLine("lowVoltage_threshold : " + tempResult.lowVoltage_threshold);
                //Console.WriteLine("highResistance_threshold : " + tempResult.highResistance_threshold);
                //Console.WriteLine("lowResistance_threshold : " + tempResult.lowResistance_threshold);
                //Console.WriteLine("highInterCell1_threshold : " + tempResult.highInterCell1_threshold);
                //Console.WriteLine("highInterCell2_threshold : " + tempResult.highInterCell2_threshold);
                //Console.WriteLine("highInterCell3_threshold : " + tempResult.highInterCell3_threshold);
                //Console.WriteLine("highInterCell4_threshold : " + tempResult.highInterCell4_threshold);
                //Console.WriteLine("Overall Voltage : " + tempResult.GetOverallFloatVoltage());
                //CellReading maxR = tempResult.GetMaxResistance();
                //Console.WriteLine("Max resistance : String : " + maxR.stringNumber + " on Cell : " + maxR.cellNumber + " of : " + maxR.resistance);
                //CellReading minR = tempResult.GetMinResistance();
                //Console.WriteLine("Min resistance : String : " + minR.stringNumber + " on Cell : " + minR.cellNumber + " of : " + minR.resistance);
                //CellReading maxV = tempResult.GetMaxFloat();
                //Console.WriteLine("maxV voltage : String : " + maxV.stringNumber + " on Cell : " + maxV.cellNumber + " of : " + maxV.floatVoltage);
            }
            catch (IOException)
            {
                Console.WriteLine(" Cannot process file : " + _fileToParse.ToString() + " as it is in use, close this file and try agnain!");
            }

        }

       
    }
}