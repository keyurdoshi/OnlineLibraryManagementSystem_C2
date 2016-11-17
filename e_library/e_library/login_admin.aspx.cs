using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace e_library
{
    public partial class login_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            status.Text = Request.QueryString["msg"];
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            if (tb_email.Text == "kdoshi96@gmail.com" && tb_pwd.Text == "150796")
            {
                Session["admin"] = tb_email.Text;
                Response.Redirect("~/HomeAdmin.aspx");
            }
            else if (tb_email.Text == "akashdesai2010@yahoo.in" && tb_pwd.Text == "061195")
            {
                Session["admin"] = tb_email.Text;
                Response.Redirect("~/HomeAdmin.aspx");
            }
            else
                status.Text = "Invalid Email-ID/Password";

            }
    }
}