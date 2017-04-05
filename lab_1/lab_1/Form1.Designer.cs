namespace lab_1
{
    partial class Form1
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
            this.addFiles = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.removeFile = new System.Windows.Forms.Button();
            this.removeAllFiles = new System.Windows.Forms.Button();
            this.optimizeCurrent = new System.Windows.Forms.Button();
            this.optimizeAll = new System.Windows.Forms.Button();
            this.outputCheck = new System.Windows.Forms.CheckBox();
            this.plotCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // addFiles
            // 
            this.addFiles.Location = new System.Drawing.Point(163, 166);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(120, 23);
            this.addFiles.TabIndex = 0;
            this.addFiles.Text = "Add Files";
            this.addFiles.UseVisualStyleBackColor = true;
            this.addFiles.Click += new System.EventHandler(this.addFiles_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(163, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 160);
            this.listBox1.TabIndex = 0;
            // 
            // removeFile
            // 
            this.removeFile.Location = new System.Drawing.Point(163, 196);
            this.removeFile.Name = "removeFile";
            this.removeFile.Size = new System.Drawing.Size(120, 23);
            this.removeFile.TabIndex = 1;
            this.removeFile.Text = "Remove Selected File";
            this.removeFile.UseVisualStyleBackColor = true;
            this.removeFile.Click += new System.EventHandler(this.removeFile_Click);
            // 
            // removeAllFiles
            // 
            this.removeAllFiles.Location = new System.Drawing.Point(163, 226);
            this.removeAllFiles.Name = "removeAllFiles";
            this.removeAllFiles.Size = new System.Drawing.Size(120, 23);
            this.removeAllFiles.TabIndex = 2;
            this.removeAllFiles.Text = "Remove All Files";
            this.removeAllFiles.UseVisualStyleBackColor = true;
            this.removeAllFiles.Click += new System.EventHandler(this.removeAllFiles_Click);
            // 
            // optimizeCurrent
            // 
            this.optimizeCurrent.Location = new System.Drawing.Point(12, 12);
            this.optimizeCurrent.Name = "optimizeCurrent";
            this.optimizeCurrent.Size = new System.Drawing.Size(120, 23);
            this.optimizeCurrent.TabIndex = 3;
            this.optimizeCurrent.Text = "Optimize current";
            this.optimizeCurrent.UseVisualStyleBackColor = true;
            this.optimizeCurrent.Click += new System.EventHandler(this.optimizeCurrent_Click);
            // 
            // optimizeAll
            // 
            this.optimizeAll.Location = new System.Drawing.Point(12, 41);
            this.optimizeAll.Name = "optimizeAll";
            this.optimizeAll.Size = new System.Drawing.Size(120, 23);
            this.optimizeAll.TabIndex = 4;
            this.optimizeAll.Text = "Optimize all";
            this.optimizeAll.UseVisualStyleBackColor = true;
            this.optimizeAll.Click += new System.EventHandler(this.optimizeAll_Click);
            // 
            // outputCheck
            // 
            this.outputCheck.AutoSize = true;
            this.outputCheck.Location = new System.Drawing.Point(12, 232);
            this.outputCheck.Name = "outputCheck";
            this.outputCheck.Size = new System.Drawing.Size(131, 17);
            this.outputCheck.TabIndex = 5;
            this.outputCheck.Text = "Output Results as files";
            this.outputCheck.UseVisualStyleBackColor = true;
            // 
            // plotCheck
            // 
            this.plotCheck.AutoSize = true;
            this.plotCheck.Location = new System.Drawing.Point(12, 209);
            this.plotCheck.Name = "plotCheck";
            this.plotCheck.Size = new System.Drawing.Size(76, 17);
            this.plotCheck.TabIndex = 6;
            this.plotCheck.Text = "Plot Graph";
            this.plotCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.plotCheck);
            this.Controls.Add(this.outputCheck);
            this.Controls.Add(this.optimizeAll);
            this.Controls.Add(this.optimizeCurrent);
            this.Controls.Add(this.removeAllFiles);
            this.Controls.Add(this.removeFile);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.addFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button removeFile;
        private System.Windows.Forms.Button removeAllFiles;
        private System.Windows.Forms.Button optimizeCurrent;
        private System.Windows.Forms.Button optimizeAll;
        private System.Windows.Forms.CheckBox outputCheck;
        private System.Windows.Forms.CheckBox plotCheck;
    }
}

