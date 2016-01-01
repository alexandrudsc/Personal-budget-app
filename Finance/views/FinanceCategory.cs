using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Finance.CustomUI;

namespace Finance.views
{
    /// <summary>
    /// Class to  manage a financial category, only from visual point of view.
    /// Derives from group box and contains a tile covering the whole group.
    /// The tile has it's own name, appearing on the bottom.
    /// A label at the middle left containing the description.
    /// Used as "View" in MCV pattern
    /// </summary>
    class FinanceCategory: GroupBox
    {

        // the tile covering all group box surface
        protected MetroTile tile;

        // label description. Is floating, in order to send click events to the parent (the tile)
        private FloatingMetroLabel lblDescr;

        private MetroButton btnDelete;

        public FinanceCategory()
        {
            this.Text = "";
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);

            initComponents();
        }


        /**
         * Init the graphical components with the backing data
         */
        private void initComponents()
        {
            // create main tile
            tile = new MetroTile();
            tile.Name = "tile";
            tile.Width = this.Width - 12;
            tile.Height = this.Height - 16;
            tile.Location = new System.Drawing.Point(6, 10);

            // create label for description
            lblDescr = new FloatingMetroLabel();
            lblDescr.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            lblDescr.Location = new System.Drawing.Point(6, 30);
            
            // create delete button
            btnDelete = new MetroButton();
            btnDelete.Name = "btnDelete";
            btnDelete.Width = 20;
            btnDelete.Height = 20;
            btnDelete.Text = "X";
            btnDelete.Theme = MetroFramework.MetroThemeStyle.Dark;
            btnDelete.Tag = this;
            btnDelete.Padding = new System.Windows.Forms.Padding(0);
            btnDelete.Margin = new System.Windows.Forms.Padding(0);
            btnDelete.Location = new System.Drawing.Point(this.Width - 30, 0);
            btnDelete.BringToFront();

            // add tile to groupbox;
            this.Controls.Add(tile);

            // add delete button to the tile
            this.Controls[0].Controls.Add(btnDelete);

            // add description to the tile;
            this.Controls[0].Controls.Add(lblDescr);
            
        }


        public void setViewName(string text)
        {
            this.tile.Text = text;
        }

        public void setViewDescription(string text)
        {
            this.lblDescr.Text = text;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

    }


}
