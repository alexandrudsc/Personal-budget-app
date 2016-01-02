using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Controls;

namespace Finance.CustomUI
{
    /// <summary>
    /// MetroMaskedTextBox accepting only digits
    /// </summary>
    class MetroNumberInput: MetroTextBox
    {

        public MetroNumberInput()
        {
            enableDigitsOnly();
        }

        private void enableDigitsOnly()
        {
            this.TextChanged += event_TextChanged;
        }

        // event for text box to create a masked text box (only digits)
        private void event_TextChanged(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTextBox txt = (MetroFramework.Controls.MetroTextBox)sender;
            this.TextChanged -= event_TextChanged;
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
            this.TextChanged += event_TextChanged;
        }

    }
}
