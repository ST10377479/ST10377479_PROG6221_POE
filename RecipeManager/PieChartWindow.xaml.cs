using System.Collections.Generic;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;

namespace RecipeManager
{
    public partial class PieChartWindow : Window
    {
        public PieChartWindow(Dictionary<string, double> foodGroupPercentages)
        {
            InitializeComponent();
            CreatePieChart(foodGroupPercentages);
        }

        private void CreatePieChart(Dictionary<string, double> foodGroupPercentages)
        {
            var pieSeries = new PieSeries { StrokeThickness = 1.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            foreach (var group in foodGroupPercentages)
            {
                pieSeries.Slices.Add(new PieSlice(group.Key, group.Value));
            }

            var model = new PlotModel { Title = "Food Group Distribution" };
            model.Series.Add(pieSeries);

            PieChart.Model = model;
        }
    }
}
// References
//Troelsen, A. and Japokse, P., 2022.PRo C# 10 with .NET 6 : Foundational Principles and Practices in Programming. 11th ed.  NEW York: Apress.(30 May 2024)