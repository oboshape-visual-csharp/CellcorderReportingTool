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


        // storage for all the test readings in a dictionary for easy access
        public static Dictionary<string, TestResult> allTestReadings = new Dictionary<string, TestResult>();
    }
}
