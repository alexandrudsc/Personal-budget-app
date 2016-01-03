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
using System.Windows.Forms;

using Finance.views;
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
        private FinanceChart chart;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        // check boxes for displaying graph
        private MetroCheckBox chkIncomes;
        private MetroCheckBox chkExpenses;
        private MetroCheckBox chkSavings;

        // controller for the list of categories
        GridListAdapter gridListAdapter;
        private MetroCheckBox chkFull;
        private MetroComboBox cmbChartType;

        // controller and model for chart (MVC)
        ChartController chartController;
        private MetroLabel metroLabel1;
        private MetroDateTime dtRight;
        private MetroDateTime dtLeft;
        ChartModel chartModel;
        #endregion 

        public MainForm()
        {
            InitializeComponent();

            // add custom chart to tab2 
            chart = new FinanceChart();
            metroTabPage2.Controls.Add(chart);

            // define hmodel and controller for chart (MVC)
            chartModel = new ChartModel();
            chartController = new ChartController(this.chart, chartModel);

            // create controller for the panel (the grid list = a panel with flow layout) (MVC)
            gridListAdapter = new GridListAdapter(this.panelCategories);
        }

        #region INITIALIZE UI COMPONENTS

        private void InitializeComponent()
        {
            this.metroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.panelCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.metroButtonAdd = new MetroFramework.Controls.MetroButton();
            this.tileSavings = new MetroFramework.Controls.MetroTile();
            this.tileExpenses = new MetroFramework.Controls.MetroTile();
            this.tileIncomes = new MetroFramework.Controls.MetroTile();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dtRight = new MetroFramework.Controls.MetroDateTime();
            this.dtLeft = new MetroFramework.Controls.MetroDateTime();
            this.cmbChartType = new MetroFramework.Controls.MetroComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkFull = new MetroFramework.Controls.MetroCheckBox();
            this.chkIncomes = new MetroFramework.Controls.MetroCheckBox();
            this.chkExpenses = new MetroFramework.Controls.MetroCheckBox();
            this.chkSavings = new MetroFramework.Controls.MetroCheckBox();
            this.lblAppName = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl
            // 
            this.metroTabControl.Controls.Add(this.metroTabPage1);
            this.metroTabControl.Controls.Add(this.metroTabPage2);
            this.metroTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl.Name = "metroTabControl";
            this.metroTabControl.SelectedIndex = 0;
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
            this.panelCategories.Size = new System.Drawing.Size(570, 249);
            this.panelCategories.TabIndex = 29;
            // 
            // metroButtonAdd
            // 
            this.metroButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonAdd.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButtonAdd.Location = new System.Drawing.Point(175, 293);
            this.metroButtonAdd.Name = "metroButtonAdd";
            this.metroButtonAdd.Size = new System.Drawing.Size(567, 32);
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
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.Controls.Add(this.dtRight);
            this.metroTabPage2.Controls.Add(this.dtLeft);
            this.metroTabPage2.Controls.Add(this.cmbChartType);
            this.metroTabPage2.Controls.Add(this.flowLayoutPanel1);
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
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(244, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(19, 25);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "-";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // dtRight
            // 
            this.dtRight.Location = new System.Drawing.Point(280, 3);
            this.dtRight.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtRight.Name = "dtRight";
            this.dtRight.Size = new System.Drawing.Size(200, 29);
            this.dtRight.TabIndex = 9;
            this.dtRight.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dtRight.ValueChanged += new System.EventHandler(this.dtRight_ValueChanged);
            // 
            // dtLeft
            // 
            this.dtLeft.Location = new System.Drawing.Point(25, 3);
            this.dtLeft.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtLeft.Name = "dtLeft";
            this.dtLeft.Size = new System.Drawing.Size(200, 29);
            this.dtLeft.TabIndex = 8;
            this.dtLeft.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dtLeft.ValueChanged += new System.EventHandler(this.dtLeft_ValueChanged);
            // 
            // cmbChartType
            // 
            this.cmbChartType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.ItemHeight = 23;
            this.cmbChartType.Items.AddRange(new object[] {
            "Default",
            "Doghnut",
            "Lines",
            "Pie"});
            this.cmbChartType.Location = new System.Drawing.Point(639, 181);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(100, 29);
            this.cmbChartType.Sorted = true;
            this.cmbChartType.TabIndex = 7;
            this.cmbChartType.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmbChartType.UseSelectable = true;
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.cmbChartType_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.Controls.Add(this.chkFull);
            this.flowLayoutPanel1.Controls.Add(this.chkIncomes);
            this.flowLayoutPanel1.Controls.Add(this.chkExpenses);
            this.flowLayoutPanel1.Controls.Add(this.chkSavings);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(636, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(106, 118);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.Checked = true;
            this.chkFull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFull.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkFull.Location = new System.Drawing.Point(3, 3);
            this.chkFull.Name = "chkFull";
            this.chkFull.Size = new System.Drawing.Size(82, 25);
            this.chkFull.TabIndex = 6;
            this.chkFull.Text = "Report";
            this.chkFull.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkFull.UseSelectable = true;
            this.chkFull.CheckedChanged += new System.EventHandler(this.checkbox_CheckedChanged);
            // 
            // chkIncomes
            // 
            this.chkIncomes.AutoSize = true;
            this.chkIncomes.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkIncomes.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkIncomes.Location = new System.Drawing.Point(3, 34);
            this.chkIncomes.Name = "chkIncomes";
            this.chkIncomes.Size = new System.Drawing.Size(95, 25);
            this.chkIncomes.TabIndex = 3;
            this.chkIncomes.Text = "Incomes";
            this.chkIncomes.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkIncomes.UseSelectable = true;
            this.chkIncomes.CheckedChanged += new System.EventHandler(this.checkbox_CheckedChanged);
            // 
            // chkExpenses
            // 
            this.chkExpenses.AutoSize = true;
            this.chkExpenses.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkExpenses.Location = new System.Drawing.Point(3, 65);
            this.chkExpenses.Name = "chkExpenses";
            this.chkExpenses.Size = new System.Drawing.Size(100, 25);
            this.chkExpenses.TabIndex = 4;
            this.chkExpenses.Text = "Expenses";
            this.chkExpenses.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkExpenses.UseSelectable = true;
            this.chkExpenses.CheckedChanged += new System.EventHandler(this.checkbox_CheckedChanged);
            // 
            // chkSavings
            // 
            this.chkSavings.AutoSize = true;
            this.chkSavings.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkSavings.Location = new System.Drawing.Point(3, 96);
            this.chkSavings.Name = "chkSavings";
            this.chkSavings.Size = new System.Drawing.Size(89, 25);
            this.chkSavings.TabIndex = 5;
            this.chkSavings.Text = "Savings";
            this.chkSavings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkSavings.UseSelectable = true;
            this.chkSavings.CheckedChanged += new System.EventHandler(this.checkbox_CheckedChanged);
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
            this.metroTabPage2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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

        // tab change event.
        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroTabControl tabCtrl = (MetroTabControl)sender;
            switch(tabCtrl.SelectedIndex)
            {
                case 0:
                    // list of categories tab 
                    break; 

                case 1:
                    // statistics tab

                    // set default item on combobox
                    cmbChartType.SelectedIndex = 0;

                    // update data
                    chartModel.refreshData();

                    // update chart            
                    DateTime startDate = DateTime.Now.AddMonths(-6);
                    DateTime stopDate = DateTime.Now.AddMonths(24);
                    chartController.updateView(startDate, stopDate);
                    break;
 
            }
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            chartController.setVisibleCharts(new bool[] { chkFull.Checked, chkIncomes.Checked, chkExpenses.Checked, chkSavings.Checked });
        }

        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroComboBox cmb = (MetroComboBox)sender;
            switch (cmb.SelectedIndex)
            {
                case 0:
                    chartController.setChartType(System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column);
                    break;
                case 1:
                    chartController.setChartType(System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut);
                    break;
                case 2:
                    chartController.setChartType(System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line);
                    break;
                case 3:
                    chartController.setChartType(System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie);
                    break;
            }
        }

        private void dtLeft_ValueChanged(object sender, EventArgs e)
        {
            MetroDateTime dt = (MetroDateTime)sender;
            chartController.updateViewLeft(dt.Value);
        }

        private void dtRight_ValueChanged(object sender, EventArgs e)
        {
            MetroDateTime dt = (MetroDateTime)sender;
            chartController.updateViewRight(dt.Value);
        }
 
    }
}
