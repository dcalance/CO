using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace lab_1
{
    public partial class Form2 : Form
    {
        public Form2(Dictionary<string, Dictionary<string, List<int>>> inputData)
        {
            InitializeComponent();
            var myModel = new PlotModel { Title = "Post Optimisation" };
            var myModel2 = new PlotModel { Title = "After Optimisation" };
            List<LineSeries> graph1 = new List<LineSeries>();
            LineSeries points = new LineSeries();
            foreach (var station in inputData["Pre"])
            {
                points = new LineSeries();
                points.Title = station.Key;
                int gap = 50 / station.Value.Count ;
                for (int counter = 0; counter < station.Value.Count; counter++)
                {
                    points.Points.Add(new DataPoint(counter * gap, station.Value[counter]));
                }
                graph1.Add(points);
            }

            List<LineSeries> graph2 = new List<LineSeries>();
            foreach (var station in inputData["Post"])
            {
                points = new LineSeries();
                points.Title = station.Key;
                int gap = 50 / station.Value.Count;
                for (int counter = 0; counter < station.Value.Count; counter++)
                {
                    points.Points.Add(new DataPoint(counter * gap, station.Value[counter]));
                }
                graph2.Add(points);
            }
            foreach (var item in graph1)
            {
                myModel.Series.Add(item);
            }
            foreach (var item in graph2)
            {
                myModel2.Series.Add(item);
            }

            this.plot1.Model = myModel;
            this.plot2.Model = myModel2;
        }
    }
}
