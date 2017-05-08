using OxyPlot;
using OxyPlot.Series;

namespace lab_2
{
    partial class Form2
    {
        private OxyPlot.WindowsForms.PlotView plot1;
        private OxyPlot.WindowsForms.PlotView plot2;
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
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.plot2 = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // plot1
            // 
            this.plot1.Dock = System.Windows.Forms.DockStyle.Left;
            this.plot1.Location = new System.Drawing.Point(0, 0);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(547, 856);
            this.plot1.TabIndex = 0;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plot2
            // 
            this.plot2.Dock = System.Windows.Forms.DockStyle.Right;
            this.plot2.Location = new System.Drawing.Point(553, 0);
            this.plot2.Name = "plot2";
            this.plot2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot2.Size = new System.Drawing.Size(557, 856);
            this.plot2.TabIndex = 0;
            this.plot2.Text = "plot2";
            this.plot2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 856);
            this.Controls.Add(this.plot2);
            this.Controls.Add(this.plot1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion
    }
}