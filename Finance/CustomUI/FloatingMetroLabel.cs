using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Finance.CustomUI
{
    /// <summary>
    /// Custom label that passes mouse click to parent below
    /// </summary>
    class FloatingMetroLabel: MetroLabel
    {

        
        protected override void WndProc(ref Message m)
        {
            // MSDN: "Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate."
            const int WM_NCHITTEST = 0x0084;
            // code for resending message o window below
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST)
            {
                // send the message to the underlying window
                m.Result = (IntPtr)HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
