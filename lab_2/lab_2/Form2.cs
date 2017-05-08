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

namespace lab_2
{
    public partial class Form2 : Form
    {
        Dictionary<int, double[]> plotData = new Dictionary<int, double[]>();
        public Form2(Dictionary<int, double[]> inputData)
        {
            InitializeComponent();
            plotData = inputData;
            Plot();
        }
        public void Plot()
        {
            var myModel2 = new PlotModel { Title = "Planted Surface" };
            var myModel = new PlotModel { Title = "Profit Obtained" };
            List<LineSeries> graph1 = new List<LineSeries>();
            List<LineSeries> graph2 = new List<LineSeries>();
            LineSeries money = new LineSeries();
            money.Title = "Profit";

            LineSeries forest = new LineSeries();
            forest.Title = "Forest";
            LineSeries potatoes = new LineSeries();
            potatoes.Title = "Potatoes";
            LineSeries grapes = new LineSeries();
            grapes.Title = "Grapes";

            foreach (var item in plotData)
            {
                forest.Points.Add(new DataPoint(item.Key, item.Value[0]));
                potatoes.Points.Add(new DataPoint(item.Key, item.Value[1]));
                grapes.Points.Add(new DataPoint(item.Key, item.Value[2]));
                money.Points.Add(new DataPoint(item.Key, item.Value[item.Value.Length - 1]));
            }
            graph1.Add(money);
            graph2.Add(forest);
            graph2.Add(potatoes);
            graph2.Add(grapes);
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
