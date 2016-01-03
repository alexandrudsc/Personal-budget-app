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
    /// Interface for defining interaction with the items of the list.
    /// Events are raised from the controller (Basic MVP merged with MVC)
    /// </summary>
    interface ListItemListener
    {
        // event handler for the delete button from the tile
        void deleteItem(FinanceCategory view, FinanceCategoryData.Data model);
        // event handler for the edit button from the tile
        void editItem(FinanceCategory view, FinanceCategoryData.Data model);
    }
}
