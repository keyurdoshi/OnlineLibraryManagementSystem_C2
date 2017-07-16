using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace e_library
{
    public partial class publisher_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/login_Admin.aspx?msg=Please Log in");
            }
            publishergridviewadmin.Visible = true;
            countpublisher();
        }
        public void padd_click(object sender,EventArgs e)
        {
            Response.Redirect("~/Add_pub.aspx");
        }
        public void b_Search(object sender,EventArgs e)
        { int f = 0;
            l_search.Visible = false;
            string query = null;
            if(dd_search.SelectedItem.Text== "Publisher Id")
            {
                query = "select pub_id,pub_name,city,email,address,phone_no from [dbo].[publisher] where delete_status=@svalue AND pub_id=@value";
                f = 1;
            }
            if(dd_search.SelectedItem.Text == "Publisher Name")
            {
                query = "select pub_id,pub_name,city,email,address,phone_no from [dbo].[publisher] where delete_status=@svalue AND pub_name LIKE '%' + @value +'%'";
                f = 0;  
            }
            else if(dd_search.SelectedItem.Text=="City")
            {
                query = "select pub_id,pub_name,city,email,address,phone_no from [dbo].[publisher] where delete_status=@svalue AND city LIKE '%' + @value + '%'";
                f = 0;
            }
            else if(dd_search.SelectedItem.Text=="Address")
            {
                query = "select pub_id,pub_name,city,email,address,phone_no from [dbo].[publisher] where delete_status=@svalue AND address LIKE '%' + @value + '%'";
                f = 0;

            }
            else if(dd_search.SelectedItem.Text=="Email")
            {
                query = "select pub_id,pub_name,city,email,address,phone_no from [dbo].[publisher] where delete_status=@svalue AND email LIKE '%' + @value + '%'";
                f = 0;

            }
            else if(dd_search.SelectedItem.Text=="Phone No")
            {
                query = "select pub_id,pub_name,city,email,address,phone_no from [dbo].[publisher] where delete_status=@svalue AND phone_no LIKE '%' + @value + '%'";
                f = 1;
            }
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);

            try
            {

                con.Open();
               
                   if (tb_search.Text.Length == 0)
                  {

                    query = "select pub_id,pub_name,city,email,address,phone_no from [dbo].[publisher] where delete_status=@svalue";
                    }
                SqlCommand cmd = new SqlCommand(query, con);
               if (f == 0 && tb_search.Text.Length != 0)
                    cmd.Parameters.AddWithValue("@value", tb_search.Text.ToLower());
                else
                    cmd.Parameters.AddWithValue("@value", tb_search.Text);
                if (publishergridviewadmin.Columns[8].Visible == false)
                   cmd.Parameters.AddWithValue("@svalue", 0);
                else
                    cmd.Parameters.AddWithValue("@svalue", 1);
                publishergridviewadmin.DataSource = cmd.ExecuteReader();
                publishergridviewadmin.DataBind();

            }
            catch (Exception err)
            {
                l_search.Visible = true;
                l_search.Text ="Invalid Search";
               
            }
            finally
            {
                con.Close();
            }


        }
        protected void countpublisher()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select count(*) from [dbo].[publisher] where delete_status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                int x = (int)cmd.ExecuteScalar();
                bcount.Text = "Blocked: " + x;
                query = "select count(*) from [dbo].[publisher] where delete_status=0";
                cmd = new SqlCommand(query, con);
                x = (int)cmd.ExecuteScalar();
                ubcount.Text = "Unblocked: " + x;
                query = "select count(*) from [dbo].[publisher] ";
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
        protected void publisher_available(object sender,EventArgs e)
        {
            l_search.Visible = false;
            search.Visible = true;
            publishergridviewadmin.Columns[8].Visible = false;
            publishergridviewadmin.Columns[6].Visible = true;
            publishergridviewadmin.Columns[7].Visible = true;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
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
            l_search.Visible = false;
            search.Visible = true;
            publishergridviewadmin.Columns[8].Visible = true;
            publishergridviewadmin.Columns[6].Visible = false;
            publishergridviewadmin.Columns[7].Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
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
            Label l = (Label)gvr.Cells[0].FindControl("lbl_id");
            // string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[publisher] SET delete_status=1 where pub_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l.Text);
                int y = cmd.ExecuteNonQuery();
                Label l1 = (Label)gvr.Cells[7].FindControl("l1");
                l1.Visible = true;
                Button b = (Button)gvr.Cells[7].FindControl("block");
                b.Visible = false;
                countpublisher();
            }
            catch (Exception err)
            {
                status.Text = err.Message;
            }
            finally
            {
                con.Close();
            }
            countpublisher();

        }
        protected void unblock_click(Object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label l1 = (Label)gvr.Cells[0].FindControl("lbl_id");
            //  string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[publisher] SET delete_status=0 where pub_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l1.Text);

                int x = cmd.ExecuteNonQuery();

                Label l = (Label)gvr.Cells[6].FindControl("l");
                l.Visible = true;
                Button b = (Button)gvr.Cells[6].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[6].FindControl("fdelete");
                b.Visible = false;
        
                countpublisher();

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
            Label l1 = (Label)gvr.Cells[0].FindControl("lbl_id");
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {

                con.Open();
                string query = "DELETE from [dbo].[publisher] where pub_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l1.Text);
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
            countpublisher();
        }
        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            publishergridviewadmin.EditIndex = e.NewEditIndex;
            object o = null;
            publisher_available(o, e);
        }
        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            Label publisher_id = (Label)publishergridviewadmin.Rows[e.RowIndex].FindControl("lbl_id");

            TextBox city = (TextBox)publishergridviewadmin.Rows[e.RowIndex].FindControl("txt_city");
            TextBox email = (TextBox)publishergridviewadmin.Rows[e.RowIndex].FindControl("txt_email");
            TextBox address = (TextBox)publishergridviewadmin.Rows[e.RowIndex].FindControl("txt_address");
            TextBox phone_no = (TextBox)publishergridviewadmin.Rows[e.RowIndex].FindControl("txt_phn");
            con.Open();
            SqlCommand cmd = new SqlCommand("update [dbo].[publisher] set  city=@city, email=@email, address=@address, phone_no=@phone_no where pub_id=@publisher1_id", con);
            cmd.Parameters.AddWithValue("@publisher_id", publisher_id.Text);

            cmd.Parameters.AddWithValue("@city", city.Text);
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@address", address.Text);
            cmd.Parameters.AddWithValue("@phone_no", phone_no.Text);
            cmd.Parameters.AddWithValue("@publisher1_id", publisher_id.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            // lblmsg.Text = seller_id + "        Updated successfully........    ";
            publishergridviewadmin.EditIndex = -1;
            object o = null;
            publisher_available(o, e);
        }
        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            publishergridviewadmin.EditIndex = -1;
            object o = null;
            publisher_available(o, e);
        }
        protected void signout_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login_admin.aspx?msg=Logged out");

        }
    }
}