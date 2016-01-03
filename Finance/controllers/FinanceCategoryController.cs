using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Finance.models;
using Finance.views;

namespace Finance.controllers
{
    /// <summary>
    /// Controller class for the FiananceCategory view.
    /// The model managed by this controller can be changed, if it is valid
    /// </summary>
    class FinanceCategoryController
    {
        // event for  delete button is pressed on a FinanceCategory
        public delegate void Delete(FinanceCategory view, FinanceCategoryData.Data model);
        public event Delete ItemDeleted;
        public event Delete ItemEdit;

        private FinanceCategoryData.Data model;
        private FinanceCategory view;

        public FinanceCategoryController(FinanceCategoryData.Data model, FinanceCategory view)
        {
            setModel(model);
            this.view = view;

            // add click listener for displaying details of financial category when the tile is clicked
            this.view.Controls["tile"].Click += tile_Click;

            // add click listener for delete button on the tile
            this.view.Controls[0].Controls["btnDelete"].Click += btnDelete_Click;

            // add click listener for edit button on the tile
            this.view.Controls[0].Controls["btnEdit"].Click += btnEdit_Click;
        }

        public void setModel(FinanceCategoryData.Data model)
        {
            validateModel(model);
            this.model = model;
        }

        public void updateView()
        {
            // set the text appering at the bottom of the tile
            this.view.setViewName(model.name + ": " + model.value);

            // set the text from the lable on the middle left of the tile 
            this.view.setViewDescription(model.desc);
        }

        private void validateModel(FinanceCategoryData.Data model)
        {
            // check the params
            if (model.name == null || model.name.Equals(""))
                throw new ArgumentException("Category name cannot be empty");
            if (model.desc == null || model.desc.Equals(""))
                throw new ArgumentException("Category description cannot be empty");
        }

        // display details at a click on the tile
        private void tile_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("message " + model.name);
            new AddCategoryForm(model).ShowDialog();
        }

        // raise event for deleting a event
        void btnDelete_Click(object sender, EventArgs e)
        {
            // try-catch block in case no handler is registered
            try
            {
                ItemDeleted(this.view, this.model);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            // try-catch block in case no handler is registered
            try
            {
                ItemEdit(this.view, this.model);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
