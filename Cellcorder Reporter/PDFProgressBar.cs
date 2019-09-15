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
    public partial class PDFProgressBarForm : Form
    {

        public event EventHandler<EventArgs> Canceled;

        public PDFProgressBarForm()
        {
            InitializeComponent();
        }

        // two properties to adjust the values on this form
        public string Message
        {
            set { label_percentage.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar_forPDFS.Value = value; }
        }

        public string ButtonText
        {
            set { button_cancelPDF.Text = value; }
            get { return button_cancelPDF.Text;  }
        }

        private void Button_cancelPDF_Click(object sender, EventArgs e)
        {
            // Create a copy of the event to work with
            EventHandler<EventArgs> ea = Canceled;
            /* If there are no subscribers, ea will be null so we need to check
                * to avoid a NullReferenceException. */
            if (ea != null)
                ea(this, e);
        }
    }
}
