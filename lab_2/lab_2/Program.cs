using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            double[][] arr = new double[][] { new double[] { 2, 3, 2, 1000 }, new double[] { 1, 1, 2, 800 }, new double[] {7, 8, 10, 0 } };
            double[][] arr2 = new double[][] { new double[] { 0, 1200, 5800, 1500 }, new double[] { 1, 1, 1, 1.2 }, new double[] { -1, 0, 0, -0.5 }, new double[] { 8000, 16000, 24000, 0 } };
            Simplex a = new Simplex(arr2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
