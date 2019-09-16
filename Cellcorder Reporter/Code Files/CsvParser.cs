/// <summary>
///  THis is the code file that will parse an individual CSV file and return the complete
///  data set to be stored.
/// </summary>

using System;
using System.IO;
using Cellcorder_Reporter;



namespace Cellcorder_Reporter
{
    static class CSV_Parser
    {
        //---------------------------------------------------------------------
        // takes a string filename and returns a complete TestResult for a system
        //---------------------------------------------------------------------
        public static TestResult ParseCSV(String _CSVFileToParse)
        {
            TestResult currentResult = new TestResult();

            // going to try using the ' using statement, to try and GC easier
            using (StreamReader reader = new StreamReader(File.OpenRead(_CSVFileToParse)))
            {
                String[] currentReadLine;
                String tempReadLine;


                // start off by getting some of the basic file details (Filename and the date the CSV was created)
                currentResult.fileName = Path.GetFileNameWithoutExtension(_CSVFileToParse);
                currentResult.dateFileCreated = File.GetLastWriteTime(_CSVFileToParse);

                // get location
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.location = tempReadLine;

                // get battery name
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.batteryName = tempReadLine;

                // get total string count
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.totalStrings = Convert.ToUInt16(tempReadLine);

                // get model number
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.modelNumber = tempReadLine;

                // get install date
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.installDate = tempReadLine;

                // get the high voltage
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.highVoltage_threshold = float.Parse(tempReadLine);

                // get the low voltage threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.lowVoltage_threshold = float.Parse(tempReadLine);

                // get the high resistance threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.highResistance_threshold = Convert.ToUInt16(tempReadLine);

                // get the low resistance threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.lowResistance_threshold = Convert.ToUInt16(tempReadLine);

                // get the high intercell 1 threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.highInterCell1_threshold = Convert.ToUInt16(tempReadLine);

                // get the high intercell 2 threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.highInterCell2_threshold = Convert.ToUInt16(tempReadLine);

                // get the high intercell 3 threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.highInterCell3_threshold = Convert.ToUInt16(tempReadLine);

                // get the high intercell 4 threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.highInterCell4_threshold = Convert.ToUInt16(tempReadLine);

                // get the high temperature threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                // setting the temperature scale here since its marked up at the end of this line
                if (tempReadLine.EndsWith("F")) { currentResult.temperatureScale = TempScale.Fahrenheit; }
                else { currentResult.temperatureScale = TempScale.Celcius; }
                tempReadLine = tempReadLine.Remove(tempReadLine.Length - 1);
                currentResult.highTemperature_threshold = Convert.ToUInt16(tempReadLine);

                // get the low temperature threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                if (tempReadLine.EndsWith("F")) { currentResult.temperatureScale = TempScale.Fahrenheit; }
                else { currentResult.temperatureScale = TempScale.Celcius; }
                tempReadLine = tempReadLine.Remove(tempReadLine.Length - 1);
                currentResult.lowTemperature_threshold = Convert.ToUInt16(tempReadLine);

                // get the high SG threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.highSG_threshold = Convert.ToUInt16(tempReadLine);

                // get the low SG threshold
                currentReadLine = reader.ReadLine().Split(',');
                tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                currentResult.lowSG_threshold = Convert.ToUInt16(tempReadLine);

                // tested values up to this point !!!!!!!!!!!!!!!!!! all ok so far ;)


                //  !! This is the section that will read in all the individual cell readings, 
                // using the IF statement to determine if its multi string or not as these are handled in differently
                // since there are extra columns in a multi string reading
                if (currentResult.totalStrings > 1)
                {
                    while (!reader.EndOfStream)
                    {
                        CellReading currentCellData = new CellReading();
                        // grab the line and remove all the quotation marks
                        string streamedLine = reader.ReadLine();
                        streamedLine = streamedLine.Replace("\0", "").Trim();
                        // ok so if there is any blank lines on the next check, just break out as its done
                        if (streamedLine == "")
                        {
                            //Console.WriteLine("End of file reached. get outta here....");
                            break;
                        }
                        currentReadLine = streamedLine.Split(',');
                        // now populate the current cell data object
                        currentCellData.stringNumber = Convert.ToInt16(currentReadLine[1]);
                        currentCellData.cellNumber = Convert.ToInt16(currentReadLine[3]);
                        currentCellData.floatVoltage = float.Parse(currentReadLine[5]);
                        currentCellData.resistance = Convert.ToInt16(currentReadLine[7]);
                        currentCellData.interCell_1_Resistance = Convert.ToInt16(currentReadLine[9]);
                        currentCellData.interCell_2_Resistance = Convert.ToInt16(currentReadLine[11]);
                        currentCellData.interCell_3_Resistance = Convert.ToInt16(currentReadLine[13]);
                        currentCellData.interCell_4_Resistance = Convert.ToInt16(currentReadLine[15]);
                        currentCellData.specificGravity = Convert.ToInt16(currentReadLine[17]);
                        currentCellData.temperature = Convert.ToInt16(currentReadLine[19]);
                        currentResult.cellReadingsList.Add(currentCellData);
                    }
                }
                else if (currentResult.totalStrings == 1)
                {
                    //Console.WriteLine("one string and File : " + _CSVFileToParse);
                    while (!reader.EndOfStream)
                    {
                        CellReading currentCellData = new CellReading();
                        // grab the line and remove all the quotation marks
                        string streamedLine = reader.ReadLine();
                        streamedLine = streamedLine.Replace("\0", "").Trim();
                        // ok so if there is any blank lines on the next check, just break out as its done
                        if (streamedLine == "")
                        {
                            //Console.WriteLine("End of file reached. get outta here....");
                            break;
                        }
                        currentReadLine = streamedLine.Split(',');
                        // now populate the current cell data object
                        currentCellData.stringNumber = 1;
                        currentCellData.cellNumber = Convert.ToInt16(currentReadLine[1]);
                        currentCellData.floatVoltage = float.Parse(currentReadLine[3]);
                        currentCellData.resistance = Convert.ToInt16(currentReadLine[5]);
                        currentCellData.interCell_1_Resistance = Convert.ToInt16(currentReadLine[7]);
                        currentCellData.interCell_2_Resistance = Convert.ToInt16(currentReadLine[9]);
                        currentCellData.interCell_3_Resistance = Convert.ToInt16(currentReadLine[11]);
                        currentCellData.interCell_4_Resistance = Convert.ToInt16(currentReadLine[13]);
                        currentCellData.specificGravity = Convert.ToInt16(currentReadLine[15]);
                        currentCellData.temperature = Convert.ToInt16(currentReadLine[17]);
                        currentResult.cellReadingsList.Add(currentCellData);
                    }

                }

            }
            // returns the completed set of test data for that system
            return currentResult;
        }
    }
}