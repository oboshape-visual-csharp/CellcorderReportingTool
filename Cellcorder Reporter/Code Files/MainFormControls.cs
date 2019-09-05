// this is the code that will contain all the main form
// interaction code


using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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
            GlobalData.csvStoragePath = csvFolderLocation;
            //return csvFolderLocation;
            return @"C:\_Current Projects\C#\Work CSV Reporting - OLD\CSV Files"; // DEBUGGING
        }


        //---------------------------------------------------------------------
        // get the list of filenames in the specified folder
        //---------------------------------------------------------------------
        public static List<string> FileListArray(string _path)
        {
            // need to ensre that the files are valid when returning the list to include
            // takes a bit longer but its probably best to do it here before going any further

            List<String> invalidFiles = new List<string>();  // records invalid files
            List<String> validFileList = new List<string>();

            foreach (string item in Directory.GetFiles(_path, "*.CSV"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(File.OpenRead(item)))
                    {
                        // if all goes well, add to list and should dispose after opening
                        validFileList.Add(item);
                    }
                }
                catch (IOException)
                {
                    // if it cannot open the file, warn user and dont add to valid list of files
                    invalidFiles.Add(Path.GetFileNameWithoutExtension(item) + "\n");
                    Console.WriteLine( "Thrown from FileListArray : " + Path.GetFileNameWithoutExtension(item));
                }

            }

            if (invalidFiles.Count > 0)
            {
                invalidFiles.Insert(0, "The following files cannot be accessed, either they are open or invalid.\n\n");
                invalidFiles.Add("\n\nCheck these files and reselect folder with browse button.");
                MessageBox.Show(string.Join<string>("", invalidFiles), "File Processing error..",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            

            // if there are no valid files at this location
            if(validFileList.Count ==0)
            {
                MessageBox.Show("\nNo valid CSV files at this location.\n" + _path + "\n\nPlease browse to another folder.", "Invalid folder selection..",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return validFileList;
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

            // now disable the threshold editing and saving comments button, since the list has changed
            GlobalData.mainFormRef.SaveComments_button.Enabled = false;
            GlobalData.mainFormRef.button_EditThresholds.Enabled = false;
            // set the filename in use flag thats in the global data to "" (nothing)
            GlobalData.currentlyViewingFile = "";

            List<string> errorList = new List<string>();
            

            foreach (string item in FileListArray(_path))
            { 
                // try to parse each one as it is added and capture any errors here.
                try
                {
                    TestResult tempResult =  Parser.ParseCSV(item);
                    GlobalData.allTestReadings.Add(Path.GetFileNameWithoutExtension(item), tempResult);

                    form.FileList_DataGrid.Rows.Add(
                    true,
                    Path.GetFileNameWithoutExtension(item),
                    "Review Data"
                    );
                }
                catch (FormatException)
                {
                    Console.WriteLine("thrown from parsing and ShowListInGrid: " + Path.GetFileNameWithoutExtension(item));
                    errorList.Add(Path.GetFileNameWithoutExtension(item));
                } 
            }

            if(errorList.Count > 0)
            {
                errorList.Insert(0,"The following files are in the incorrect format and can not be read.\n\n");
                errorList.Add("\n\nCheck these files if required and reselect folder with browse button.");
                // show any errors as a message box
                MessageBox.Show(string.Join<string>("", errorList),
                    "File Formatting error..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // process the clicks on the checkbox column
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

                // process the clicks on the preview button column
                if(e.ColumnIndex == 2)
                {
                    DataGridViewButtonCell butCell = (DataGridViewButtonCell)row.Cells[2];
                    //string fileToShow = senderGrid.Columns[1].Row[e.RowIndex]
                    string fileToExamine =  senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    // now fire this off to another method to display it in the grid.
                    PreviewFile(fileToExamine);
                }
            }
        }

        //---------------------------------------------------------------------
        //    show preview data in preview datagrid
        //---------------------------------------------------------------------
        public static void PreviewFile(string _fileName)
        {
            // get the dict entry for the dataset
            TestResult resultSet = GlobalData.allTestReadings[_fileName];
            GlobalData.mainFormRef.Location_text.Text = resultSet.location;
            GlobalData.mainFormRef.Battery_text.Text = resultSet.batteryName;
            GlobalData.mainFormRef.dateTested_text.Text = resultSet.dateFileCreated.ToString("dd / MM / yyyy");
            GlobalData.mainFormRef.Strings_text.Text = resultSet.totalStrings.ToString();
            GlobalData.mainFormRef.CellCount_text.Text = resultSet.GetMaxCellsInStrings().ToString();
            GlobalData.mainFormRef.tag_text.Text = _fileName;

            // set the currently viewing file reference
            GlobalData.currentlyViewingFile = _fileName;
            // display any test comments in the comments box
            GlobalData.mainFormRef.Comments_textBox.Text = @resultSet.comments;

            // need to clear the datagridview ready for repopulating
            if (GlobalData.mainFormRef.testResults_DataGrid.Rows.Count > 0)
                GlobalData.mainFormRef.testResults_DataGrid.Rows.Clear();


            // heres the color definitions rather than hard coding in loads of places.
            Color lowColor = Color.Yellow;
            Color highColor = Color.Red;

            // going to use a string index counter here, just so that if the string changes to a 2 i can add a separator line.
            int stringIndexCounter = 1;

            // populate the datagrid with the cell results
            foreach (CellReading reading in resultSet.cellReadingsList)
            {
                // add a blank line if the current string index is incremented (so different to stringIndexCounter)
                if (reading.stringNumber > stringIndexCounter)
                {
                    // add a blank row and increment string index counter
                    DataGridViewRow BlankRow = new DataGridViewRow();
                    GlobalData.mainFormRef.testResults_DataGrid.Rows.Add(BlankRow);
                    stringIndexCounter++;
                }
                // declare row > populate > and add it to datagrid
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(GlobalData.mainFormRef.testResults_DataGrid);
                // as goes through check the values agains the thresholds set via cellcorder
                row.Cells[0].Value = reading.stringNumber;
                row.Cells[1].Value = reading.cellNumber;

                // get the float voltage and check against thresholds
                row.Cells[2].Value = reading.floatVoltage.ToString("0.000");
                if (reading.floatVoltage <= resultSet.lowVoltage_threshold)
                    row.Cells[2].Style.BackColor = lowColor;
                else if (reading.floatVoltage >= resultSet.highVoltage_threshold)
                    row.Cells[2].Style.BackColor = highColor;

                // get the resistance and check check against thresholds
                row.Cells[3].Value = reading.resistance;
                if (reading.resistance <= resultSet.lowResistance_threshold && resultSet.lowResistance_threshold != 0)
                    row.Cells[3].Style.BackColor = lowColor;
                else if (reading.resistance >= resultSet.highResistance_threshold && resultSet.highResistance_threshold != 0)
                    row.Cells[3].Style.BackColor = highColor;

                // get the intertier resistance and check against thresholds
                row.Cells[4].Value = reading.interCell_1_Resistance;
                if (reading.interCell_1_Resistance >= resultSet.highInterCell1_threshold && resultSet.highInterCell1_threshold !=0)
                    row.Cells[4].Style.BackColor = highColor;

                // get the intertier resistance and check against thresholds
                row.Cells[5].Value = reading.interCell_2_Resistance;
                if (reading.interCell_2_Resistance >= resultSet.highInterCell2_threshold && resultSet.highInterCell2_threshold != 0)
                    row.Cells[5].Style.BackColor = highColor;

                // get the intertier resistance and check against thresholds
                row.Cells[6].Value = reading.interCell_3_Resistance;
                if (reading.interCell_3_Resistance >= resultSet.highInterCell3_threshold && resultSet.highInterCell3_threshold != 0)
                    row.Cells[6].Style.BackColor = highColor;

                // get the intertier resistance and check against thresholds
                row.Cells[7].Value = reading.interCell_4_Resistance;
                if (reading.interCell_4_Resistance >= resultSet.highInterCell4_threshold && resultSet.highInterCell4_threshold != 0)
                    row.Cells[7].Style.BackColor = highColor;

                // get the specific gravity
                row.Cells[8].Value = reading.specificGravity;
                if (reading.specificGravity <= resultSet.lowSG_threshold && resultSet.lowSG_threshold != 0 && resultSet.lowSG_threshold != resultSet.highSG_threshold)
                    row.Cells[8].Style.BackColor = lowColor;
                else if (reading.specificGravity >= resultSet.highSG_threshold && resultSet.highSG_threshold != 0 && resultSet.lowSG_threshold != resultSet.highSG_threshold)
                    row.Cells[8].Style.BackColor = highColor;

                // get the temperature
                row.Cells[9].Value = reading.temperature;
                if (reading.temperature <= resultSet.lowTemperature_threshold && resultSet.lowTemperature_threshold != 0 && resultSet.lowTemperature_threshold != resultSet.highTemperature_threshold)
                    row.Cells[9].Style.BackColor = lowColor;
                else if (reading.temperature >= resultSet.highTemperature_threshold && resultSet.highTemperature_threshold != 0 && resultSet.lowTemperature_threshold != resultSet.highTemperature_threshold)
                    row.Cells[9].Style.BackColor = highColor;

                // now insert this row object into the grid
                GlobalData.mainFormRef.testResults_DataGrid.Rows.Add(row);
            }

            // can enable the edit thresholds and save comments buttons at this point as data is displayed
            GlobalData.mainFormRef.SaveComments_button.Enabled = true;
            GlobalData.mainFormRef.button_EditThresholds.Enabled = true;
        }
    }
}