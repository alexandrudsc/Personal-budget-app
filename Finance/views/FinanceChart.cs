using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Finance.views
{
    /// <summary>
    /// Custom chart for displaying incomes, expenses and savings with respect to time.
    /// Supports zoom.
    /// Used as "View" in MCV pattern
    /// </summary>
    class FinanceChart : Chart
    {

        public FinanceChart()
        {
            init();
        }

        // control initialization specific for this app
        public void init()
        {
            // location and size
            this.Location = new System.Drawing.Point(25, 25);
            this.Width = 600;
            this.Height = 309;

            // define a single chart area
            this.ChartAreas.Add(new ChartArea());

            // event handler for zoom
            this.MouseWheel += chart_MouseWheel;
            this.MouseEnter += chart_MouseEnter;
            this.MouseLeave += chart_MouseLeave;
        }

        // handle mouse wheel event for zooming: zoom out - return to default;
        private void chart_MouseWheel(object sender, MouseEventArgs e)
        {

            try
            {
                if (e.Delta < 0)
                {
                    this.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    this.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }

                if (e.Delta > 0)
                {
                    double xMin = this.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = this.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = this.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = this.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = this.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X % 100) - (xMax - xMin) / 4;
                    double posXFinish = this.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X % 100) + (xMax - xMin) / 4;
                    double posYStart = this.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y % 100) - (yMax - yMin) / 4;
                    double posYFinish = this.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y % 100) + (yMax - yMin) / 4;

                    this.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    this.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        void chart_MouseLeave(object sender, EventArgs e)
        {
            if (this.Focused)
                this.Parent.Focus();
        }

        void chart_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Focused)
                this.Focus();
        }

    }
}
