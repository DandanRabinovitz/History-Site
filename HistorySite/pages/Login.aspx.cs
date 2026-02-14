using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HistorySite.pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                User user = Helper.GetRow(Request.Form["userName"], Request.Form["password"]);

                if (user.userName == "Visitor")
                {
                    Session["Login"] = false;
                    message.InnerHtml = "Unknown username or password";
                }
                else
                {
                    Session["Login"] = true;
                    message.InnerHtml = "Admin: " + user.admin;
                    Session["userName"] = user.userName;
                    Session["Admin"] = user.admin;
                    Response.Redirect("Main.aspx");
                }
                Session["userName"] = user.userName;
                Session["Admin"] = user.admin;
            }

        }

        public static User GetRow(string userName, string password)
        // The Method check if there is a user with userName and Password. 
        // If true the Method return a user with the first Name and Admin property.
        // If not the Method return a user with first name "Visitor" and Admin = false

        {
            SqlConnection con = new SqlConnection(Helper.conString);

            string SQL = $"SELECT userName, admin FROM " + Helper.tblName +
                    $" WHERE userName='{userName}' AND password = '{password}'";
            SqlCommand cmd = new SqlCommand(SQL, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            User user = new User();
            if (reader.HasRows)
            {
                reader.Read();
                user.userName = reader.GetString(0);
                user.admin = reader.GetBoolean(1);

            }
            else
            {
                user.userName = "Visitor";
                user.admin = false;
            }
            reader.Close();
            con.Close();

            //while (reader.HasRows)
            //{
            //    reader.Read();
            //    user.userName = reader.GetValue(0).ToString();
            //    user.Admin = (bool)reader.GetValue(1);
            //    object obj = reader.GetValue(2);
            //    // Do something with Data
            //}
            return user;
        }

    }
}