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

public partial class delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        Button1.Visible = true;
        LinkButton1.Visible = false;
        if (Session["user"] == null || 
            Session["user"].ToString() != "admin")
        {
            Label1.Text = "Вы не администратор и поэтому можете удалить только свою учетную запись";
            Label1.Visible = true;
            Button1.Visible =false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["name"] == null ||
            Session["IsLogged"] == null)
        {
            Label1.Visible = true;
            Button1.Visible = false;
            return;
        }
       SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=user-3;User ID=user-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
        Connection.Open();

/*        SqlCommand Command = new SqlCommand("SELECT * FROM users WHERE login = '" + Session["name"].ToString() + "'", Connection);
        SqlDataReader Reader = Command.ExecuteReader();

        if (!Reader.HasRows)
        {
            Label1.Visible = true;
            Button1.Visible = false;
            Reader.Close();
            return;
        }
/*        if (Reader.GetString(0)=="Yana")
        {
            Label1.Text = "Вы администратор и поэтому не можете удалить свою учетную запись";
            Label1.Visible = true;
            Button1.Visible = false;
        }
  */      
  //      Reader.Close();
        if (Page.Request["name"] == null)
        {
            Label1.Text = "Необходимо указать имя в параметрах командной строки";
            Label1.Visible = true;
            Button1.Visible = false;
            return;
        }
        SqlCommand Command = new SqlCommand("DELETE FROM users WHERE login = '" + Page.Request["name"]+"'",Connection);
        Command.ExecuteScalar();

        Button1.Visible=false;
        Label1.Text="Учетная запись пользователя "+Page.Request["name"].ToString()+" удалена";
        Label1.Visible=true;
        
        LinkButton1.Visible = true;

//        Response.Redirect("default.aspx");
    }
}
