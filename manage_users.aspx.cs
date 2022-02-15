using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class manage_users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null ||
            Session["user"].ToString() != "admin")
        {
            Response.Redirect("login.aspx");
        }

   
    }
    public void ShowUsers()
    {
       SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=YanaSedova-3;User ID=YanaSedova-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
        Connection.Open();

        SqlCommand Command = new SqlCommand("SELECT login,email FROM users", Connection);
        SqlDataReader Reader = Command.ExecuteReader();

//        int len = Reader.VisibleFieldCount;
  //      Reader.
        while (Reader.Read())
        {
            Response.Write(
                "<tr>\n" +
                "<td><b>" + Reader.GetString(0).ToString() + "</b></td>" +
                "<td><b>" + Reader.GetString(1).ToString() + "</b></td>" +
                "<td>" + "<a href='deleteof.aspx?name=" + Reader.GetString(0).ToString() + "'>Удалить</a></td>\n" +
                "</tr>\n"
                );
        }
        Reader.Close();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
