using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Finance.models;
using Finance.views;

namespace Finance.controllers
{
    /// <summary>
    /// Controller class for displaying a list of categories
    /// </summary>
    class GridListAdapter : ListItemListener
    {

        // a panel displaying a grid list of categories (list of views)
        private Panel panelList;

        // list of data retreived from file (list of models)
        List<FinanceCategoryData.Data> list;

        private int majorCategory = -1;

        public GridListAdapter(Panel list)
        {
            this.panelList = list;
        }

        // refresh the grid list of the current selected category
        public void refreshList(int majorCategory)
        {

            FinanceCategory view;
            FinanceCategoryController controller;

            // keep what major category is displayed. Used when the file is deleted and recreated for deleting a file
            this.majorCategory = majorCategory;

            // clear the current list
            this.panelList.Controls.Clear();

            // get all categories of this major from the binary files;
            list = Utils.retreiveAll(majorCategory);

            // add all categories to the grid list
            foreach (FinanceCategoryData.Data model in list)
            {
                // create the view
                view = new FinanceCategory();

                // create controller for this category
                controller = new FinanceCategoryController(model, view);
                controller.updateView();
                // register listener for each item
                controller.ItemDeleted += deleteItem;
                controller.ItemEdit += editItem;

                this.panelList.Controls.Add(view);
            }

        }

        // handler for ItemDelete event;
        public void deleteItem(FinanceCategory view, FinanceCategoryData.Data model) 
        {
            string filename = majorCategory + ".dat";
            // delete current file
            Utils.deleteFile(filename);
            // save all items to new file, except the deleted item
            foreach (FinanceCategoryData.Data m in list)
                if (m != model)
                    Utils.save<FinanceCategoryData.Data>(m, filename);

            // refresh the list
            refreshList(majorCategory);
        }

        // handler for ItemEdit event
        public void editItem(FinanceCategory view, FinanceCategoryData.Data model)
        {
            string filename = majorCategory + ".dat";
            FinanceCategoryData.Data nModel = model;
            AddCategoryForm f = new AddCategoryForm(nModel, true);
            
            // if the user sended the input ...
            if (DialogResult.OK == f.ShowDialog())
            {
                nModel = f.getData();
                //... delete the old file of items 
                Utils.deleteFile(filename);
                //... save all items to new file, and instead of the selected item write the new item
                foreach (FinanceCategoryData.Data m in list)
                    if (m != model)
                        Utils.save<FinanceCategoryData.Data>(m, filename);
                    else
                        Utils.save<FinanceCategoryData.Data>(nModel, filename);
            }
            refreshList(majorCategory);
        }
    }
}
