using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.models
{
    class FinanceCategoryData
    {
        // Global codes
        public const int INCOMES = 0;
        public const int EXPENSES = 1;
        public const int SAVINGS = 2;

        // the data backing this category: must be serializable in order to write/read from files
        [Serializable]
        public struct Data
        {
            // the name of the category
            public string name;
            // short desctiption
            public string desc;
            // the value in EUR
            public int value;
            // if this financial category repeats 
            public bool isRecurrent;
            // if the category is recurrent, this is 
            public int repeatMonths;

            // the start date of this category ( if is recurrent)
            // if not recurrent, this will be the date on which the financial event happened
            public DateTime start;


            public override string ToString()
            {
                return name + ": " + desc;
            }

            public static bool operator != (Data d1, Data d2)
            {
                return (!d1.name.Equals(d2.name) ||
                            !d1.desc.Equals(d2.desc) ||
                            !d1.start.Equals(d2.start) ||
                             d1.value != d2.value ||
                             d1.repeatMonths != d2.repeatMonths);
            }

            public static bool operator ==(Data d1, Data d2)
            {
                return (d1.name.Equals(d2.name) &&
                             d1.desc.Equals(d2.desc) &&
                             d1.start.Equals(d2.start) &&
                             d1.value == d2.value &&
                             d1.repeatMonths == d2.repeatMonths);
            }



        }
    }
}
