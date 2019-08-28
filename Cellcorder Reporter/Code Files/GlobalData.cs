using System;
using System.Collections.Generic;
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

        // this will be set to null on closing app
        public static string[] fileListArray = null;

        // datatable that stores the information for the file listing shown on main screen
        public static DataTable fileListDataTable = new DataTable();
    }
}
