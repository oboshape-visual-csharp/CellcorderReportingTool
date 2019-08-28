/// <summary>
///  THis is the code file that will parse an individual CSV file and return the complete
///  data set to be stored.
/// </summary>

using System;
using System.IO;
using Cellcorder_Reporter;



namespace Cellcorder_Reporter
{
    static class Parser
    {
        //---------------------------------------------------------------------
        // takes a string array with all the filenames and returns a List of TestResult
        //---------------------------------------------------------------------
        public static TestResult ParseCSV(String _CSVFilesToParse)
        {
            TestResult currentResult = new TestResult();
            var reader = new StreamReader(_CSVFilesToParse);
            String[] currentReadLine;
            String tempReadLine;
        }







    }
}