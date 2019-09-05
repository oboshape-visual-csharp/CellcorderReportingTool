using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Shapes;
using PdfSharp.Pdf;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using System.Linq;
using PdfSharp.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Threading.Tasks;

namespace CSV_Reporter
{
    

    public partial class frm_Main : Form

    {
        List<TestResult> allTestReadings = new List<TestResult>();

        public frm_Main()

        {

            InitializeComponent(); 
        }

        private async Task GeneratePDFFile(TestResult currentResult)  // using MigraDoc
        {

            // initially create the empty docuemnt object
            Document myDocument = new Document();
            // define all the styles that will be used in the PDF
            DefineDocumentStyles(myDocument);
            // create the first coversheet
            CreateCoverSheet(myDocument, currentResult);
            // create the headers and footers
            CreateHeadersAndFooters(myDocument, currentResult);
            // populate the data on the sheet
            ShowData(myDocument, currentResult);

            HelperMethods.Create2DStackedChart(myDocument, currentResult);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);

            pdfRenderer.Document = myDocument;
            pdfRenderer.RenderDocument();
            string fileNameToUse = currentResult.fileName + ".PDF";
            System.IO.Directory.CreateDirectory(AppGlobals.pdfOutputFolderPath);
            await Task.Run(() => pdfRenderer.PdfDocument.Save(AppGlobals.pdfOutputFolderPath + "/" + fileNameToUse));
            Console.WriteLine("document written");



            // just launches the file to view, only use for testing
            System.Diagnostics.Process.Start(AppGlobals.pdfOutputFolderPath);
        }


        // defining the general styles components of the document
        void DefineDocumentStyles(Document doc)
        {
            // initially start with Normal default and derive from it
            Style style = doc.Styles["Normal"];
            style.Font.Name = "Times New Roman";

            // heading1 to Heading9 are predefined styles with an outline level.
            // an outline level other than OutlineLevel.BodyText automatically
            // creates the outline (or bookmarks) in the PDF

            style = doc.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = doc.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = doc.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = doc.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
            style = doc.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = doc.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = doc.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;

        }


        // create the details for the main cover sheet of the report
        void CreateCoverSheet(Document doc, TestResult testResult)
        {
            Section section = doc.AddSection();
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.SpaceAfter = "1cm";

            Image image = section.AddImage("NorcoLogo.png");
            image.Width = "8cm";

            paragraph = section.AddParagraph("Battery Resistance Testing DataSet for :");
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = Colors.DarkRed;
            paragraph.Format.SpaceBefore = "3cm";
            paragraph.Format.SpaceAfter = "1cm";
            paragraph = section.AddParagraph(testResult.location + ", " + testResult.batteryName);
            paragraph.Format.Font.Size = 12;
            paragraph.Format.Font.Color = Colors.DarkRed;
            paragraph.Format.SpaceAfter = "5cm";
            paragraph = section.AddParagraph("Rendering date: ");
            paragraph.AddDateField();
        }


        // create the headers and footers
        void CreateHeadersAndFooters(Document doc, TestResult testResult)
        {
            // ok so heres the main title of the header, should be the battery name
            Section section = doc.AddSection();
            HeaderFooter headers = section.Headers.Primary;
            Paragraph para = headers.AddParagraph(testResult.batteryName);
            para.Style = "Heading2";
            para.Format.Font.Color = Colors.Black;
            para.Format.Alignment = ParagraphAlignment.Center;

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
            rowPara.Format.Font.Color = Colors.DarkBlue;
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Bold = true;
            rowPara.Format.Font.Italic = true;
            rowPara = row.Cells[2].AddParagraph("Install Date : " + GetDateString(testResult.installDate));
            rowPara.Format.Font.Color = Colors.Black;
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Bold = true;

            // now for the second row, using all three column cells, batt Tag, block type, Location
            row = table.AddRow();
            rowPara = row.Cells[0].AddParagraph(testResult.fileName);
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Color = Colors.Black;
            rowPara.Format.Font.Bold = true;
            rowPara = row.Cells[1].AddParagraph(testResult.modelNumber);
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Color = Colors.Black;
            rowPara.Format.Font.Bold = true;
            rowPara = row.Cells[2].AddParagraph(testResult.location);
            rowPara.Format.Font.Size = 11;
            rowPara.Format.Font.Color = Colors.Black;
            rowPara.Format.Font.Bold = true;

            // now add a blank colored bar across page, cant mind what its called so
            para = headers.AddParagraph();
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
            rowPara = row.Cells[0].AddParagraph("Readings Taken : " + testResult.dateFileCreated);
            rowPara = row.Cells[1].AddParagraph("Overall Float Voltage : " + testResult.overallVoltage + " V");
            // stick another line below everything in the header

            // now add a blank colored bar across page, cant mind what its called so
            para = headers.AddParagraph();
            para.Format.Alignment = ParagraphAlignment.Center;
            border = para.Format.Borders.Top;
            border.Width = 2;
            border.Color = Colors.DarkRed;
        }


        void ShowData(Document doc, TestResult testResult)
        {

            // need to show a table of results for each string in the result set.
            for (int stringID = 1; stringID <= testResult.totalStrings; stringID++)
            {
                CreateStringTabulatedData(doc, testResult, stringID);
            }
        }

