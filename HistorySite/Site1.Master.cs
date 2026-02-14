using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HistorySite
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null && (bool)Session["Admin"] == true)
            {
                btnLogout.Visible = true;
                bar1.Visible = false;
                bar2.Visible = false;
                bar3.Visible = true;
                bar4.Visible = true;
                bar5.Visible = false;
                bar6.Visible = true;
                bar7.Visible = true;
                bar8.Visible = true;
                
            }
            else if (Session["Login"] != null && (bool)Session["Login"] == true)
            {
                btnLogout.Visible = true;
                bar1.Visible = false;
                bar2.Visible = false;
                bar3.Visible = true;
                bar4.Visible = true;
                bar5.Visible = true;
                bar6.Visible = true;
                bar7.Visible = true;
                bar8.Visible = false;
            }
            else
            {
                btnLogout.Visible = false;
                bar1.Visible = true;
                bar2.Visible = true;
                bar3.Visible = false;
                bar4.Visible = false;
                bar5.Visible = false;
                bar6.Visible = false;
                bar7.Visible = false;
                bar8.Visible = false;
            }
        }
        protected void logoutbtn(object sender, EventArgs e)
        {
            Session["userName"] = "visitor";
            Session["Login"] = false;
            Session["Admin"] = false;
            Response.Redirect("Main.aspx");
        }
    }
}