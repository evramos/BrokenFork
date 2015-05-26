using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DotsNBoxes
{
    /// <summary>
    /// 
    /// </summary>
    class CustomTabControl : TabControl
    {
        /// <summary>
        /// The message ID of the render tab message
        /// </summary>
        const int RENDER_TAB = 0x1328;
        
        protected override void WndProc(ref Message m)
        {
            //If this is the render tab message, block it
            if (m.Msg == RENDER_TAB && !DesignMode)
            {
                m.Result = (IntPtr)1;
            }

            //Otherwise process the message normally
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //Determine if the current key combination changes the current tab
            bool changeTabKeyCombo = (e.Control &&
                (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Next || e.KeyCode == Keys.Prior));

            //Only process the keystrokes if they won't change our tab index
            if(!changeTabKeyCombo)
            {
                base.OnKeyDown(e);
            }
        }
    }
}
