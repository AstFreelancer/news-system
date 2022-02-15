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
public partial class activate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Page.Request["login"] == null)
        {
            Page.Response.Write("На указанный вами ящик отправлено письмо с просьбой о подтверждении. Перейдите по ссылке в этом письме для завершения регистрации.");
            return;
        }
        SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=YanaSedova-3;User ID=YanaSedova-3;Password=0KfcYUFGf3");
//        SqlConnection Connection = new SqlConnection("Data Source=(local);User ID=sa;Password=;database=asp");
        Connection.Open();
        SqlCommand Command = new SqlCommand();
        Command.Connection = Connection;
        Command.CommandText = "UPDATE users SET active=1 WHERE login='" + Page.Request["login"] + "'";

        Command.ExecuteScalar();
        Page.Response.Write("Учетная запись пользователя " + Page.Request["login"] + " активизирована");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
