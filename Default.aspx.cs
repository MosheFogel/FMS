using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           string a = Request.QueryString.Get(0);
           string b = Request.QueryString.Get(1);
           Label1.Text = b;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}