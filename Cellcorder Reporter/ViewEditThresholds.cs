using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cellcorder_Reporter
{
    public partial class ViewEditThresholds : Form
    {
        public ViewEditThresholds()
        {
            InitializeComponent();
        }

        private void ViewEditThresholds_Load(object sender, EventArgs e)
        {
            DisplayCurrentThresholds();
            
        }


        //---------------------------------------------------------------------
        //        display all the thresholds in the form
        //---------------------------------------------------------------------
        private void DisplayCurrentThresholds()
        {
            // check to see if there is a file selected
            if (GlobalData.currentlyViewingFile == "")
                return;

            // get the current test reading set
            TestResult currentResults = GlobalData.allTestReadings[GlobalData.currentlyViewingFile];

            // carry on and display.
            lowVolt_text.Text = currentResults.lowVoltage_threshold.ToString();
            highVolt_text.Text = currentResults.highVoltage_threshold.ToString();

            lowRes_text.Text = currentResults.lowResistance_threshold.ToString();
            highRes_text.Text = currentResults.highResistance_threshold.ToString();

            lowTemp_text.Text = currentResults.lowTemperature_threshold.ToString();
            highTemp_text.Text = currentResults.highTemperature_threshold.ToString();

            lowSG_text.Text = currentResults.lowSG_threshold.ToString();
            highSG_text.Text = currentResults.highSG_threshold.ToString();

            highIC1_text.Text = currentResults.highInterCell1_threshold.ToString();
            highIC2_text.Text = currentResults.highInterCell2_threshold.ToString();
            highIC3_text.Text = currentResults.highInterCell3_threshold.ToString();
            highIC4_text.Text = currentResults.highInterCell4_threshold.ToString();
        }

        private void button_CancelThresholds_Click(object sender, EventArgs e)
        {
            // just close the form and do nothing
            this.Close();
        }


        //---------------------------------------------------------------------
        //  save all the text back to the app testresult set ready for printing
        //---------------------------------------------------------------------
        private void button_SaveThresholds_Click(object sender, EventArgs e)
        {
            // now for validation, and log all errors to display when save button is pressed
            
            float LV;
            float HV;
            int LR;
            int HR;
            int LT;
            int HT;
            int LSG;
            int HSG;
            int HIC1;
            int HIC2;
            int HIC3;
            int HIC4;

            List<string> errors = new List<string>();
            if (float.TryParse(lowVolt_text.Text, out LV) == false)
            {
                errors.Add("Low float voltage incorrect format.  (0.00)\n");
            }
            if (float.TryParse(highVolt_text.Text, out HV) == false)
            {
                errors.Add("High float voltage incorrect format.  (0.00)\n");
            }
            if (int.TryParse(lowRes_text.Text, out LR) == false)
            {
                errors.Add("Low resistance incorrect format.  (0000)\n");
            }
            if (int.TryParse(highRes_text.Text, out HR) == false)
            {
                errors.Add("High resistance incorrect format.  (0000)\n");
            }
            if(int.TryParse(lowTemp_text.Text, out LT) == false)
            {
                errors.Add("Low temperature incorrect format.  (0000)\n");
            }
            if (int.TryParse(highTemp_text.Text, out HT) == false)
            {
                errors.Add("High temperature incorrect format.  (0000)\n");
            }
            if (int.TryParse(lowSG_text.Text, out LSG) == false)
            {
                errors.Add("Low SG incorrect format.  (0000)\n");
            }
            if (int.TryParse(highSG_text.Text, out HSG) == false)
            {
                errors.Add("High SG incorrect format.  (0000)\n");
            }
            if (int.TryParse(highIC1_text.Text, out HIC1) == false)
            {
                errors.Add("High Intertier 1 Resistance incorrect format.  (0000)\n");
            }
            if (int.TryParse(highIC2_text.Text, out HIC2) == false)
            {
                errors.Add("High Intertier 2 Resistance incorrect format.  (0000)\n");
            }
            if (int.TryParse(highIC3_text.Text, out HIC3) == false)
            {
                errors.Add("High Intertier 3 Resistance incorrect format.  (0000)\n");
            }
            if (int.TryParse(highIC4_text.Text, out HIC4) == false)
            {
                errors.Add("High Intertier 4 Resistance incorrect format.  (0000)\n");
            }

            // now to make sure some smart arse doesnt try to make low higher than high, cos it will happen :(
            if(LV > HV || LV == HV && LV !=0 && HV !=0)
            {
                errors.Add("low voltage cannot be higher than the high threshold!");
            }

            if (LR > HR || LR == HR && LR !=0 && HR !=0)
            {
                errors.Add("low resistance cannot be higher than the high threshold!");
            }

            if (LT > HT)
            {
                errors.Add("low temp cannot be higher than the high threshold!");
            }

            if (LSG > HSG && LSG != 0 && HSG != 0)
            {
                errors.Add("low SG cannot be higher than the high threshold!");
            }


            // if there are any errors, show to user
            if (errors.Count > 0)
            {
                errors.Add("\n\nCorrect the above and try again..");
                MessageBox.Show(string.Join<string>("", errors),
                    "the following entries have formatting errors..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // if there are no errors, write back to dataset and close form
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].lowVoltage_threshold = LV;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].highVoltage_threshold = HV;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].lowResistance_threshold = LR;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].highResistance_threshold = HR;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].lowTemperature_threshold = LT;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].highTemperature_threshold = HT;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].lowSG_threshold = LSG;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].highSG_threshold = HSG;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].highInterCell1_threshold = HIC1;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].highInterCell2_threshold = HIC2;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].highInterCell3_threshold = HIC3;
                GlobalData.allTestReadings[GlobalData.currentlyViewingFile].highInterCell4_threshold = HIC4;

                //now force a refresh on the preview data grid

                this.Close();
            }

        }
    }
}
