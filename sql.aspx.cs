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
        SqlConnection Connection = new SqlConnection("Data Source=sql04.corp.parking.ru,1435;Initial Catalog=user-3;User ID=user-3;Password=0KfcYUFGf3");
        Connection.Open();
        SqlCommand Command = new SqlCommand();
        Command.Connection = Connection;
        Command.CommandText = "CREATE TABLE [dbo].[users] ("+
	"[id] [int] IDENTITY (1, 1) NOT NULL ,"+
	"[login] [varchar] (50) COLLATE Cyrillic_General_CI_AS NOT NULL,"+
	"[pass] [varchar] (10) NOT NULL,"+
	"[isAdmin] [int]"+
	"[email] [varchar] (50) NOT NULL,"+
	"[active] [int]"+
	") ON [PRIMARY];");

        Command.ExecuteScalar();
        Page.Response.Write("Таблица users создана!");
		
        Command = new SqlCommand();
        Command.Connection = Connection;
        Command.CommandText = "CREATE TABLE [dbo].[news] ("+
	"[id] [int] IDENTITY (1, 1) NOT NULL ,"+
	"[author] [int] NOT NULL ,"+
	"[text] [varchar] (500) COLLATE Cyrillic_General_CI_AS NOT NULL ,"+
	"[date] [datetime] NOT NULL ,"+
	"[isChecked] [int] NOT NULL "+
	") ON [PRIMARY]");

        Command.ExecuteScalar();
        Page.Response.Write("Таблица news создана!");
   		
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
