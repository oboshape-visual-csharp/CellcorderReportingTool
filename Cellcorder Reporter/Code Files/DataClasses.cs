using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cellcorder_Reporter
{
    // to declare what temperature scale the readings are using
    enum TempScale
    {
        Celcius,
        Fahrenheit,
        UNSET
    };

    // this is the class for storing all the readings for one single cell
    class CellReading
    {
        public CellReading()
        {
            stringNumber = 1;  // dont know why ive put this here ??
        }
        public int stringNumber; // hopefully this is already set so i can bin constructor
        public int cellNumber;
        public float floatVoltage;
        public int resistance;
        public int interCell_1_Resistance;
        public int interCell_2_Resistance;
        public int interCell_3_Resistance;
        public int interCell_4_Resistance;
        public int specificGravity;
        public int temperature;
    }


    // this one is the to store one complete system set of readings
    // there are also some helper methods so they can be called on each test reading set
    class TestResult
    {
        public TestResult()
        {
            Reading = new List<CellReading>();
            location = "";
            batteryName = "";
            modelNumber = "";
            installDate = "";
            dateFileCreated = DateTime.Now;
            temperatureScale = TempScale.UNSET;
        }
        public string       fileName;
        public DateTime     dateFileCreated;
        public String       location;
        public String       batteryName;
        public int          totalStrings;
        public String       modelNumber;
        public String       installDate;
        public float        highVoltage_threshold;
        public float        lowVoltage_threshold;
        public int          highResistance_threshold;
        public int          lowResistance_threshold;
        public int          highInterCell1_threshold;
        public int          highInterCell2_threshold;
        public int          highInterCell3_threshold;
        public int          highInterCell4_threshold;
        public int          highTemperature_threshold;
        public int          lowTemperature_threshold;
        public int          highSG_threshold;
        public int          lowSG_threshold;
        public TempScale    temperatureScale;
        public List<CellReading> Reading;


        //---------------------------------------------------------------------
        //   helper methids for getting data from the test results
        //---------------------------------------------------------------------

        public CellReading GetMaxResistance()
        {
            CellReading maxObject = Reading.OrderByDescending(item => item.resistance).First();
            return maxObject;
        }

        public CellReading GetMinResistance()
        {
            CellReading minObject = Reading.OrderByDescending(item => item.resistance).Last();
            return minObject;
        }

        // method to return the max float voltage of system
        public CellReading GetMaxFloat()
        {
            CellReading maxObject = Reading.OrderByDescending(item => item.floatVoltage).First();
            return maxObject;
        }

        // method to return the minimum float voltage reading of system
        public CellReading GetMinFloat()
        {
            CellReading minObject = Reading.OrderByDescending(item => item.floatVoltage).Last();
            return minObject;
        }

        // need to set the overall float voltage used via property in class
        public float GetOverallFloatVoltage()
        {
            float totalVolts = 0f;
            foreach (CellReading cell in Reading.Where(val => val.stringNumber == 1))
            {
                totalVolts += cell.floatVoltage;
            }
            return totalVolts;
        }


    }

}
