using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HistorySite.pages
{
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string SQL = $"SELECT COUNT (admin) FROM " + Helper.tblName +
                    $" WHERE userName='{Request.Form["userName"]}'";

                int count = (int)Helper.GetScalar(SQL);
                if (count > 0)
                {
                    userNameAlert.InnerHtml = "User Name is taken";
                }
                else
                {       
                    SQL = $"INSERT INTO {Helper.tblName} " +
                    "(firstName, lastName, userName, password, admin, birthday, city, country) " +
                    $"VALUES ('{Request.Form["firstName"]}', '{Request.Form["lastName"]}', " +
                    $"'{Request.Form["userName"]}', '{Request.Form["password"]}', " +
                    $"'0', '{Request.Form["birthday"]}', " +
                    $"'{Request.Form["city"]}', '{Request.Form["country"]}')";
                    Helper.ExecuteNonQuery(SQL);
                    Response.Redirect("Login.aspx");
                }
            }

        }

    }

}