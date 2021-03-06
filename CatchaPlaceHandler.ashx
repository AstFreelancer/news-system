<%@ WebHandler Language="C#" Class="CatchaPlaceHandler" %>

using System;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;

public class CatchaPlaceHandler : IHttpHandler 
{
    
    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.BufferOutput = false;
        
        // Get text
        string s = "null";
        if (context.Request.QueryString["c"] != null &&
            context.Request.QueryString["c"] != "")
        {
            s = context.Request.QueryString["c"].ToString();
        }
        // Get dimensions
        int w = 120;
        int h = 50;
        // Width
        if (context.Request.QueryString["w"] != null &&
            context.Request.QueryString["w"] != "")
        {
            try
            {
                w = Convert.ToInt32(context.Request.QueryString["w"]);
            }
            catch { }
        }
        // Height
        if (context.Request.QueryString["h"] != null &&
            context.Request.QueryString["h"] != "")
        {
            try
            {
                h = Convert.ToInt32(context.Request.QueryString["h"]);
            }
            catch { }
        }
        // Color
        Color Bc = Color.White;
        if (context.Request.QueryString["bc"] != null &&
            context.Request.QueryString["bc"] != "")
        {
            try
            {
                string bc = context.Request.QueryString["bc"].ToString().Insert(0, "#");
                Bc = ColorTranslator.FromHtml(bc);
            }
            catch { }
        }
        // Generate image
        CaptchaImage ci = new CaptchaImage(s, Bc, w, h);
        
        // Return
        ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        // Dispose
        ci.Dispose();
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}