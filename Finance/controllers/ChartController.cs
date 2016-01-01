using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Finance.models;

namespace Finance.controllers
{
    class ChartController
    {
        Chart view;
        
        ChartModel model;

        public ChartController(Chart view, ChartModel model)
        {
            this.view = view;
            this.model = model;

            view.Series.Clear();
            
            
            // show all three series
            view.Series.Add("Incomes");
            view.Series.Add("Expenses");
            view.Series.Add("Savings");

            view.Series[0].Color = System.Drawing.Color.Green;
            view.Series[1].Color = System.Drawing.Color.Red;
            view.Series[2].Color = System.Drawing.Color.Blue;

            view.ChartAreas[0].AxisX.Interval = 200;
            view.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            view.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            LineAnnotation ann = new LineAnnotation();
            ann.IsInfinitive = true;
            view.Annotations.Add(ann);

        }

        public void updateView()
        {
            for (int i = 0; i < view.Series.Count; i++)
                view.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            foreach (FinanceCategoryData.Data data in model.Incomes)
                view.Series[0].Points.Add(data.value);

            foreach (FinanceCategoryData.Data data in model.Expenses)
                view.Series[1].Points.Add(data.value);

            foreach (FinanceCategoryData.Data data in model.Savings)
                view.Series[2].Points.Add(data.value);
        }

        public void setVisibleCharts(bool[] visible)
        {
            if (visible.Length != view.Series.Count)
                throw new ArgumentException("The visibility must be set for all series");

            for (int i = 0; i < view.Series.Count; i++)
                view.Series[i].Enabled = visible[i];

        }

        public void invalidate()
        {
            this.view.Invalidate();
        }

    }
}
