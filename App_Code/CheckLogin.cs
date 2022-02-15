using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for CheckLogin
/// </summary>
public class CheckLogin
{
	public CheckLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool Check(string SubjectString)
    {
        return Regex.IsMatch(SubjectString, "\\A\\w[\\w _]*\\z");
    }
    public static bool CheckPass(string SubjectString)
    {
        return Regex.IsMatch(SubjectString,"^([-a-z0-9_\\.]+)@([-a-z0-9_\\.]+)$");
    }
}
