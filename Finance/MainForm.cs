using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using System.Data.SqlClient;
using System.Data;

using Finance.models;
using Finance.controllers;

namespace Finance
{
    /// <summary>
    /// Main form - metro form
    /// </summary>
    class MainForm : MetroForm
    {

        #region UI COMPONENTS
        private MetroTabControl metroTabControl;
        private MetroTabPage metroTabPage1;
        private MetroTabPage metroTabPage2;
        private MetroTile tileSavings;
        private MetroTile tileExpenses;
        private MetroTile tileIncomes;
        private MetroButton metroButtonAdd;
        private System.Windows.Forms.FlowLayoutPanel panelCategories;
        private MetroLabel lblAppName;
        #endregion


        #region LOGIC COMPONENTS 

        // the selected major category
        private int majorCategory = 0;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        // controller for the list of categories
        GridListAdapter gridListAdapter;

        #endregion 

        public MainForm()
        {
            InitializeComponent();

            // create adapter for the panel (the grid list = a panel with flow layout)
            gridListAdapter = new GridListAdapter(this.panelCategories);
        }

        #region INITIALIZE UI COMPONENTS

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.metroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.panelCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.metroButtonAdd = new MetroFramework.Controls.MetroButton();
            this.tileSavings = new MetroFramework.Controls.MetroTile();
            this.tileExpenses = new MetroFramework.Controls.MetroTile();
            this.tileIncomes = new MetroFramework.Controls.MetroTile();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblAppName = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl
            // 
            this.metroTabControl.Controls.Add(this.metroTabPage1);
            this.metroTabControl.Controls.Add(this.metroTabPage2);
            this.metroTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl.Name = "metroTabControl";
            this.metroTabControl.SelectedIndex = 1;
            this.metroTabControl.Size = new System.Drawing.Size(753, 401);
            this.metroTabControl.TabIndex = 1;
            this.metroTabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl.UseSelectable = true;
            this.metroTabControl.SelectedIndexChanged += new System.EventHandler(this.metroTabControl_SelectedIndexChanged);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.AutoScroll = true;
            this.metroTabPage1.Controls.Add(this.panelCategories);
            this.metroTabPage1.Controls.Add(this.metroButtonAdd);
            this.metroTabPage1.Controls.Add(this.tileSavings);
            this.metroTabPage1.Controls.Add(this.tileExpenses);
            this.metroTabPage1.Controls.Add(this.tileIncomes);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage1.Size = new System.Drawing.Size(745, 359);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Categories && details";
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // panelCategories
            // 
            this.panelCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCategories.AutoScroll = true;
            this.panelCategories.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelCategories.Location = new System.Drawing.Point(175, 28);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.Size = new System.Drawing.Size(570, 250);
            this.panelCategories.TabIndex = 29;
            // 
            // metroButtonAdd
            // 
            this.metroButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonAdd.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButtonAdd.Location = new System.Drawing.Point(175, 284);
            this.metroButtonAdd.Name = "metroButtonAdd";
            this.metroButtonAdd.Size = new System.Drawing.Size(570, 32);
            this.metroButtonAdd.TabIndex = 0;
            this.metroButtonAdd.TabStop = false;
            this.metroButtonAdd.Text = "Add";
            this.metroButtonAdd.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButtonAdd.UseSelectable = true;
            this.metroButtonAdd.Click += new System.EventHandler(this.metroButtonAdd_Click);
            // 
            // tileSavings
            // 
            this.tileSavings.ActiveControl = null;
            this.tileSavings.Location = new System.Drawing.Point(28, 260);
            this.tileSavings.Name = "tileSavings";
            this.tileSavings.Size = new System.Drawing.Size(120, 80);
            this.tileSavings.TabIndex = 26;
            this.tileSavings.Text = "Savings";
            this.tileSavings.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileSavings.UseSelectable = true;
            this.tileSavings.Click += new System.EventHandler(this.majorCategory_Click);
            // 
            // tileExpenses
            // 
            this.tileExpenses.ActiveControl = null;
            this.tileExpenses.Location = new System.Drawing.Point(28, 146);
            this.tileExpenses.Name = "tileExpenses";
            this.tileExpenses.Size = new System.Drawing.Size(120, 80);
            this.tileExpenses.TabIndex = 25;
            this.tileExpenses.Text = "Expenses";
            this.tileExpenses.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileExpenses.UseSelectable = true;
            this.tileExpenses.Click += new System.EventHandler(this.majorCategory_Click);
            // 
            // tileIncomes
            // 
            this.tileIncomes.ActiveControl = null;
            this.tileIncomes.Location = new System.Drawing.Point(28, 28);
            this.tileIncomes.Name = "tileIncomes";
            this.tileIncomes.Size = new System.Drawing.Size(120, 80);
            this.tileIncomes.TabIndex = 24;
            this.tileIncomes.Text = "Incomes";
            this.tileIncomes.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileIncomes.UseSelectable = true;
            this.tileIncomes.Click += new System.EventHandler(this.majorCategory_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.chart1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage2.Size = new System.Drawing.Size(745, 359);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Statistics";
            this.metroTabPage2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            this.metroTabPage2.Visible = false;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(25, 25);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.LegendToolTip = "Incomes";
            series1.Name = "Series1";
            series1.ToolTip = "Incomes";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.LegendToolTip = "Expenses";
            series2.Name = "Series2";
            series2.ToolTip = "Expenses";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(695, 309);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Segoe UI", 12F);
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Income";
            title2.Name = "Expenses";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAppName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAppName.Location = new System.Drawing.Point(24, 23);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(77, 25);
            this.lblAppName.Style = MetroFramework.MetroColorStyle.White;
            this.lblAppName.TabIndex = 2;
            this.lblAppName.Text = "Finance";
            this.lblAppName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(793, 481);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.metroTabControl);
            this.Name = "MainForm";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.metroTabControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private void MainForm_Load(object sender, EventArgs e)
        {
            // display the categories of the first major
            gridListAdapter.refreshList(majorCategory);
        }

        // add a new category to the current selected major
        private void metroButtonAdd_Click(object sender, EventArgs e)
        {
            // display form with details about the new category
            AddCategoryForm f = new AddCategoryForm();
            f.ShowDialog();

            // if all data is completed, add the new item to the new Major and refresh the list
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                // save the category to the coresponding binary file
                Utils.save<FinanceCategoryData.Data>(f.getData(), majorCategory + ".dat");
                // refresh the grid list
                this.gridListAdapter.refreshList(majorCategory);
            }

        }

        // change the major cateogory
        private void majorCategory_Click(object sender, EventArgs e)
        {
            switch (((MetroTile)sender).Text)
            {
                case "Incomes":
                    this.majorCategory = 0;
                    break;
                case "Expenses":
                    this.majorCategory = 1;
                    break;
                case "Savings":
                    this.majorCategory = 2;
                    break;
            }

            // refresh the grid list
            gridListAdapter.refreshList(majorCategory);
        }
        static int x = 50;
        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Add(new double[] { x });
            chart1.Series[0].Points.Add(new double[] {x *= 2});

        }
 
    }
}
