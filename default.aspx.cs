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
public partial class view_news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsLogged"] == null ||
            Session["IsLogged"].ToString() != "true")
        {
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
            LinkButton3.Visible = false;
            LinkButton5.Visible = true;
            LinkButton6.Visible = false;
            Label2.Text = "У вас полномочия гостя, то есть на чтение";
            Label2.Visible = true;
        }
        else
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            LinkButton5.Visible = false;
            LinkButton6.Visible = true;
        }
       
        if (Session["user"] == "user")
        {
            LinkButton1.Visible = true;
            LinkButton2.Visible = false;
            LinkButton3.Visible = false;
            Label1.Text = "Привет, "+Session["name"];
            Label2.Text = "У вас полномочия пользователя, то есть на добавление";
            Label2.Visible = true;
            LinkButton6.Visible = true;
        }
        else
            if (Session["user"] == "admin")
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = true;
                LinkButton3.Visible = true;
                Label1.Text = "Привет, "+Session["name"];
                Label2.Text = "У вас полномочия администратора";
                Label2.Visible = true;
                LinkButton6.Visible = true;
            }
            else
            {
                Label1.Text = "Привет, гость";
                LinkButton6.Visible = false;
            }

    }
    public void ShowNews()
    {
       SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=YanaSedova-3;User ID=YanaSedova-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
        Connection.Open();

        SqlCommand Command = new SqlCommand("SELECT * FROM news", Connection);
        SqlDataReader Reader = Command.ExecuteReader();

	if (!Reader.HasRows)
		return;
        while (Reader.Read())
        {
            if (Reader.GetString(3) == "0")
                continue;
            Response.Write(
                "<tr>\n" +
                "<td><b>" + Reader.GetString(0).ToString() + "</b></td>" +
                "<td>" + Reader.GetString(1).ToString() + "</td>" +
                "<td>" + Reader.GetDateTime(2).ToString() + "</td>" +
                "</tr>\n"
                );
        }
        Reader.Close();
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["IsLogged"] = null;
    }
}
