using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellcorder_Reporter
{
    public static class GlobalData
    {
        // the following two will be retained each time app is opened
        public static string csvStoragePath = null;
        public static string pdfOutputFolderPath = null;

        // reference to the main form
        public static main_Form mainFormRef = null;

        // reference to the file list datagridview
        public static DataGridView fileListDGV = null;

        // reference to the data preview datagridview
        public static DataGridView previewDataDGV = null;

        // storage for all the test readings in a dictionary for easy access
        public static Dictionary<string, TestResult> allTestReadings = new Dictionary<string, TestResult>();

        public static string currentlyViewingFile = "";
    }
}
