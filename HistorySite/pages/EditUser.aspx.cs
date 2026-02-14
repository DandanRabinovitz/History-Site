using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;

namespace HistorySite.pages
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {
                if (Session["userToUpdate"] != null)
                {
                    int userId = (int)Session["userToUpdate"];

                    string sql = $"SELECT * FROM tblUsers WHERE userId = {userId}";
                    DataSet ds = Helper.RetrieveTable(sql);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];

                        firstName.Value = dr["FirstName"].ToString();
                        lastName.Value = dr["LastName"].ToString();
                        password.Value = dr["Password"].ToString();
                        if (!dr.IsNull("birthday"))
                        {
                            birthday.Value = ((DateTime)(dr["birthday"])).ToString("yyy-MM-dd");
                        }
                        city.Value = dr["city"].ToString();
                        country.Value = dr["country"].ToString();
                    }
                }
            }
        }
        

        public void UpdateUser(object sender, EventArgs e)
        {

            string connectionString = Helper.conString;
            SqlConnection con = new SqlConnection(connectionString);

            int userId = (int)Session["userToUpdate"];
            string SQLStr = $"SELECT * FROM tblUsers Where userid={userId}";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "tblUsers");

            DataRow dr = ds.Tables["tblUsers"].Rows[0];
            ds.Tables["tblUsers"].Rows[0]["firstName"] = firstName.Value;
            ds.Tables["tblUsers"].Rows[0]["lastName"] = lastName.Value;
            dr["password"] = password.Value;
            dr["birthday"] = DateTime.Parse(birthday.Value);
            dr["city"] = city.Value;
            dr["country"] = country.Value;

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds, "tblUsers");

            Response.Redirect("UsersTable.aspx");
        }
    }
}