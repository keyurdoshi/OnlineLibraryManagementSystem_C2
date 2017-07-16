using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace e_library
{
    public partial class member_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["admin"]==null)
            {
                Response.Redirect("~/login_Admin.aspx?msg=Please Log in");
            }
            countuser();
        }
        protected void b_Search(object sender, EventArgs e)
        {
            count.Visible = true;

            l_search.Visible = false;
            membergridviewadmin.Visible =true;
            usergridviewadmin.Visible = false;
            bookdetailview.Visible = false;
            int f = 0;
            string query = null;
            if (dd_search.SelectedItem.Text == "Member ID")
            {
                query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=@svalue AND  member_id=@value";
                f = 1;
            }
            else if (dd_search.SelectedItem.Text == "Member Name")
            {
                query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=@svalue AND  member_name LIKE '%' + @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Email")
            {
                query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=@svalue AND  email LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Category")
            {
                query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=@svalue AND  category LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Branch")
            {
                query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=@svalue AND  branch LIKE '%' + @value +'%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Contact No")
            {
                query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=@svalue AND  phone_no LIKE '%' + @value +'%'";
                f = 1;
            }
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);

            try
            {

                con.Open();

                if (tb_search.Text.Length == 0)
                {

                    query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=@svalue";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                if (f == 0 && tb_search.Text.Length != 0)
                    cmd.Parameters.AddWithValue("@value", tb_search.Text.ToLower());
                else
                    cmd.Parameters.AddWithValue("@value", tb_search.Text);
                if (membergridviewadmin.Columns[9].Visible == false)
                    cmd.Parameters.AddWithValue("@svalue", 0);
                else
                    cmd.Parameters.AddWithValue("@svalue", 1);
                membergridviewadmin.DataSource = cmd.ExecuteReader();
                membergridviewadmin.DataBind();
            }
            catch (Exception err)
            {
                l_search.Visible = true;
                l_search.Text = "Invalid Search";
            }
            finally
            {
                con.Close();
            }


        }
        protected void user_click(object sender,EventArgs e)
        {
            l_search.Visible = false;
            search.Visible = false;

            count.Visible = false;
            membergridviewadmin.Visible = false;
            usergridviewadmin.Visible = true;
            bookdetailview.Visible = true;  
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,date_of_issue,actual_date_of_return from [dbo].[status] where email=@email ORDER BY actual_date_of_return ASC";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email",gvr.Cells[2].Text );
                usergridviewadmin.DataSource = cmd.ExecuteReader();
                usergridviewadmin.DataBind();

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
        protected void countuser()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select count(*) from [dbo].[member] where delete_status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                int x = (int)cmd.ExecuteScalar();
                bcount.Text = "Blocked: " + x;
                query = "select count(*) from [dbo].[member] where delete_status=0";
                cmd = new SqlCommand(query, con);
                x = (int)cmd.ExecuteScalar();
                ubcount.Text = "Unblocked: " + x;
                query = "select count(*) from [dbo].[member] ";
                cmd = new SqlCommand(query, con);
                x = (int)cmd.ExecuteScalar();
                tcount.Text = "Total: " + x;

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
        protected void bookdetail_click(object sender,EventArgs e)
        {
            count.Visible = false;
            search.Visible = false;
            l_search.Visible = false;
            membergridviewadmin.Visible = false;
            usergridviewadmin.Visible = false;
            bookdetailview.Visible = true;

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,language,description,length,Edition,pub_year,pub_name from [dbo].[books]  where book_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);


                bookdetailview.DataSource = cmd.ExecuteReader();
                bookdetailview.DataBind();

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
        protected void member_available(object sender, EventArgs e)
        {
            count.Visible = true;
            search.Visible = true;
            l_search.Visible = false;
            
            membergridviewadmin.Visible = true;
            usergridviewadmin.Visible = false;
            bookdetailview.Visible = false;

            membergridviewadmin.Columns[9].Visible = false;

            membergridviewadmin.Columns[8].Visible = true;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=0";
                SqlCommand cmd = new SqlCommand(query, con);
                membergridviewadmin.DataSource = cmd.ExecuteReader();
                membergridviewadmin.DataBind();

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
        protected void member_archived(object sender, EventArgs e)
        {
            count.Visible = true;
            search.Visible = true;
            l_search.Visible = false;
            membergridviewadmin.Columns[9].Visible = true;
            membergridviewadmin.Columns[8].Visible = false;
            membergridviewadmin.Visible = true;
            usergridviewadmin.Visible = false;
            bookdetailview.Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select member_id,member_name,email,password,category,branch,phone_no from [dbo].[member] where delete_status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                membergridviewadmin.DataSource = cmd.ExecuteReader();
                membergridviewadmin.DataBind();

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
            count.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[member] SET delete_status=1 where member_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                int y = cmd.ExecuteNonQuery();
                Label l1 = (Label)gvr.Cells[9].FindControl("l1");
                l1.Visible = true;
                Button b = (Button)gvr.Cells[9].FindControl("block");
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
            countuser();
        }
        protected void unblock_click(Object sender, EventArgs e)
        {
            count.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[member] SET delete_status=0 where member_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);

                int x = cmd.ExecuteNonQuery();

                Label l = (Label)gvr.Cells[9].FindControl("l");
                l.Visible = true;
                Button b = (Button)gvr.Cells[9].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[9].FindControl("fdelete");
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
            countuser();
        }
        protected void fdelete_click(object sender, EventArgs e)
        {
            count.Visible = true; Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {

                con.Open();
                string query = "DELETE from [dbo].[member] where member_name=@name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", (string)gvr.Cells[1].Text);
                cmd.ExecuteNonQuery();
                Label l = (Label)gvr.Cells[9].FindControl("l");
                l.Text = "Deleted";
                l.Visible = true;
                Button b = (Button)gvr.Cells[9].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[9].FindControl("fdelete");
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
            countuser();
        }
        protected void signout_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login_admin.aspx?msg=Logged out");

        }
    }
}