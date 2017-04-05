using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab_1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            this.listBox1.DisplayMember = "text";
            this.listBox1.ValueMember = "id";
        }

        private void InitializeOpenFileDialog()
        {
            this.openFileDialog1.Filter = "All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Browse File";
            openFileDialog1.ReadOnlyChecked = true;
        }

        private void addFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Read the files
                foreach (String file in openFileDialog1.FileNames)
                {
                    if (!listBox1.Items.Contains(new ListBoxItem(file, Path.GetFileNameWithoutExtension(file))))
                    {
                        listBox1.Items.Add(new ListBoxItem(file, Path.GetFileNameWithoutExtension(file)));
                    }
                }
            }
        }

        private void removeFile_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }

        }

        private void removeAllFiles_Click(object sender, EventArgs e)
        {
            while (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(0);
            }
        }

        private void optimizeCurrent_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                OptimizeStations op = new OptimizeStations((ListBoxItem)listBox1.SelectedItem);
                if (plotCheck.Checked == true)
                {
                    plotGraph(op.getPlotData());
                }
                if (outputCheck.Checked == true)
                {
                    op.generateOutputFiles();
                }
            }
        }

        private void optimizeAll_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                int counter = 0;
                ListBoxItem[] items = new ListBoxItem[listBox1.Items.Count];
                foreach (var item in listBox1.Items)
                {
                    ListBoxItem itemBoxed = (ListBoxItem)item;
                    items[counter] = new ListBoxItem(itemBoxed.id, itemBoxed.text);
                    counter += 1;
                }
                OptimizeStations op = new OptimizeStations(items);
                if (plotCheck.Checked == true)
                {
                    plotGraph(op.getPlotData());
                }
                if (outputCheck.Checked == true)
                {
                    op.generateOutputFiles();
                }
                
            }
        }
        private void plotGraph(Dictionary<string, Dictionary<string, List<int>>> input)
        {
            Form graphWindow = new Form2(input);
            graphWindow.Show();
        }
    }
}
