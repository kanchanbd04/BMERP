using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlineTicketingSystem
{
    public class zsetvalue
    {
        public static void SetDWNumItem(DropDownList dw,int start, int end)
        {
            dw.Items.Clear();
            dw.Items.Add("");
            for (int i = start; i <= end; i++)
            {
                dw.Items.Add(i.ToString());
            }
            dw.Text = "";
        }
    }
}