using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("~/login.aspx?msg=Please log in");
        }
        protected void logout_b_click(Object e,EventArgs er)
        {
            Session.Abandon();
            Session.Clear();
         
            Response.Redirect("~/Login.aspx?msg=Logged out");

        }
    }
}