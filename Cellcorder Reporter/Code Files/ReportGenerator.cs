using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// migradoc references
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Cellcorder_Reporter;

// aliases
using TabAlignment = MigraDoc.DocumentObjectModel.TabAlignment;
using System.Globalization;

namespace Cellcorder_Reporter
{
    public static class CellcorderReporting
    {
        // use this to store the current reading set for each report
        static TestResult currentResult = null;

        public static void CreatePDFReport(string fileName)
        { 
            // grab the test result set that were reporting on
            currentResult = GlobalData.allTestReadings[fileName];
            // Create the MigraDoc document this will populate the contents
            Document document = CreateDocument();
            // define the pdf renderer object
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            // define the document to render
            renderer.Document = document;
            // render out the pdf document
            renderer.RenderDocument();

            // Save the document with the date and time on end of string...
            DateTime currentTime = DateTime.Now;


            string fileToSave = fileName + "_" + currentTime.ToShortDateString().Replace("/", "") +
                currentTime.ToShortTimeString().Replace(":", "")
                + ".pdf";

            renderer.Save(GlobalData.pdfOutputFolderPath + "\\" + fileToSave);
            //renderer = null;
            //document = null;
        }

        //---------------------------------------------------------------------
        // this will create the document and populate all the content of it
        //---------------------------------------------------------------------

        public static Document CreateDocument()
        {
            // Create a new MigraDoc document
            Document document = new Document();
            document.Info.Title = "Norco Cellcorder Report";
            document.Info.Subject = "Auto Generated PDF report for Cellcorder Data";
            document.Info.Author = "Application Created by : Darren McBain";


            // this will create the different sections that will make up the report
            // Create all the styles for use within the document
            DefineStyles(document);
            // define create and add the cover sheet
            DefineCover(document);
            // define, create and add the headers and footers
            DefineHeadersAndFooters(document);
            // now create the tabluated cell data
            DefineTabulatedData(document);
            // create the float voltage chart
            DefineVoltageChart(document);
            // create the resistance value charting
            DefineResistanceChart(document);
            // now add the last comments section
            DefineCommentsSection(document);
            // Finally return the completed document for rendering
            return document;


            //DefineTableOfContents(document);
            //DefineContentSection(document);
            //DefineParagraphs(document);
            //DefineTables(document);
        }

        /// THis method defines all the styles that are to be used in the document
        public static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";
            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks)
            // in PDF.
            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;

