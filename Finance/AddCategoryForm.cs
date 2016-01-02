using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MetroFramework.Controls;
using Finance.models;

namespace Finance
{
    /// <summary>
    /// Input form for a new financial category, or for displaying details of this category
    /// </summary>
    class AddCategoryForm : MetroFramework.Forms.MetroForm
    {
        private MetroFramework.Controls.MetroTextBox txtName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtDesc;
        private MetroFramework.Controls.MetroCheckBox chkRecurrent;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtValue;
        private MetroFramework.Controls.MetroButton btnDone;
        private MetroFramework.Controls.MetroLabel lblPeriod;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroDateTime startDate;
        private MetroFramework.Controls.MetroLabel lblWeeks;
        private MetroFramework.Controls.MetroTextBox txtWeeks;

        // the model that will be created with the data
        private FinanceCategoryData.Data data;

        public AddCategoryForm()
        {
            InitializeComponent();
        }

        // constructor used when this form is showed only for info and not for input
        public AddCategoryForm(FinanceCategoryData.Data data)
        {
            InitializeComponent();
            // if this is constructor is used, then this form will be used only to display details
            foreach (System.Windows.Forms.Control ctrl in this.Controls)
                ctrl.Enabled = false;

            this.txtName.Text = data.name;
            this.txtDesc.Text = data.desc;
            this.txtValue.Text = data.value + "";
            this.startDate.Value = data.start;

            // if this is recurrent. show extra info: the frequency;
            this.chkRecurrent.Checked = data.isRecurrent;
            this.txtWeeks.Text = data.repeatMonths + "";

            // disable done button. There is no input
            this.btnDone.Visible = false;
        }

