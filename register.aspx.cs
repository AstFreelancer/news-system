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

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginTextBox.Focus();

        LoginErrorLabel.Visible = false;
        PassErrorLabel.Visible = false;
        PassAgainErrorLabel.Visible = false;
        CaptchaErrorLabel.Visible = false;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
            if (!captcha.CheckCaptcha(CaptchaTextBox.Text))
            {
                CaptchaErrorLabel.Text = "Введенное число не совпадает с указанным на картинке";
                CaptchaErrorLabel.Visible = true;
                CaptchaTextBox.Text = "";
                return;
            }

            if (!CheckLogin.CheckPass(PassAgainTextBox.Text))
            {
                PassAgainErrorLabel.Text = "Неправильный e-mail";
                LoginErrorLabel.Visible = true;
            }
       SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=user-3;User ID=user-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
            Connection.Open();

        if (!CheckLogin.Check(LoginTextBox.Text))
        {
            LoginErrorLabel.Text = "Логин может содержать только буквы, цифры, пробелы и знаки подчеркивания";
            LoginErrorLabel.Visible = true;
        }
        else
        {
            string login = (LoginTextBox.Text.Replace("'", "")).Trim();
            SqlCommand Command = new SqlCommand("SELECT * FROM users WHERE login = '" + login + "'", Connection);
            SqlDataReader Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                LoginErrorLabel.Text = "Такой пользователь уже есть";
                LoginErrorLabel.Visible = true;
                Reader.Close();
                return;
            }

            Reader.Close();
        }

        if (!CheckLogin.Check(PassTextBox.Text))
        {
            PassErrorLabel.Text = "Пароль может содержать только буквы, цифры, пробелы и знаки подчеркивания";
            PassErrorLabel.Visible = true;
        }
        else
            if (PassTextBox.Text != PassAgainTextBox.Text)
            {
                PassAgainErrorLabel.Text = "Введенные пароли должны совпадать";
                PassAgainErrorLabel.Visible = true;
            }
            else
            {
                string login = (LoginTextBox.Text.Replace("'", "")).Trim();
                string pass = (PassAgainTextBox.Text.Replace("'", "")).Trim();
                string email = (TextBox1.Text.Replace("'", "")).Trim();
                SqlCommand Command = new SqlCommand(/*"SELECT * FROM users WHERE login = '" + login + "'", Connection*/);
                string PassMD5 = FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "md5");
                Command.CommandText = "INSERT INTO users VALUES ('" + login + "', '" + PassMD5 + "',0,'"+email+"',0)";
                Command.Connection = Connection;
                Command.ExecuteScalar();

                MailMessage oMsg = new MailMessage();
                oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
        oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "Yana");
        oMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "1234567");
                oMsg.From = "lab5@rambler.ru";
                oMsg.To = email;
                oMsg.Subject = "Регистрация в новостной системе (лаб. 5)";
                oMsg.Body = "Для подтверждения регистрации перейдите по ссылке " +
                            "yana.russia.webmatrixhosting.net/activate.aspx?login=" + login;
                SmtpMail.SmtpServer = "localhost";
                SmtpMail.Send(oMsg);
//               catch (Exception Ex) { } 

                Response.Redirect("activate.aspx");
/*                Session.Add("IsLogged", true);
                Session.Add("user", "user");
                Session.Add("name", login);
                Response.Redirect("default.aspx");
  */          }
    }
}
