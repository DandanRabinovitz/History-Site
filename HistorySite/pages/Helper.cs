using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public static class Helper
{
    public const string DBName = "Database.mdf";   
    public const string tblName = "tblUsers";      
    public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\"
                                    + DBName + ";Integrated Security=True";   

    public static DataSet RetrieveTable(string SQLStr)
    // Gets A table from the data base acording to the SELECT Command in SQLStr;
    // Returns DataSet with the Table.
    {

        SqlConnection con = new SqlConnection(conString);

        SqlCommand cmd = new SqlCommand(SQLStr, con);

        SqlDataAdapter ad = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();

        ad.Fill(ds, tblName);

        return ds;
    }

    public static object GetScalar(string SQL)
    {
        SqlConnection con = new SqlConnection(conString);

        SqlCommand cmd = new SqlCommand(SQL, con);

        con.Open();
        object scalar = cmd.ExecuteScalar();
        con.Close();

        return scalar;
    }

    public static int ExecuteNonQuery(string SQL)
    {
        SqlConnection con = new SqlConnection(conString);

        SqlCommand cmd = new SqlCommand(SQL, con);

        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        return n;
    }

    public static void Delete(int[] userIdToDelete)
    // The Array "userIdToDelete" contain the id of the users to delete. 
    // Delets all the users in the array "userIdToDelete".
    {
        SqlConnection con = new SqlConnection(conString);

        string SQL = "SELECT * FROM " + tblName;
        SqlCommand cmd = new SqlCommand(SQL, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, tblName);

        for (int i = 0; i < userIdToDelete.Length; i++)
        {
            {
                DataRow[] dr = ds.Tables[tblName].Select($"userId = {userIdToDelete[i]}");
                dr[0].Delete();
            }
        }

        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetDeleteCommand();
        adapter.Update(ds, tblName);
    }

    public static void Update(User user)
    // The Method recieve a user objects. Find the user in the DataBase acording to his userId and update all the other properties in DB.
    {
        SqlConnection con = new SqlConnection(conString);

        string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where userid={user.userId}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        DataRow dr = ds.Tables[tblName].Rows[0];
        dr["firstName"] = user.firstName;
        dr["lastName"] = user.lastName;
        dr["userName"] = user.userName;
        dr["password"] = user.password;
        dr["birthday"] = user.birthday;
        dr["city"] = user.city;
        dr["country"] = user.country;

        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, tblName);

    }

    public static void Insert(User user)
    // The Method recieve a user object and inserts it to the Database as new row. 
    // The Method does't check if the user is already taken.
    {
        //HttpRequest Request
        // התחברות למסד הנתונים
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);

        string SQLStr = $"SELECT * FROM " + tblName + " WHERE 0=1";//returns 0 rows in tblname to show the row structure
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        DataSet ds = new DataSet();

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        DataRow dr = ds.Tables[tblName].NewRow();
        dr["firstName"] = user.firstName;
        dr["lastName"] = user.lastName;
        dr["userName"] = user.userName;
        dr["password"] = user.password;
        dr["birthday"] = user.birthday;
        dr["city"] = user.city;
        dr["country"] = user.country;
        ds.Tables[tblName].Rows.Add(dr);

        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetInsertCommand();
        adapter.Update(ds, tblName);
    }

    public static User GetRow(string userName, string password)
    // The Method check if there is a user with userName and Password. 
    // If true the Method return a user with the first Name and Admin property.
    // If not the Method return a user wuth first name "Visitor" and Admin = false

    {
        SqlConnection con = new SqlConnection(conString);

        string SQL = $"SELECT firstName, admin FROM " + tblName +
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
        return user;
    }

    public static string BuildSimpleUsersTable(DataTable dt)
    // the Method Build HTML user Table using the users in the DataTable dt.
    {
        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + row[column] + "</td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string BuildUsersTable(DataTable dt)
    // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
    {

        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        str += "<td> </td>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            str += "<td>" + CreateRadioBtn(row["userId"].ToString()) + "</td>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + row[column] + "</td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string CreateRadioBtn(string id)
    {
        return $"<input type='checkbox' name='chk{id}' id='chk{id}' runat='server' />";
    }

    public static DataTable SortTable(DataTable dt, string column, string dir)
    {
        dt.DefaultView.Sort = column + " " + dir;
        return dt.DefaultView.ToTable();
    }

    public static DataTable FilterTable(DataTable dt, string column, string criteria)
    {
        dt.DefaultView.RowFilter = column + "=" + criteria;
        return dt.DefaultView.ToTable();
    }
}