            style = document.Styles.AddStyle("Hidden", "Normal");
            style.Font.Size = 1;
            style.Font.Bold = false;
            style.Font.Color = Colors.White;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 0;
            style.ParagraphFormat.SpaceAfter = 0;
        }

        /// Defines the cover page.  DONE
        static void DefineCover(Document document)
        {
            Section section = document.AddSection();

            Paragraph paragraph = section.AddParagraph("Cover Sheet", "Hidden");
            paragraph.Format.OutlineLevel = OutlineLevel.Level1;

            paragraph.Format.SpaceAfter = "3cm";

            // adding the LOGO
            Image image = section.AddImage("NorcoLogo.png");
            image.Width = "10cm";
            image.Left = ShapePosition.Center ;

            // report title
            paragraph = section.AddParagraph("Battery Resistance Testing Report");
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Size = 30;
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Underline = Underline.Single;
            paragraph.Format.SpaceBefore = "3cm";
            paragraph.Format.SpaceAfter = "1cm";

            // test location
            paragraph = section.AddParagraph(currentResult.location);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Size = 22;
            paragraph.Format.Font.Color = Colors.Black;
            paragraph.Format.SpaceBefore = "3cm";
            paragraph.Format.SpaceAfter = "1cm";

            // test battery system
            paragraph = section.AddParagraph(currentResult.batteryName);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Size = 22;
            paragraph.Format.Font.Color = Colors.Black;
            //paragraph.Format.SpaceBefore = "3cm";
            paragraph.Format.SpaceAfter = "5cm";
            paragraph = section.AddParagraph("Report Generated on : ");
            paragraph.AddDateField();
        }

        // define the headers and footers
        static void DefineHeadersAndFooters(Document doc)
        {
            Section section = doc.AddSection();
            HeaderFooter headers = section.Headers.Primary;
            Paragraph para = headers.AddParagraph(currentResult.batteryName);
            para.Style = "Heading2";
            para.Format.Font.Color = Colors.Black;
            para.Format.Alignment = ParagraphAlignment.Center;
            para.Format.OutlineLevel = OutlineLevel.BodyText;

            // now to add the table so that its got 3 columns, this is just the column spacings
            Table table = headers.AddTable();
            table.Format.Alignment = ParagraphAlignment.Center;
            table.Borders.Visible = false;
            Column col = table.AddColumn("5cm");
            col.Format.Alignment = ParagraphAlignment.Left;
            col = table.AddColumn("6cm");
            col.Format.Alignment = ParagraphAlignment.Center;
            col = table.AddColumn("5cm");
            col.Format.Alignment = ParagraphAlignment.Right;

            // now we have to add rows to these columns, but only going to populate the left and right, for the first row
            Row row = table.AddRow();
            Paragraph rowPara = row.Cells[0].AddParagraph("Battery Dataset Detail Report");
            rowPara.Format.OutlineLevel = OutlineLevel.BodyText;
            rowPara.Format.Font.Color = Colors.DarkBlue;
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Bold = true;
            rowPara.Format.Font.Italic = true;
            rowPara = row.Cells[2].AddParagraph("Install Date : " + currentResult.installDate);
            rowPara.Format.Font.Color = Colors.Black;
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Bold = true;

            // now for the second row, using all three column cells, batt Tag, block type, Location
            row = table.AddRow();
            rowPara = row.Cells[0].AddParagraph(currentResult.fileName);
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Color = Colors.Black;
            rowPara.Format.Font.Bold = true;
            rowPara = row.Cells[1].AddParagraph(currentResult.modelNumber);
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Color = Colors.Black;
            rowPara.Format.Font.Bold = true;
            rowPara = row.Cells[2].AddParagraph(currentResult.location);
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Color = Colors.Black;
            rowPara.Format.Font.Bold = true;

            // now add a blank colored bar across page, cant mind what its called so
            para = headers.AddParagraph();
            para.Format.OutlineLevel = OutlineLevel.BodyText;
            para.Format.Alignment = ParagraphAlignment.Center;
            Border border = para.Format.Borders.Bottom;
            border.Width = 2;
            border.Color = Colors.DarkRed;

            table = headers.AddTable();
            headers.Format.Alignment = ParagraphAlignment.Center;
            table.Borders.Visible = false;
            col = table.AddColumn("8cm");
            col.Format.Alignment = ParagraphAlignment.Left;
            col = table.AddColumn("8cm");
            col.Format.Alignment = ParagraphAlignment.Center;

            row = table.AddRow();
            rowPara = row.Cells[0].AddParagraph("Readings Taken : " + currentResult.dateFileCreated);
            rowPara = row.Cells[1].AddParagraph("Overall Float Voltage : " + currentResult.GetOverallFloatVoltage() + " V");
            // stick another line below everything in the header

            // now add a blank colored bar across page, cant mind what its called so
            para = headers.AddParagraph();
            para.Format.Alignment = ParagraphAlignment.Center;
            border = para.Format.Borders.Top;
            border.Width = 2;
            border.Color = Colors.DarkRed;
        }

        // create the tablulated date from the results
        static void DefineTabulatedData(Document doc)
        {
            // need to show a table of results for each string in the result set.
            for (int stringID = 1; stringID <= currentResult.totalStrings; stringID++)
            {
                CreateStringTabulatedData(doc, currentResult, stringID);
            }
        }

        // create the tabular data for the PDF reports, called from DefineTabulatedData()
        static void CreateStringTabulatedData(Document doc, TestResult testResult, int _stringNumber)
        {
            doc.LastSection.AddPageBreak();
            
            //Console.WriteLine("heres the string number : " + _stringNumber);
            // now sure how to set this globally yet, so ill just do it per section
            Section section = doc.LastSection;

            // Add a hidden bookmark for the tabulated page ;)
            Paragraph paragraph = section.AddParagraph("Tabulated Data", "Hidden");
            paragraph.Format.OutlineLevel = OutlineLevel.Level1;

            section.PageSetup.TopMargin = 200; // for Header
            section.PageSetup.BottomMargin = 100; // for Footer


            // set up the table main parameters and settings
            Table tableData = section.AddTable();
            tableData.Format.Alignment = ParagraphAlignment.Left;
            tableData.Format.Borders.Visible = true;
            tableData.Format.Borders.Width = 0;
            Column col = tableData.AddColumn("2cm");
            col = tableData.AddColumn("2cm");
            col = tableData.AddColumn("2cm");
            col = tableData.AddColumn("2cm");
            col = tableData.AddColumn("2cm");
            col = tableData.AddColumn("2cm");
            col = tableData.AddColumn("2cm");
            col = tableData.AddColumn("2cm");

            // ok now heres the table headings 
            Row row = tableData.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;
            row.Cells[0].AddParagraph("String No.");
            row.Cells[1].AddParagraph("Cell/Jar No.");
            row.Cells[2].AddParagraph("Cell/Jar Voltage");
            row.Cells[3].AddParagraph("Internal Resistance ");
            row.Cells[4].AddParagraph("icR 1");
            row.Cells[5].AddParagraph("icR 2");
            row.Cells[6].AddParagraph("icR 3");
            row.Cells[7].AddParagraph("icR 4");


            foreach (CellReading cell in testResult.cellReadingsList)
            {
                if (cell.stringNumber == _stringNumber)
                {
                    row = tableData.AddRow();
                    row.Cells[0].AddParagraph(cell.stringNumber.ToString());
                    row.Cells[1].AddParagraph(cell.cellNumber.ToString());
                    row.Cells[2].AddParagraph(String.Format("{0:0.00}", cell.floatVoltage));
                    // this is for coloring the high and low cell voltages
                    if (currentResult.highVoltage_threshold == currentResult.lowVoltage_threshold)
                    {
                        // dont color anything since both thresholds are exactly the same
                    }
                    else if (cell.floatVoltage > currentResult.highVoltage_threshold)
                    {
                        row.Cells[2].Format.Shading.Color = Colors.IndianRed;
                    }
                    else if (cell.floatVoltage < currentResult.lowVoltage_threshold)
                    {
                        row.Cells[2].Format.Shading.Color = Colors.Yellow;
                    }
                    row.Cells[3].AddParagraph(cell.resistance.ToString());
                    
                    // this is for coloring the table for high and low resistances
                    if (currentResult.lowResistance_threshold == currentResult.highResistance_threshold)
                    {
                        // dont color anything since both thresholds are exactly the same
                    }
                    else if (cell.resistance > currentResult.highResistance_threshold)
                    {
                        row.Cells[3].Format.Shading.Color = Colors.IndianRed;
                    }
                    else if (cell.resistance < currentResult.lowResistance_threshold)
                    {
                        row.Cells[3].Format.Shading.Color = Colors.Yellow;
                    }
                    row.Cells[4].AddParagraph(cell.interCell_1_Resistance.ToString());
                    row.Cells[5].AddParagraph(cell.interCell_2_Resistance.ToString());
                    row.Cells[6].AddParagraph(cell.interCell_3_Resistance.ToString());
                    row.Cells[7].AddParagraph(cell.interCell_4_Resistance.ToString());
                }

            }

        }

        // TODO :  need to get the table of contents done at a later stage
        //static void DefineTableOfContents(Document document)
        //{
        //    Section section = document.LastSection;

        //    section.AddPageBreak();
        //    Paragraph paragraph = section.AddParagraph("Table of Contents");
        //    //paragraph.AddBookmark("Table of contents");
        //    paragraph.Format.Font.Size = 14;
        //    paragraph.Format.Font.Bold = true;
        //    paragraph.Format.SpaceAfter = 24;
        //    paragraph.Format.OutlineLevel = OutlineLevel.Level1;

        //    // this should add a hyper link to the table of contents
        //    paragraph = section.AddParagraph();
        //    paragraph.Style = "TOC";
        //    Hyperlink hyperlink = paragraph.AddHyperlink("CoverSheet");
        //    hyperlink.AddText("Cover Sheet\t");
        //    hyperlink.AddPageRefField("Cover Sheet");

        //    paragraph = section.AddParagraph();
        //    paragraph.Style = "TOC";
        //    hyperlink = paragraph.AddHyperlink("Paragraphs");
        //    hyperlink.AddText("Paragraphs\t");
        //    hyperlink.AddPageRefField("Paragraphs");

        //    paragraph = section.AddParagraph();
        //    paragraph.Style = "TOC";
        //    hyperlink = paragraph.AddHyperlink("Tables");
        //    hyperlink.AddText("Tables\t");
        //    hyperlink.AddPageRefField("Tables");

        //    paragraph = section.AddParagraph();
        //    paragraph.Style = "TOC";
        //    hyperlink = paragraph.AddHyperlink("Charts");
        //    hyperlink.AddText("Charts\t");
        //    hyperlink.AddPageRefField("Charts");
        //}

        // create the charting page for the voltages
        static void DefineVoltageChart(Document document)
        {
            Paragraph paragraph = document.LastSection.AddParagraph("Battery Voltage Chart", "Heading1");
            
            //paragraph.Format.OutlineLevel = OutlineLevel.Level1;
            //paragraph.AddBookmark("VoltageChart");

            paragraph = document.LastSection.AddParagraph("Cell Voltages", "Heading2");
            paragraph.Format.OutlineLevel = OutlineLevel.BodyText;

            Chart chart = new Chart();
            chart.Left = 0;

            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);

            Series series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Column2D;

            // create an array of all the battery cell voltages and cell numbers to use as values
            List<double> cellVoltageValues = new List<double>();
            List<string> cellXlabels = new List<string>();

            // depending on the number of cells, need to suss out a gap say every 10%
            int xSpacing = (int)(currentResult.cellReadingsList.Count * 0.1);
            if (xSpacing < 1)
                xSpacing = 1;

            foreach (CellReading reading in currentResult.cellReadingsList)
            {
                //add the resistance values to the table series
                cellVoltageValues.Add(reading.floatVoltage);
                // add the corresponding x labelling to the series, but try and space them out if theres alot 

                if (reading.cellNumber % xSpacing == 0)
                {
                    cellXlabels.Add(reading.cellNumber.ToString());
                    //Console.WriteLine(reading.cellNumber.ToString());
                }
                else
                {
                    cellXlabels.Add("");
                }
            }

            // now add the voltage data to the chart series
            series.Add(cellVoltageValues.ToArray());
            series.HasDataLabel = false;

            // now to color the bar graph for the voltages depending on the current test thresholds
            var elements = series.Elements.Cast<Point>().ToArray();
            // since each of the elements will be the same index as the readings, loop through and color accordingly
            int counterIndex = 0;
            foreach (CellReading reading in currentResult.cellReadingsList)
            {
                if (currentResult.highVoltage_threshold == currentResult.lowVoltage_threshold)
                {
                    elements[counterIndex].FillFormat.Color = Colors.Green;
                }
                else if (reading.floatVoltage > currentResult.highVoltage_threshold)
                {
                    elements[counterIndex].FillFormat.Color = Colors.Red;
                }
                else if (reading.floatVoltage < currentResult.lowVoltage_threshold)
                {
                    elements[counterIndex].FillFormat.Color = Colors.Yellow;
                }
                else
                {
                    elements[counterIndex].FillFormat.Color = Colors.Green;
                }
                counterIndex++;
            }


            // create the xlabel series and add the cell numbers
            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add(cellXlabels.ToArray());

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "Cell Numbers";

            chart.YAxis.MajorTickMark = TickMarkType.Outside;

            // heres the ymin and max reading values
            double yMin, yMax;
            yMin = currentResult.GetMinFloatValueAsDouble();
            yMax = currentResult.GetMaxFloatValueAsDouble();

            // need to set the Y axis scale to something that wont overlap if too small

            chart.YAxis.MajorTick = (yMax-yMin) * 0.1; // so a tenth of the overall size
            chart.YAxis.TickLabels.Format = "0.00";
            chart.YAxis.HasMajorGridlines = true;

            
            // now to set up the Y axis scales, need to get the min and max floats and put a small tollerance either side
            

            // just so that the min and max values arent slap bang on the axis lines
            double chartYAxisPadding = (yMax - yMin) * 0.1; // just 10 percent padding for min and max charting values

            chart.YAxis.MinimumScale = currentResult.GetMinFloatValueAsDouble() - chartYAxisPadding;
            chart.YAxis.MaximumScale = currentResult.GetMaxFloatValueAsDouble() + chartYAxisPadding;

            chart.PlotArea.LineFormat.Color = Colors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;

            document.LastSection.Add(chart);
        }

        // define the charting page for the resistance values
        static void DefineResistanceChart(Document document)
        {
            Paragraph paragraph = document.LastSection.AddParagraph("Battery Resistance Chart", "Heading1");
            //paragraph.AddBookmark("ResistanceChart");

            paragraph = document.LastSection.AddParagraph("Cell Resistances", "Heading2");
            paragraph.Format.OutlineLevel = OutlineLevel.BodyText;

            Chart chart = new Chart();
            chart.Left = 0;

            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);

            Series series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Column2D;

            // create an array of all the battery cell voltages and cell numbers to use as values
            List<double> resistanceValuesList = new List<double>();
            List<string> cellXlabels = new List<string>();

            // depending on the number of cells, need to suss out a gap say every 10%
            int xSpacing = (int)(currentResult.cellReadingsList.Count * 0.1);
            if (xSpacing < 1)
                xSpacing = 1;

            foreach (CellReading reading in currentResult.cellReadingsList)
            {
                //add the resistance values to the table series
                resistanceValuesList.Add(reading.resistance);
                // add the corresponding x labelling to the series, but try and space them out if theres alot 

                if(reading.cellNumber % xSpacing == 0)
                {
                    cellXlabels.Add(reading.cellNumber.ToString());
                    //Console.WriteLine(reading.cellNumber.ToString());
                }
                else
                {
                    cellXlabels.Add("");
                }
            }

            // now add the voltage data to the chart series
            series.Add(resistanceValuesList.ToArray());
            series.HasDataLabel = false;

            // now to color the bar graph for the resistance values depending on the current test thresholds
            var elements = series.Elements.Cast<Point>().ToArray();
            // since each of the elements will be the same index as the readings, loop through and color accordingly
            int counterIndex = 0;
            foreach (CellReading reading in currentResult.cellReadingsList)
            {
                if (currentResult.lowResistance_threshold == currentResult.highResistance_threshold)
                {
                    elements[counterIndex].FillFormat.Color = Colors.Blue;
                }
                else if (reading.resistance > currentResult.highResistance_threshold)
                {
                    elements[counterIndex].FillFormat.Color = Colors.Red;
                }
                else if (reading.resistance < currentResult.lowResistance_threshold)
                {
                    elements[counterIndex].FillFormat.Color = Colors.Yellow;
                }
                else
                {
                    elements[counterIndex].FillFormat.Color = Colors.Blue;
                }
                counterIndex++;
            }

            // create the xlabel series and add the cell numbers
            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add(cellXlabels.ToArray());

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "Cell Numbers";

            // y values min and max
            double yMin, yMax;
            yMin = currentResult.GetMinResistanceValueAsDouble();
            yMax = currentResult.GetMaxResistanceValueAsDouble();

            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.MajorTick = (yMax-yMin) * 0.1;
            //chart.YAxis.TickLabels.Format = "0";
            chart.YAxis.HasMajorGridlines = true;

            // now to set up the Y axis scales, need to get the min and max floats and put a small tollerance either side
            // just so that the min and max values arent slap bang on the axis lines
           
            double chartYAxisPadding = (yMax - yMin) * 0.1; // just 10 percent padding for min and max charting values

            chart.YAxis.MinimumScale = currentResult.GetMinResistanceValueAsDouble() - chartYAxisPadding;
            chart.YAxis.MaximumScale = currentResult.GetMaxResistanceValueAsDouble() + chartYAxisPadding;

            chart.PlotArea.LineFormat.Color = Colors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;

            document.LastSection.Add(chart);
        }

        // now to pop the comments in at the end of the document
        static void DefineCommentsSection(Document document)
        {
            Paragraph paragraph = document.LastSection.AddParagraph("Closing Report Comments", "Heading1");
            //paragraph.AddBookmark("Comments");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.OutlineLevel = OutlineLevel.BodyText;
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.AddText(currentResult.comments);
        }

    }
}
