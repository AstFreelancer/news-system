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

public partial class check_news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        Label2.Visible = false;
        LinkButton1.Visible = false;
        if (Session["user"] == null || 
            Session["user"].ToString() != "admin")
        {
            Label1.Visible = true;
       }
        if (Session["name"] == null ||
            Session["IsLogged"] == null)
        {
            Label1.Visible = true;
            return;
        }
       SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=user-3;User ID=user-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
        Connection.Open();

        if (Page.Request["id"] == null)
        {
            Label1.Text = "Необходимо указать номер новости в параметрах командной строки";
            Label1.Visible = true;
            return;
        }
        SqlCommand Command = new SqlCommand("UPDATE news SET isChecked=1 WHERE id = " + Page.Request["id"], Connection);
        Command.ExecuteScalar();

        Label1.Text = "Новость " + Page.Request["id"].ToString() + " подтверждена";
        Label1.Visible = true;

        LinkButton1.Visible = true;

        Command = new SqlCommand("SELECT author,text FROM news WHERE id = '" + Page.Request["id"].ToString() + "'", Connection);
        SqlDataReader Reader = Command.ExecuteReader();
        if (!Reader.HasRows)
            return;
        Reader.Read();
        string author = Reader.GetString(0).ToString();
        string text = Reader.GetString(1).ToString();
        Reader.Close();

        SqlCommand Command1 = new SqlCommand("SELECT email FROM users WHERE login = '" + author + "'", Connection);
        SqlDataReader Reader1 = Command1.ExecuteReader();
        if (!Reader1.HasRows)
            return;
        Reader1.Read();
        string email = Reader1.GetString(0).ToString();
        Reader1.Close();

        MailMessage oMsg = new MailMessage();
        oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
        oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "Yana");
        oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "1234567");
        oMsg.From = "lab5@rambler.ru";
        oMsg.To = email;
        oMsg.Subject = "Подтверждение новости";
        oMsg.Body = "Привет, " + author + "! Новость "+ text + " подтверждена.";
        SmtpMail.SmtpServer = "localhost";
        try { SmtpMail.Send(oMsg); }
        catch (Exception Ex) { } 

        Label2.Text = "На ящик "+email+" отправлено уведомление";
        Label2.Visible = true;
    }
}
