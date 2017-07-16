using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_library
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("~/login_admin.aspx?msg=Please log in");

        }
        protected void signout_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login_admin.aspx?msg=Logged out");
            
        }
        protected void trans_click(object sender,EventArgs e)
        {
            Response.Redirect("~/transaction.aspx");
        }
        protected void book_click(object sender, EventArgs e)
        {
            Response.Redirect("~/book_admin.aspx");
        }
        protected void publisher_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/publisher_admin.aspx");
        }
        protected void seller_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Seller_admin.aspx");
        }
        protected void user_click(object sender, EventArgs e)
        {
            Response.Redirect("~/member_admin.aspx");

        }

        protected void section_click(object sender, EventArgs e)
        {

        }

        protected void transaction_click(object sender, EventArgs e)
        {

        }
    }
}