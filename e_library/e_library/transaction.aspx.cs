using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace e_library
{
    public partial class transaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("~/login_admin.aspx?msg=Please log in");
        }
        protected void home_click(object sender,EventArgs e)
        {
            Response.Redirect("~/HomeAdmin.aspx");
        }

        protected void signout_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login_admin.aspx?msg=Logged out");

        }

        protected void search_click(object sender, EventArgs e)
        {

            status.Visible = false;


            homegridview.Visible = true;


            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                status.Text = clndr.SelectedDate.ToShortDateString();
                con.Open();
                string query = "select book_id,email,book_name,author_name,date_of_issue,date_of_return from [dbo].[status] where CONVERT(VARCHAR(10), date_of_issue, 105)=@date";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@date", clndr.SelectedDate.ToShortDateString());
                homegridview.DataSource = cmd.ExecuteReader();
                homegridview.DataBind();

            }
            catch (Exception err)
            {

                // status.Text = err.Message;
            }
            finally
            {
                con.Close();
            }


        }
    }
     
       
    }
