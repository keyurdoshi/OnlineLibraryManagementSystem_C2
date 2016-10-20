using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace library
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                        status.Text = Request.QueryString["msg"]; 

        }
        protected void login_b_click(Object o,EventArgs e)
        {
            string constr= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\documents\visual studio 2015\Projects\library\library\App_Data\user.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "select * FROM member WHERE Email=@email AND Password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", email_tb.Text);
            cmd.Parameters.AddWithValue("@password", password_tb.Text);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == false)
                    status.Text = "Wrong";
                else
                {
                    Session["user"] = email_tb.Text;
                    Response.Redirect("Home.aspx");
                }
            }
            catch (Exception err)
            {
                status.Text = err.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}