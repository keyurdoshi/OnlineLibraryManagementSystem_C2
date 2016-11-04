using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace e_library
{
    public partial class book_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void book_available(object sender, EventArgs e)
        {
            bookgridviewadmin.Columns[14].Visible = false;

            bookgridviewadmin.Columns[13].Visible = true;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0";
                SqlCommand cmd = new SqlCommand(query, con);
                bookgridviewadmin.DataSource = cmd.ExecuteReader();
                bookgridviewadmin.DataBind();

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
        protected void block_click(object sender,EventArgs e)
        {
            
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[books] SET delete_status=1 where book_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                int y = cmd.ExecuteNonQuery();
                Label l1 = (Label)gvr.Cells[14].FindControl("l1");
                l1.Visible = true;
                Button b = (Button)gvr.Cells[14].FindControl("block");
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
     /*   void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Button b = (Button)e.Row.FindControl("undo");
            b.Visible = true;
        }*/

        protected void book_archived(object sender, EventArgs e)
        {
            bookgridviewadmin.Visible = true;
            bookgridviewadmin.Columns[14].Visible = true;
            bookgridviewadmin.Columns[13].Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                bookgridviewadmin.DataSource = cmd.ExecuteReader();
                bookgridviewadmin.DataBind();

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
                string query = "Update [dbo].[books] SET delete_status=0 where book_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
               
                int x = cmd.ExecuteNonQuery();
              
                Label l = (Label)gvr.Cells[14].FindControl("l");
                l.Visible = true;
                Button b = (Button)gvr.Cells[14].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[14].FindControl("fdelete");
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
        protected void fdelete_click(object sender,EventArgs e)
        {
            bookgridviewadmin.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
               
                con.Open();
                string query = "DELETE from [dbo].[books] where book_name=@name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", (string)gvr.Cells[1].Text);
                cmd.ExecuteNonQuery();
                Label l = (Label)gvr.Cells[14].FindControl("l");
                l.Text = "Deleted";
                l.Visible = true;
                Button b = (Button)gvr.Cells[14].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[14].FindControl("fdelete");
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