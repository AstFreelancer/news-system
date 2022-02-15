using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _hello : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["IsLogged"] == null) ||
           (Session["IsLogged"].ToString() == "false"))
            Response.Redirect("Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";

        if (Char.IsLetter(TextBox1.Text[0]))
            TextBox2.Text = TextBox2.Text + Char.ToUpper(TextBox1.Text[0]);
        else
            TextBox2.Text = TextBox2.Text + TextBox1.Text[0];

        char last = TextBox1.Text[0];
        for (int i = 1; i < TextBox1.Text.Length; i++)
        {
            if ((Char.IsWhiteSpace(last) || Char.IsPunctuation(last)) && last != '/')
            {
                if (Char.IsLetter(TextBox1.Text[i]))
                    TextBox2.Text = TextBox2.Text + Char.ToUpper(TextBox1.Text[i]);
                else
                    TextBox2.Text = TextBox2.Text + TextBox1.Text[i];
            }
            else
                TextBox2.Text = TextBox2.Text + TextBox1.Text[i];
            last = TextBox1.Text[i];
        }
    }
}
