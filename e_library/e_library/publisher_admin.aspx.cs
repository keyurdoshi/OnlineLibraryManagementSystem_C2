using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace e_library
{
    public partial class publisher_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void publisher_available(object sender, EventArgs e)
        {
            publishergridviewadmin.Columns[7].Visible = false;

            publishergridviewadmin.Columns[6].Visible = true;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select pub_id,pub_name,email,address,city,phone_no from [dbo].[publisher] where delete_status=0";
                SqlCommand cmd = new SqlCommand(query, con);
                publishergridviewadmin.DataSource = cmd.ExecuteReader();
                publishergridviewadmin.DataBind();

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
        protected void publisher_archived(object sender, EventArgs e)
        {
            publishergridviewadmin.Columns[7].Visible = true;

            publishergridviewadmin.Columns[6].Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select pub_id,pub_name,email,address,city,phone_no from [dbo].[publisher] where delete_status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                publishergridviewadmin.DataSource = cmd.ExecuteReader();
                publishergridviewadmin.DataBind();

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
        protected void block_click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[publisher] SET delete_status=1 where pub_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                int y = cmd.ExecuteNonQuery();
                Label l1 = (Label)gvr.Cells[7].FindControl("l1");
                l1.Visible = true;
                Button b = (Button)gvr.Cells[7].FindControl("block");
                b.Visible = false;

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
        protected void unblock_click(Object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[publisher] SET delete_status=0 where pub_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);

                int x = cmd.ExecuteNonQuery();

                Label l = (Label)gvr.Cells[7].FindControl("l");
                l.Visible = true;
                Button b = (Button)gvr.Cells[7].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[7].FindControl("fdelete");
                b.Visible = false;


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
        protected void fdelete_click(object sender, EventArgs e)
        {
            publishergridviewadmin.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {

                con.Open();
                string query = "DELETE from [dbo].[publisher] where pub_name=@name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", (string)gvr.Cells[1].Text);
                cmd.ExecuteNonQuery();
                Label l = (Label)gvr.Cells[7].FindControl("l");
                l.Text = "Deleted";
                l.Visible = true;
                Button b = (Button)gvr.Cells[7].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[7].FindControl("fdelete");
                b.Visible = false;
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