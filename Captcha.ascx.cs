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

public partial class Captcha : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetCaptcha();
    }

    public static string GetRandomColor()
    {
        string S = "0369CF";

        string res = "#";

        Random r = new Random();
        for (int i = 0; i < 3; i++)
        {
            int rn = r.Next(6);
            res += S[rn];
            res += S[rn];
        }

        return res;
    }
    public void SetCaptcha()
    {
        RandomString random = new RandomString();
        string s = random.GenerateRandomCode();

        Session["captcha"] = s;

        CaptchaImage.ImageUrl = "~/CatchaPlaceHandler.ashx?w=100&h=50&c=" + s + "&bc="+GetRandomColor();
    }

    public bool CheckCaptcha(string key)
    {
        if (Session["captcha"] != null && key == Session["captcha"].ToString())
        {
            return true;
        }
        else
        {
            SetCaptcha();
            return false;
        }
    }
}
