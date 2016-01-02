using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Finance.models;
using Finance.views;

namespace Finance.controllers
{
    class ChartController
    {
        FinanceChart view;
        
        ChartModel model;

        // limits for time axis (min is start of 2015, max is fall of current ywer plus 5
        DateTime minDate;
        DateTime maxDate;

        DateTime startDate;
        DateTime stopDate;

        public ChartController(FinanceChart view, ChartModel model)
        {
            this.view = view;
            this.model = model;


            // set limiits for time
            minDate = new DateTime(2005, 1, 1);
            maxDate = DateTime.Now.AddYears(5);

            this.view.setLimits(minDate, maxDate);

            // set color for each component
            view.Series[0].Color = System.Drawing.Color.Blue;

        }

        // left and right time limit changed
        public void updateView(DateTime startDate, DateTime stopDate)
        {
            this.startDate = startDate;
            this.stopDate = stopDate;

            drawReport(FinanceChart.REPORT, startDate, stopDate);

            drawPoints(model.Incomes, FinanceChart.INCOME, startDate, stopDate);
            drawPoints(model.Expenses, FinanceChart.EXPENSES, startDate, stopDate);
            drawPoints(model.Savings, FinanceChart.SAVINGS, startDate, stopDate);
        }

        // left time limit changed
        public void updateViewLeft(DateTime startDate)
        {
            this.startDate = startDate;

            drawReport(FinanceChart.REPORT, startDate, stopDate);

            drawPoints(model.Incomes, FinanceChart.INCOME, startDate, this.stopDate);
            drawPoints(model.Expenses, FinanceChart.EXPENSES, startDate, this.stopDate);
            drawPoints(model.Savings, FinanceChart.SAVINGS, startDate, this.stopDate);
        }

        // right time limit changed
        public void updateViewRight(DateTime stopDate)
        {
            this.stopDate = stopDate;

            drawReport(FinanceChart.REPORT, this.startDate, stopDate);

            drawPoints(model.Incomes, FinanceChart.INCOME, this.startDate, this.stopDate);
            drawPoints(model.Expenses, FinanceChart.EXPENSES, this.startDate, this.stopDate);
            drawPoints(model.Savings, FinanceChart.SAVINGS, this.startDate, this.stopDate);
        }

        // select what chart area are visible
        public void setVisibleCharts(bool[] visible)
        {
            if (visible.Length != view.ChartAreas.Count)
                throw new ArgumentException("The visibility must be set for all series");

            for (int i = 0; i < view.ChartAreas.Count; i++)
                view.ChartAreas[i].Visible = visible[i];


            invalidateView();
        }

        public void invalidateView()
        {
            this.view.Invalidate();
        }

        public void setChartType(SeriesChartType type)
        {
            for (int i = 0; i < this.view.Series.Count; i++)
                this.view.Series[i].ChartType = type;

            this.view.Invalidate();
        }

        // draw the report between dates. Report includes incomes and expenses. Unit time is month
        private void drawReport(int series, DateTime start, DateTime stop)
        {
            long value = 0;

            DateTime currDate = start;

            // clear old drawing
            view.Series[series].Points.Clear();

            // loop through time interval: each month is considered a point on graph
            while (currDate < stop)
            {
                // loop incomes
                foreach (FinanceCategoryData.Data data in model.Incomes)
                {
                    // for non recurent income, check difference between current date and the income date
                    if (!data.isRecurrent)
                    {
                        if (currDate.Subtract(data.start).TotalDays < 31)
                            value += data.value;
                    }
                    // for recurent income, check if we are on the valid month of year
                    else if (data.start > start)
                    {
                        // for frequency of 1 month, each month of interval is valid
                        if (data.repeatMonths == 1)
                            value += data.value;
                        else
                            // for any frequency between 2 and 12 months, check the modulo
                            if (currDate.Month % data.repeatMonths == 0)
                                value += data.value;
                    }


                }

                // loop expenses
                foreach (FinanceCategoryData.Data data in model.Expenses)
                {
                    // for non recurent expense, check difference between current date and the expense date
                    if (!data.isRecurrent)
                    {
                        if (currDate > data.start && currDate.Subtract(data.start).TotalDays < 31)
                            value -= data.value;
                    }
                    // for recurent expense, check if we are on the valid month of year
                    else if (data.start > start)
                    {
                        // for frequency of 1 month, each month of interval is valid
                        if (data.repeatMonths == 1)
                            value -= data.value;
                        else
                            // for any frequency between 2 and 12 months, check the modulo
                            if (currDate.Month % data.repeatMonths == 0)
                                value -= data.value;
                    }

                }

                // go to next month
                currDate = currDate.AddMonths(1);

                // add point to month
                view.Series[series].Points.AddXY(currDate, value);
            }

        }

        private void drawPoints(List<FinanceCategoryData.Data> list, int series, DateTime start, DateTime stop)
        {

            // clear old drawing
            view.Series[series].Points.Clear();

            DateTime currDate = start;

            // loop through time interval: each month is considered a point on graph
            while (currDate < stop)
            {
                // loop incomes
                foreach (FinanceCategoryData.Data data in list)
                {
                    // for non recurent expense, check difference between current date and the expense date
                    if (!data.isRecurrent)
                    {
                        if (currDate > data.start && currDate.Subtract(data.start).TotalDays < 31)
                            // add point to month
                            view.Series[series].Points.AddXY(currDate, data.value);
                    }
                    // for recurent expense, check if we are on the valid month of year
                    else if (data.start > start)
                    {
                        // for frequency of 1 month, each month of interval is valid
                        if (data.repeatMonths == 1)
                            view.Series[series].Points.AddXY(currDate, data.value);
                        else
                            // for any frequency between 2 and 12 months, check the modulo
                            if (currDate.Month % data.repeatMonths == 0)
                                view.Series[series].Points.AddXY(currDate, data.value);
                    }
                }
                // go to next month
                currDate = currDate.AddMonths(1);
            }
        }
        

    }
}
