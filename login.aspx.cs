using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Visible = false;
        if (NumberField.Value == "")
        {
            LoginTextBox.Focus();
            NumberField.Value = FormsAuthentication.HashPasswordForStoringInConfigFile(DateTime.Now.ToString(), "md5").ToLower();

            string scriptString = "var pass = document.getElementById('PassTextBox').value;";
            scriptString += "pass = hex_md5(pass);";
            scriptString += "var number = document.getElementById('NumberField').value;";
            scriptString += "if (document.getElementById('PassTextBox').value != '') document.getElementById('PassTextBox').value = hex_md5(pass + number);";
            RegisterOnSubmitStatement("submit", scriptString);
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (!CheckLogin.Check(LoginTextBox.Text))
            return;

       SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=YanaSedova-3;User ID=YanaSedova-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
        Connection.Open();

        SqlCommand Command = new SqlCommand("SELECT pass,isAdmin,active FROM users WHERE login = '" + LoginTextBox.Text + "'", Connection);
        SqlDataReader Reader = Command.ExecuteReader();

        if (Reader.HasRows)
        {
            Reader.Read();
            if (Reader.GetString(2).ToString() == "0")
                Response.Redirect("activate.aspx");
            string ServerMD5 = FormsAuthentication.HashPasswordForStoringInConfigFile(Reader.GetString(0).ToLower() + NumberField.Value, "md5").ToLower();
            if (PassTextBox.Text == ServerMD5)
            {
                NumberField.Value = "";
                Session.Add("IsLogged", true);
                if (Reader.GetString(1) == "0")
                    Session.Add("user", "user");
                else
                    Session.Add("user", "admin");
                Session.Add("name", LoginTextBox.Text);
                Response.Redirect("default.aspx");
            }
        }
        else
        {
            Label3.Text = "Пользователь не найден";
            Label3.Visible = true;
        }
    }
    protected void RegButton_Click(object sender, EventArgs e)
    {
    }
    protected void NumberField_ValueChanged(object sender, EventArgs e)
    {

    }
}
