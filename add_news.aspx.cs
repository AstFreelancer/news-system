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
using System.Web.Mail;

public partial class add_news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null ||
             (Session["user"].ToString() != "user" &&
             Session["user"].ToString() != "admin"))
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=user-3;User ID=user-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
        Connection.Open();

        string author = (Session["name"].ToString().Replace("'", "")).Trim();
        string text = TextBox1.Text.Replace("'", "");
        text.Replace("\n", "<br>");
        SqlCommand Command = new SqlCommand("INSERT INTO news VALUES ('" + author + "', '" + text + "',GETDATE(),0)");
        Command.Connection = Connection;
        Command.ExecuteScalar();
        MailMessage oMsg = new MailMessage();
        oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
        oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "Yana");
        oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "1234567");
        oMsg.From = "lab5@rambler.ru";
        oMsg.To = "user@rambler.ru";
        oMsg.Subject = "На сайт добавлена новость";
        oMsg.Body = "Новость: "+ text + " ждет подтверждения.";
        SmtpMail.SmtpServer = "localhost";
        try { SmtpMail.Send(oMsg); }
        catch (Exception Ex) { } 
    
        Response.Redirect("default.aspx");
    //    TextBox1.Text
    }
}
