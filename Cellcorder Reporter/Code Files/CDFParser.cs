/// <summary>
///  THis is the code file that will parse an individual CSV file and return the complete
///  data set to be stored.
/// </summary>

using System;
using System.IO;
using Cellcorder_Reporter;



namespace Cellcorder_Reporter
{
    static class CDF_Parser
    {
        //---------------------------------------------------------------------
        // takes a string filename and returns a complete TestResult for a system
        //---------------------------------------------------------------------
        public static TestResult ParseCDF(String _CDF_FileToParse)
        {
            TestResult currentResult = new TestResult();

            // going to try using the  'using' statement, to try and GC easier
            using (StreamReader reader = new StreamReader(File.OpenRead(_CDF_FileToParse)))
            {
                String[] currentReadLine;
                String tempReadLine;


                // start off by getting some of the basic file details (Filename and the date the CSV was created)
                currentResult.fileName = Path.GetFileNameWithoutExtension(_CDF_FileToParse);
                //Console.WriteLine("filename : " + currentResult.fileName);
                currentResult.dateFileCreated = File.GetLastWriteTime(_CDF_FileToParse);
                //Console.WriteLine("datecreated : " + currentResult.dateFileCreated);

                // ignore a line
                currentReadLine = reader.ReadLine().Split(' '); // dont do anything with it!

                // get total string count
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.totalStrings = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("totalstrings : " + currentResult.totalStrings);

                // get location
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.location = tempReadLine;
                //Console.WriteLine("location :  " + tempReadLine);

                // get battery name
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.batteryName = tempReadLine;
                //Console.WriteLine("battery name " + tempReadLine);

                // get asset tag
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.stringName = tempReadLine;
                //Console.WriteLine("stringname " + tempReadLine);

                // get model number
                currentReadLine = reader.ReadLine().Trim().Split(' ');
                //Console.WriteLine("Mod Name : " + currentReadLine.Length);
                //Console.WriteLine("mod first part : " + currentReadLine[0]);
                if (currentReadLine.Length > 1)
                {
                    tempReadLine = currentReadLine[1].Replace("\"", "").Trim();
                    currentResult.modelNumber = tempReadLine;
                    //Console.WriteLine("model " + tempReadLine);
                }
                else
                {
                    currentResult.modelNumber = "Unspecified Model No";
                    //Console.WriteLine("model unspecified");
                }
                
                // just need to skip the next 3 lines of the CDF
                for(int i = 0; i <= 2; i++)
                {
                    currentReadLine = reader.ReadLine().Split(' '); // dont do anything with it, read it and move on!
                    //Console.WriteLine("skipped : " + currentReadLine[0]);
                }

                // get the number of cells in each string
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.cellsPerString = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("number of cells : " + tempReadLine);

                // just need to skip the next 3 lines of the CDF
                for (int i = 0; i <= 2; i++)
                {
                    currentReadLine = reader.ReadLine().Split(' '); // dont do anything with it, read it and move on!
                    //Console.WriteLine("skipped " + currentReadLine[0]);
                }

                // get install date
                //currentReadLine = reader.ReadLine().Split(' ');
                //string yearVal = currentReadLine[1].Trim().Substring(0,4);
                //string monthVal = currentReadLine[1].Trim().Substring(4, 2);
                //string dayVal = currentReadLine[1].Trim().Substring(6, 2);
                //DateTime date = new DateTime(int.Parse(yearVal), int.Parse(monthVal), int.Parse(dayVal));
                //currentResult.installDate = date.ToString();

                // get the high voltage threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                tempReadLine = tempReadLine.Insert(2, "."); // put a decimal point in there before parsing
                currentResult.highVoltage_threshold = float.Parse(tempReadLine);
                //Console.WriteLine("HV " + tempReadLine);

                // get the low voltage threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                tempReadLine = tempReadLine.Insert(2, "."); // put a decimal point in there before parsing
                currentResult.lowVoltage_threshold = float.Parse(tempReadLine);
                //Console.WriteLine("LV " + tempReadLine);

                // get the high resistance threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.highResistance_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("HR " + tempReadLine);

                // get the low resistance threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.lowResistance_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("LR " + tempReadLine);

                // get the high intercell 1 threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.highInterCell1_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("HIC 1 " + tempReadLine);

                // get the high intercell 2 threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.highInterCell2_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("HIC 2 " + tempReadLine);

                // get the high intercell 3 threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.highInterCell3_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("HIC 3 " + tempReadLine);

                // get the high intercell 4 threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.highInterCell4_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("HIC 4 " + tempReadLine);

                // setting the temperature scale here since its marked up at the end of this line
                currentResult.temperatureScale = TempScale.Fahrenheit;

                // get the high temperature threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.highTemperature_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("HT : " + tempReadLine);

                // get the low temperature threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.lowTemperature_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("LT : " + tempReadLine);

                // get the high SG threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.highSG_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("HS : " + tempReadLine);

                // get the low SG threshold
                currentReadLine = reader.ReadLine().Split(' ');
                tempReadLine = currentReadLine[1].Trim();
                currentResult.lowSG_threshold = Convert.ToUInt16(tempReadLine);
                //Console.WriteLine("LS : " + tempReadLine);

                // just need to skip the next 4 lines of the CDF
                for (int i = 0; i <= 3; i++)
                {
                    currentReadLine = reader.ReadLine().Split(' '); // dont do anything with it, read it and move on!
                    //Console.WriteLine("skipped : " + currentReadLine[0]);
                }


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
                        currentReadLine = streamedLine.Split(' ');
                        // now populate the current cell data object
                        currentCellData.stringNumber = Convert.ToInt16(currentReadLine[10]);
                        currentCellData.cellNumber = Convert.ToInt16(currentReadLine[1]);

                        string voltVal = currentReadLine[2];
                        voltVal = voltVal.Insert(2, "."); // put a decimal point in there before parsing
                        currentCellData.floatVoltage = float.Parse(voltVal);

                        currentCellData.resistance = Convert.ToInt16(currentReadLine[3]);
                        currentCellData.interCell_1_Resistance = Convert.ToInt16(currentReadLine[4]);
                        currentCellData.interCell_2_Resistance = Convert.ToInt16(currentReadLine[5]);
                        currentCellData.interCell_3_Resistance = Convert.ToInt16(currentReadLine[6]);
                        currentCellData.interCell_4_Resistance = Convert.ToInt16(currentReadLine[7]);
                        currentCellData.specificGravity = Convert.ToInt16(currentReadLine[9]);

                        string tempVal = currentReadLine[8];
                        tempVal = tempVal.Substring(1, 3); // need to remove the + first character
                        currentCellData.temperature = Convert.ToInt16(tempVal);  

                        currentResult.cellReadingsList.Add(currentCellData);
                        // so if this is the last cell in the last string, stop trying to parse any more
                        if (currentCellData.cellNumber == currentResult.cellsPerString && currentCellData.stringNumber == currentResult.totalStrings)
                            break;
                    }
                }
                else if (currentResult.totalStrings == 1)
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
                        currentReadLine = streamedLine.Split(' ');
                        // now populate the current cell data object
                        currentCellData.stringNumber = 1;
                        currentCellData.cellNumber = Convert.ToInt16(currentReadLine[1]);
                        string voltVal = currentReadLine[2];
                        voltVal = voltVal.Insert(2, "."); // put a decimal point in there before parsing
                        currentCellData.floatVoltage = float.Parse(voltVal);

                        currentCellData.resistance = Convert.ToInt16(currentReadLine[3]);
                        currentCellData.interCell_1_Resistance = Convert.ToInt16(currentReadLine[4]);
                        currentCellData.interCell_2_Resistance = Convert.ToInt16(currentReadLine[5]);
                        currentCellData.interCell_3_Resistance = Convert.ToInt16(currentReadLine[6]);
                        currentCellData.interCell_4_Resistance = Convert.ToInt16(currentReadLine[7]);
                        currentCellData.specificGravity = Convert.ToInt16(currentReadLine[9]);

                        string tempVal = currentReadLine[8];
                        tempVal = tempVal.Substring(1, 3); // need to remove the + first character
                        currentCellData.temperature = Convert.ToInt16(tempVal);

                        currentResult.cellReadingsList.Add(currentCellData);

                        // now if the current cell number matches the total string length break out
                        if (currentCellData.cellNumber == currentResult.cellsPerString)
                            break;
                    }

                }

            }
            // returns the completed set of test data for that system
            return currentResult;
        }
    }
}