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

        public static string[] AREAS = { "Report", "Incomes", "Expenses", "Savings"};

        public const int REPORT = 0;
        public const int INCOME = 1;
        public const int EXPENSES= 2;
        public const int SAVINGS = 3;

        public FinanceChart()
        {
            initControl();
            initDataVisualization();
        }

        // control initialization specific for this app
        public void initControl()
        {

            // location and size
            this.Location = new System.Drawing.Point(25, 50);
            this.Width = 600;
            this.Height = 309;

            // anchors for redim
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            // event handler for zoom
            this.MouseWheel += chart_MouseWheel;
            this.MouseEnter += chart_MouseEnter;
            this.MouseLeave += chart_MouseLeave;
        }

        public void setLimits(DateTime minDate, DateTime maxDate)
        {
            foreach (Series s in this.Series)
            {
                // xAxis will be time
                s.XValueType = ChartValueType.DateTime;
            }
            foreach (ChartArea a in this.ChartAreas)
            {
                a.AxisX.IntervalType = DateTimeIntervalType.Weeks;
                a.AxisX.IntervalOffset = 1;

                // set limits on the time axis
                a.AxisX.Minimum = minDate.ToOADate();
                a.AxisX.Maximum = maxDate.ToOADate();
            }
        }

        private void initDataVisualization()
        {

            // make both axis infinite
            LineAnnotation ann = new LineAnnotation();
            ann.IsInfinitive = true;
            this.Annotations.Add(ann);

            // define a four area chart
            for (int i = 0; i < 4; i++)
            {
                this.ChartAreas.Add(new ChartArea(AREAS[i]));
                // enable zooming 
                this.ChartAreas[i].AxisX.ScaleView.Zoomable = true;
                this.ChartAreas[i].AxisY.ScaleView.Zoomable = true;
            }
            // only main area is visible at begin
            this.ChartAreas[1].Visible = false;
            this.ChartAreas[2].Visible = false;
            this.ChartAreas[3].Visible = false;


            // define 4 series
            for (int i = 0; i < 4; i++)
            {
                this.Series.Add(AREAS[i]);

                // move each series to it's area
                this.Series[i].ChartArea = AREAS[i];

                this.Series[i].ToolTip = AREAS[i];
            }
            

        }

        // handle mouse wheel event for zooming: zoom out - return to default;
        private void chart_MouseWheel(object sender, MouseEventArgs e)
        {
            int i;
            System.Drawing.Point posChart = this.PointToClient(e.Location);//Position of the mouse with respect to the chart
            for (i = 0; i < this.ChartAreas.Count; i++)
            {
                int minX1, minY1, maxX1, maxY1;
                minX1 = (int)this.ChartAreas[i].Position.X;
                maxX1 = (int)(this.ChartAreas[i].Position.X + this.ChartAreas[i].Position.Width * this.Width / 100);
                minY1 = (int)this.ChartAreas[i].Position.Y;
                maxY1 = (int)(this.ChartAreas[i].Position.Y + this.ChartAreas[i].Position.Height * this.Height / 100);

                if (posChart.X >= minX1 && posChart.X <= maxX1 && posChart.Y >= minY1 && posChart.Y <= maxY1) 
                    break;
            }

            if (i > this.ChartAreas.Count)
                // the mouse was outside chart, so change zoom on the default area [0]
                i = 0;

            try
            {
                if (e.Delta < 0)
                {
                    this.ChartAreas[i].AxisX.ScaleView.ZoomReset();
                    this.ChartAreas[i].AxisY.ScaleView.ZoomReset();
                }

                if (e.Delta > 0)
                {
                    double xMin = this.ChartAreas[i].AxisX.ScaleView.ViewMinimum;
                    double xMax = this.ChartAreas[i].AxisX.ScaleView.ViewMaximum;
                    double yMin = this.ChartAreas[i].AxisY.ScaleView.ViewMinimum;
                    double yMax = this.ChartAreas[i].AxisY.ScaleView.ViewMaximum;

                    double posXStart = this.ChartAreas[i].AxisX.PixelPositionToValue(e.Location.X % 100) - (xMax - xMin) / 4;
                    double posXFinish = this.ChartAreas[i].AxisX.PixelPositionToValue(e.Location.X % 100) + (xMax - xMin) / 4;
                    double posYStart = this.ChartAreas[i].AxisY.PixelPositionToValue(e.Location.Y % 100) - (yMax - yMin) / 4;
                    double posYFinish = this.ChartAreas[i].AxisY.PixelPositionToValue(e.Location.Y % 100) + (yMax - yMin) / 4;

                    this.ChartAreas[i].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    this.ChartAreas[i].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

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
