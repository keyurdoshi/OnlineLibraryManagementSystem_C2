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

        }

        protected void book_click(object sender, EventArgs e)
        {
            Response.Redirect("~/book_admin.aspx");
        }

        protected void publisher_Click(object sender, EventArgs e)
        {

        }

        protected void seller_click(object sender, EventArgs e)
        {

        }

        protected void user_click(object sender, EventArgs e)
        {

        }

        protected void section_click(object sender, EventArgs e)
        {

        }
    }
}