        public AddCategoryForm(int category)
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtDesc = new MetroFramework.Controls.MetroTextBox();
            this.chkRecurrent = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtValue = new MetroFramework.Controls.MetroTextBox();
            this.btnDone = new MetroFramework.Controls.MetroButton();
            this.lblPeriod = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.startDate = new MetroFramework.Controls.MetroDateTime();
            this.lblWeeks = new MetroFramework.Controls.MetroLabel();
            this.txtWeeks = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.CustomButton.Image = null;
            this.txtName.CustomButton.Location = new System.Drawing.Point(198, 1);
            this.txtName.CustomButton.Name = "";
            this.txtName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtName.CustomButton.TabIndex = 1;
            this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtName.CustomButton.UseSelectable = true;
            this.txtName.CustomButton.Visible = false;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(112, 44);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.Size = new System.Drawing.Size(220, 23);
            this.txtName.TabIndex = 0;
            this.txtName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtName.UseSelectable = true;
            this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(25, 42);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(46, 25);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Type";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(371, 44);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(97, 25);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Description";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtDesc
            // 
            // 
            // 
            // 
            this.txtDesc.CustomButton.Image = null;
            this.txtDesc.CustomButton.Location = new System.Drawing.Point(160, 1);
            this.txtDesc.CustomButton.Name = "";
            this.txtDesc.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDesc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDesc.CustomButton.TabIndex = 1;
            this.txtDesc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDesc.CustomButton.UseSelectable = true;
            this.txtDesc.CustomButton.Visible = false;
            this.txtDesc.Lines = new string[0];
            this.txtDesc.Location = new System.Drawing.Point(498, 44);
            this.txtDesc.MaxLength = 32767;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.PasswordChar = '\0';
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDesc.SelectedText = "";
            this.txtDesc.SelectionLength = 0;
            this.txtDesc.SelectionStart = 0;
            this.txtDesc.Size = new System.Drawing.Size(182, 23);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtDesc.UseSelectable = true;
            this.txtDesc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDesc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chkRecurrent
            // 
            this.chkRecurrent.AutoSize = true;
            this.chkRecurrent.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkRecurrent.Location = new System.Drawing.Point(25, 158);
            this.chkRecurrent.Name = "chkRecurrent";
            this.chkRecurrent.Size = new System.Drawing.Size(103, 25);
            this.chkRecurrent.TabIndex = 6;
            this.chkRecurrent.Text = "Recurrent";
            this.chkRecurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRecurrent.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkRecurrent.UseSelectable = true;
            this.chkRecurrent.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(378, 99);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(53, 25);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Value";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtValue
            // 
            // 
            // 
            // 
            this.txtValue.CustomButton.Image = null;
            this.txtValue.CustomButton.Location = new System.Drawing.Point(160, 1);
            this.txtValue.CustomButton.Name = "";
            this.txtValue.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtValue.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtValue.CustomButton.TabIndex = 1;
            this.txtValue.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtValue.CustomButton.UseSelectable = true;
            this.txtValue.CustomButton.Visible = false;
            this.txtValue.Lines = new string[0];
            this.txtValue.Location = new System.Drawing.Point(498, 99);
            this.txtValue.MaxLength = 32767;
            this.txtValue.Name = "txtValue";
            this.txtValue.PasswordChar = '\0';
            this.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtValue.SelectedText = "";
            this.txtValue.SelectionLength = 0;
            this.txtValue.SelectionStart = 0;
            this.txtValue.ShowClearButton = true;
            this.txtValue.Size = new System.Drawing.Size(182, 23);
            this.txtValue.TabIndex = 8;
            this.txtValue.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtValue.UseSelectable = true;
            this.txtValue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtValue.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtValue.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(311, 216);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 9;
            this.btnDone.Text = "Done";
            this.btnDone.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDone.UseSelectable = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPeriod.Location = new System.Drawing.Point(378, 162);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(64, 25);
            this.lblPeriod.TabIndex = 11;
            this.lblPeriod.Text = "Repeat";
            this.lblPeriod.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblPeriod.Visible = false;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(25, 103);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(47, 25);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Date";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(112, 99);
            this.startDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(220, 29);
            this.startDate.TabIndex = 13;
            this.startDate.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblWeeks
            // 
            this.lblWeeks.AutoSize = true;
            this.lblWeeks.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblWeeks.Location = new System.Drawing.Point(620, 162);
            this.lblWeeks.Name = "lblWeeks";
            this.lblWeeks.Size = new System.Drawing.Size(69, 25);
            this.lblWeeks.TabIndex = 14;
            this.lblWeeks.Text = "months";
            this.lblWeeks.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblWeeks.Visible = false;
            // 
            // txtWeeks
            // 
            // 
            // 
            // 
            this.txtWeeks.CustomButton.Image = null;
            this.txtWeeks.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.txtWeeks.CustomButton.Name = "";
            this.txtWeeks.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtWeeks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtWeeks.CustomButton.TabIndex = 1;
            this.txtWeeks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtWeeks.CustomButton.UseSelectable = true;
            this.txtWeeks.CustomButton.Visible = false;
            this.txtWeeks.Lines = new string[0];
            this.txtWeeks.Location = new System.Drawing.Point(498, 164);
            this.txtWeeks.MaxLength = 32767;
            this.txtWeeks.Name = "txtWeeks";
            this.txtWeeks.PasswordChar = '\0';
            this.txtWeeks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtWeeks.SelectedText = "";
            this.txtWeeks.SelectionLength = 0;
            this.txtWeeks.SelectionStart = 0;
            this.txtWeeks.ShowClearButton = true;
            this.txtWeeks.Size = new System.Drawing.Size(100, 23);
            this.txtWeeks.TabIndex = 15;
            this.txtWeeks.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtWeeks.UseSelectable = true;
            this.txtWeeks.Visible = false;
            this.txtWeeks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtWeeks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtWeeks.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
            // 
            // AddCategoryForm
            // 
            this.AcceptButton = this.btnDone;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(703, 267);
            this.Controls.Add(this.txtWeeks);
            this.Controls.Add(this.lblWeeks);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.chkRecurrent);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtName);
            this.Name = "AddCategoryForm";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // action for done button
        private void btnDone_Click(object sender, EventArgs e)
        {
            // prepare "Data" object to be sent back to main form.
            // the object will be a data adapter for each category.
            data.name = txtName.Text;
            data.desc = txtDesc.Text;
            data.isRecurrent = chkRecurrent.Checked;
            
            // parse the integers for value and  repeat cycle
            try
            {
                data.start = startDate.Value;
                data.value = int.Parse(txtValue.Text);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.ToString());
                data.value = 0;
                data.repeatMonths = 0;
            }

            if (data.isRecurrent)
            {
                try
                {
                    data.repeatMonths = int.Parse(txtWeeks.Text);
                }
                catch
                {
                    data.repeatMonths = 0;
                }
            }


            // end form dialog
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        // event for text box to create a masked text box (only digits)
        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = (MetroFramework.Controls.MetroTextBox)sender;
            txtValue.TextChanged -= metroTextBox1_TextChanged;
            try
            {
                if (Char.IsDigit(txt.Text[txt.Text.Length - 1]) == false)
                {
                    txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
                    txt.SelectionStart = txt.Text.Length;
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            txtValue.TextChanged += metroTextBox1_TextChanged;
        }

        // event for checkBox if category is recurrent: visible/not visible
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroCheckBox chk = (MetroFramework.Controls.MetroCheckBox)sender;

            if (chk.Checked)
            {
                this.txtWeeks.Visible = true;
                this.lblPeriod.Visible = true;
                this.lblWeeks.Visible = true;
            }
            else
            {
                this.txtWeeks.Visible = false;
                this.lblPeriod.Visible = false;
                this.lblWeeks.Visible = false;
            }

        }

        // used to send data from input form to the calling form ( Main Form);
        public FinanceCategoryData.Data getData()
        {
            return this.data;
        }

    }
}
