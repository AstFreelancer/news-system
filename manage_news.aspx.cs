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

public partial class manage_news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null ||
            Session["user"].ToString() != "admin")
        {
            Response.Redirect("login.aspx");
        }

    }
    public void ShowNews()
    {
       SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=YanaSedova-3;User ID=YanaSedova-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
        Connection.Open();

        SqlCommand Command = new SqlCommand("SELECT * FROM news", Connection);
        SqlDataReader Reader = Command.ExecuteReader();

        while (Reader.Read())
        {
            string check = "Подтверждена";
            if (Reader.GetString(3) == "0")
                check = "<a href='check_news.aspx?id=" + Reader.GetInt32(4).ToString() + "'>Подтвердить</a>";
            Response.Write(
                "<tr>\n" +
                "<td><b>" + Reader.GetString(0).ToString() + "</b></td>" +
                "<td>" + Reader.GetString(1).ToString() + "</td>" +
                "<td>" + Reader.GetDateTime(2).ToString() + "</td>" +
                "<td>" + check +
                "<td>" + "<a href='deletenews.aspx?id=" + Reader.GetInt32(4).ToString() + "'>Удалить</a></td>\n" +
                "</tr>\n"
                );
        }
        Reader.Close();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
