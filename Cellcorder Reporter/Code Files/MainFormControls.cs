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

            Console.WriteLine("count of all test readings : " + GlobalData.allTestReadings.Count);
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


        ////---------------------------------------------------------------------
        ////    handle the test parse button click
        ////---------------------------------------------------------------------
        //public static TestResult ProcessParsing(String _fileToParse)
        //{
        //        TestResult tempResult = Parser.ParseCSV(_fileToParse);
        //}

       
    }
}