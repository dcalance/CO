using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<int, double[]> outputData = new Dictionary<int, double[]>();
            double[][] arr2m = new double[][] { new double[] { 0, 1200, 5800, 1, 0, 0, 1500 }, new double[] { 1, 1, 1, 0, 1, 0, 1.2 }, new double[] { 1, 0, 0, 0, 0, -1, 0.5 }, new double[] { 8000, 16000, 24000, 0, 0, 0, 0 } };
            Simplex a = new Simplex(arr2m, 3);
            double[] data = a.getData();
            outputData[0] = a.getData();
            for (int i = 1; i < 5; i++)
            {
                arr2m[0][6] = data[data.Length - 1];
                a = new Simplex(arr2m, 3);
                data = a.getData();
                outputData[i] = a.getData();
            }
            Form2 graphWindow = new Form2(outputData);
            graphWindow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<int, double[]> outputData = new Dictionary<int, double[]>();
            double[][] arr2m = new double[][] { new double[] { 0, 1200, 5800, 1, 0, 0, 1500 }, new double[] { 1, 1, 1, 0, 1, 0, 1.2 }, new double[] { 1, 0, 0, 0, 0, -1, 0.5 }, new double[] { 8000, 16000, 24000, 0, 0, 0, 0 } };
            Simplex a = new Simplex(arr2m, 3);
            double[] data = a.getData();
            outputData[0] = a.getData();
            for (int i = 1; i < 5; i++)
            {
                arr2m[0][2] -= 800 * data[2];
                arr2m[0][6] = data[data.Length - 1];
                a = new Simplex(arr2m, 3);
                data = a.getData();
                outputData[i] = a.getData();
            }
            Form2 graphWindow = new Form2(outputData);
            graphWindow.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dictionary<int, double[]> outputData = new Dictionary<int, double[]>();
            double[][] arr2m = new double[][] { new double[] { 0, 1200, 5800, 1, 0, 0, 1500 }, new double[] { 1, 1, 1, 0, 1, 0, 1.2 }, new double[] { 1, 0, 0, 0, 0, -1, 0.5 }, new double[] { 8000, 16000, 24000, 0, 0, 0, 0 } };
            Simplex a = new Simplex(arr2m, 3);
            double[] data = a.getData();
            outputData[0] = a.getData();
            arr2m[0][2] = 2500 + 800;
            arr2m[3][2] -= 600;
            for (int i = 1; i < 5; i++)
            {
                arr2m[0][6] = data[data.Length - 1];
                a = new Simplex(arr2m, 3);
                data = a.getData();
                outputData[i] = a.getData();
            }
            Form2 graphWindow = new Form2(outputData);
            graphWindow.Show();
        }
    }
}
