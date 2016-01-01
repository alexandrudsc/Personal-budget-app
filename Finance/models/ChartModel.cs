using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.models
{
    class ChartModel
    {

        List<FinanceCategoryData.Data> incomes;
        List<FinanceCategoryData.Data> expenses;
        List<FinanceCategoryData.Data> savings;

        public List<FinanceCategoryData.Data> Incomes
        {
            get 
            { 
                return this.incomes; 
            }

        }

        public List<FinanceCategoryData.Data> Expenses
        {
            get 
            { 
                return this.expenses;
            }

        }

        public List<FinanceCategoryData.Data> Savings
        {
            get 
            { 
                return this.savings; 
            }

        }

        public ChartModel()
        {
            incomes = Utils.retreiveAll(FinanceCategoryData.INCOMES);
            expenses = Utils.retreiveAll(FinanceCategoryData.EXPENSES);
            savings = Utils.retreiveAll(FinanceCategoryData.SAVINGS);
        }

    }
}
