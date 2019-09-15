namespace Cellcorder_Reporter
{
    partial class PDFProgressBarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar_forPDFS = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_percentage = new System.Windows.Forms.Label();
            this.button_cancelPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar_forPDFS
            // 
            this.progressBar_forPDFS.Location = new System.Drawing.Point(45, 58);
            this.progressBar_forPDFS.Name = "progressBar_forPDFS";
            this.progressBar_forPDFS.Size = new System.Drawing.Size(345, 23);
            this.progressBar_forPDFS.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generating PDF reports";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_percentage
            // 
            this.label_percentage.BackColor = System.Drawing.Color.Transparent;
            this.label_percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_percentage.Location = new System.Drawing.Point(48, 84);
            this.label_percentage.Name = "label_percentage";
            this.label_percentage.Size = new System.Drawing.Size(342, 22);
            this.label_percentage.TabIndex = 3;
            this.label_percentage.Text = "0%";
            this.label_percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_cancelPDF
            // 
            this.button_cancelPDF.Location = new System.Drawing.Point(182, 120);
            this.button_cancelPDF.Name = "button_cancelPDF";
            this.button_cancelPDF.Size = new System.Drawing.Size(75, 23);
            this.button_cancelPDF.TabIndex = 4;
            this.button_cancelPDF.Text = "Cancel";
            this.button_cancelPDF.UseVisualStyleBackColor = true;
            this.button_cancelPDF.Click += new System.EventHandler(this.Button_cancelPDF_Click);
            // 
            // PDFProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 172);
            this.ControlBox = false;
            this.Controls.Add(this.button_cancelPDF);
            this.Controls.Add(this.label_percentage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar_forPDFS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PDFProgressBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDFProgressBar";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar progressBar_forPDFS;
        private System.Windows.Forms.Button button_cancelPDF;
        public System.Windows.Forms.Label label_percentage;
    }
}