        // create the tabular data for the PDF reports, called from ShowData()
        private static void CreateStringTabulatedData(Document doc, TestResult testResult, int _stringNumber)
        {
            doc.LastSection.AddPageBreak();
            //Console.WriteLine("heres the string number : " + _stringNumber);
            // now sure how to set this globally yet, so ill just do it per section
            Section section = doc.LastSection;
            section.PageSetup.TopMargin = 130; // for Header
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


            foreach (CellReading cell in testResult.Reading)
            {
                if (cell.stringNumber == _stringNumber)
                {
                    row = tableData.AddRow();
                    row.Cells[0].AddParagraph(cell.stringNumber.ToString());
                    row.Cells[1].AddParagraph(cell.cellNumber.ToString());
                    row.Cells[2].AddParagraph(String.Format("{0:0.00}", cell.floatVoltage));
                    row.Cells[3].AddParagraph(cell.resistance.ToString());
                    row.Cells[4].AddParagraph(cell.interCell_1_Resistance.ToString());
                    row.Cells[5].AddParagraph(cell.interCell_2_Resistance.ToString());
                    row.Cells[6].AddParagraph(cell.interCell_3_Resistance.ToString());
                    row.Cells[7].AddParagraph(cell.interCell_4_Resistance.ToString());
                }

            }

        }


        // //// this is going to be for addding the bar graph at the end of the report
        //private static void CreateCharts(Document document, TestResult testResult)
        // {

        // //    //Chart chart = new Chart(ChartType.ColumnStacked2D);
        // //    //Series series = chart.SeriesCollection.AddSeries();
        // //    //series.Name = "Series 1";
        // //    //series.Add(new double[] { 1, 5, -3, 20, 11 });

        // //    //series = chart.SeriesCollection.AddSeries();
        // //    //series.Name = "Series 2";
        // //    //series.Add(new double[] { 22, 4, 12, 8, 12 });

        // //    //series = chart.SeriesCollection.AddSeries();
        // //    //series.Name = "Series 3";
        // //    //series.Add(new double[] { 12, 14, 2, 18, 1 });

        // //    //series = chart.SeriesCollection.AddSeries();
        // //    //series.Name = "Series 4";
        // //    //series.Add(new double[] { 17, 13, 10, 9, 15 });

        // //    //chart.XAxis.TickLabels.Format = "00";
        // //    //chart.XAxis.MajorTickMark = TickMarkType.Outside;
        // //    //chart.XAxis.Title.Caption = "X-Axis";

        // //    //chart.YAxis.MajorTickMark = TickMarkType.Outside;
        // //    //chart.YAxis.HasMajorGridlines = true;

        // //    //chart.PlotArea.LineFormat.Color = Color.Parse("Red");
        // //    //chart.PlotArea.LineFormat.Width = 50;
        // //    //chart.PlotArea.LineFormat.Visible = true;

        // //    ////chart.format

        // //    ////chart.Legend.Docking = DockingType.Right;

        // //    //chart.DataLabel.Type = DataLabelType.Value;
        // //    //chart.DataLabel.Position = DataLabelPosition.Center;
        //     //document.LastSection.Add(chart);
        //     Paragraph paragraph = document.LastSection.AddParagraph("BarGraph Data", "Heading1");
        //     paragraph.AddBookmark("Charts");

        //     document.LastSection.AddParagraph("Voltage Graph", "Cell / Jar Voltages");
        //     Chart chart = new Chart();

        //     chart.Left = 0;

        //     chart.Width = Unit.FromCentimeter(16);
        //     chart.Height = Unit.FromCentimeter(6);

        //     Series series = chart.SeriesCollection.AddSeries();
        //     series.ChartType = ChartType.Column2D;
        //     List<Double> valueList = new List<Double>();


        //     foreach (var reading in testResult.Reading)
        //     {
        //         //series.Add(reading.floatVoltage);
        //         valueList.Add(reading.floatVoltage);
        //     }
        //     series.HasDataLabel = true;
        //     Double[] valueListArray = valueList.ToArray();
        //     series.Add(valueListArray);
        //     XSeries xseries = chart.XValues.AddXSeries();
        //     // this next three lines is purely to set the numbering of the xaxis
        //     int[] cellRangeArray = Enumerable.Range(0, testResult.Reading.Count + 1).ToArray();
        //     string[] xAxisElementArray = cellRangeArray.Select(x => x.ToString()).ToArray();
        //     Console.WriteLine(cellRangeArray.Count());

        //      xseries.Add(xAxisElementArray);

        //     chart.XAxis.Title.Caption = "Cell/Jar Number";
        //     chart.XAxis.HasMajorGridlines = true;
        //     chart.XAxis.MajorTickMark = TickMarkType.Outside;
        //     chart.XAxis.HasMajorGridlines = true;
        //     chart.XAxis.MajorTick = 10;
        //     chart.XAxis.TickLabels.Font.Size = 6;

        //     chart.YAxis.MajorTickMark = TickMarkType.Outside;
        //     chart.YAxis.HasMajorGridlines = true;
        //     chart.YAxis.Title.Caption = "Voltage";
        //     chart.YAxis.TickLabels.Format = "0.00";
        //     document.LastSection.Add(chart);
        // }


        // since the install date is in a string format in the CSV, need to parse it out to a readable format to allow formatting
        private static string GetDateString(string date)
        {
            DateTime theDate;
            if (DateTime.TryParseExact(date, "MM/dd/yy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out theDate))
            {
                // the string was successfully parsed into theDate
                return theDate.ToString("dd'/'MM'/'yyyy");
            }
            else
            {
                // the parsing failed, return some sensible default value
                return "Couldn't read the date";
            }
        }








        //private void fileListView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (fileListView.SelectedIndices.Count <= 0)
        //    {
        //        return;
        //    }
        //    // need to clear the datagridview
        //    dataGridPreview.Columns.Clear();
        //    string test = fileListView.SelectedItems[0].Text;
        //    Console.WriteLine(test);

        //    dataGridPreview.Columns.Add("Cell", "Cell No:");


        //}
    }
}

     