using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace e_library
{
    public partial class Seller_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/login_Admin.aspx?msg=Please Log in");
            }
            sellergridviewadmin.Visible = true;
            countseller();

        }
        protected void countseller()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select count(*) from [dbo].[seller] where delete_status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                int x = (int)cmd.ExecuteScalar();
                bcount.Text = "Blocked: " + x;
                query = "select count(*) from [dbo].[seller] where delete_status=0";
                cmd = new SqlCommand(query, con);
                x = (int)cmd.ExecuteScalar();
                ubcount.Text = "Unblocked: " + x;
                query = "select count(*) from [dbo].[seller] ";
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
        protected void sadd_click(object sender,EventArgs e)
        {
            Response.Redirect("~/Add_seller.aspx");
        }
        protected void seller_available(object sender, EventArgs e)
        {
            search.Visible = true;
            l_search.Visible = false;
            sellergridviewadmin.Columns[8].Visible = false;
            sellergridviewadmin.Columns[6].Visible = true;
            sellergridviewadmin.Columns[7].Visible = true;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select seller_id,seller_name,email,address,city,phone_no from [dbo].[seller] where delete_status=0";
                SqlCommand cmd = new SqlCommand(query, con);
                sellergridviewadmin.DataSource = cmd.ExecuteReader();
                sellergridviewadmin.DataBind();

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
        protected void seller_archived(object sender, EventArgs e)
        {
            search.Visible = true;
            l_search.Visible = false;
            sellergridviewadmin.Columns[8].Visible = true;
            sellergridviewadmin.Columns[6].Visible = false;
            sellergridviewadmin.Columns[7].Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select seller_id,seller_name,email,address,city,phone_no from [dbo].[seller] where delete_status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                sellergridviewadmin.DataSource = cmd.ExecuteReader();
                sellergridviewadmin.DataBind();

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
            Label l =(Label) gvr.Cells[0].FindControl("lbl_id");
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[seller] SET delete_status=1 where seller_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id",l.Text);
                int y = cmd.ExecuteNonQuery();
                Label l1 = (Label)gvr.Cells[8].FindControl("l1");
                l1.Visible = true;
                Button b = (Button)gvr.Cells[8].FindControl("block");
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
            countseller();
        }
        protected void unblock_click(Object sender, EventArgs e)
        {
           
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label l1 = (Label)gvr.Cells[0].FindControl("lbl_id");
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[seller] SET delete_status=0 where seller_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l1.Text);

                int x = cmd.ExecuteNonQuery();

                Label l = (Label)gvr.Cells[8].FindControl("l");
                l.Visible = true;
                Button b = (Button)gvr.Cells[8].FindControl("unblock");
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
            countseller();
        }
        protected void fdelete_click(object sender, EventArgs e)
        {
            sellergridviewadmin.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label l1 = (Label)gvr.Cells[0].FindControl("lbl_id");
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {

                con.Open();
                string query = "DELETE from [dbo].[seller] where seller_id=@id";
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
            countseller();
        }
        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            sellergridviewadmin.EditIndex = e.NewEditIndex;
            object o = null;
            seller_available(o, e);
        }
        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            Label seller_id = (Label)sellergridviewadmin.Rows[e.RowIndex].FindControl("lbl_id");
            
            TextBox city = (TextBox)sellergridviewadmin.Rows[e.RowIndex].FindControl("txt_city");
            TextBox email = (TextBox)sellergridviewadmin.Rows[e.RowIndex].FindControl("txt_email");
            TextBox address = (TextBox)sellergridviewadmin.Rows[e.RowIndex].FindControl("txt_address");
            TextBox phone_no = (TextBox)sellergridviewadmin.Rows[e.RowIndex].FindControl("txt_phn");
            con.Open();
            SqlCommand cmd = new SqlCommand("update seller set  city=@city, email=@email, address=@address, phone_no=@phone_no where seller_id=@seller_id", con);
            cmd.Parameters.AddWithValue("@seller_id", seller_id.Text);
           
            cmd.Parameters.AddWithValue("@city", city.Text);
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@address", address.Text);
            cmd.Parameters.AddWithValue("@phone_no", phone_no.Text);
            cmd.ExecuteNonQuery();
            con.Close();
           // lblmsg.Text = seller_id + "        Updated successfully........    ";
            sellergridviewadmin.EditIndex = -1;
            object o = null;
            seller_available(o, e);
        }
        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            sellergridviewadmin.EditIndex = -1;
            object o = null;
            seller_available(o, e);
        }
       protected void b_Search(object sender, EventArgs e)
        {
            l_search.Visible = false;
            int f = 0;
            string query = null;
            if (dd_search.SelectedItem.Text == "Seller Id")
            {
                query = "select seller_id,seller_name,city,email,address,phone_no from [dbo].[seller] where delete_status=@svalue AND seller_id=@value";
                f = 1;
            }
            if (dd_search.SelectedItem.Text == "Seller Name")
            {
                query = "select seller_id,seller_name,city,email,address,phone_no from [dbo].[seller] where delete_status=@svalue AND seller_name LIKE '%' + @value +'%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "City")
            {
                query = "select seller_id,seller_name,city,email,address,phone_no from [dbo].[seller] where delete_status=@svalue AND city LIKE '%' + @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Address")
            {
                query = "select seller_id,seller_name,city,email,address,phone_no from [dbo].[seller] where delete_status=@svalue AND address LIKE '%' + @value + '%'";
                f = 0;

            }
            else if (dd_search.SelectedItem.Text == "Email")
            {
                query = "select seller_id,seller_name,city,email,address,phone_no from [dbo].[seller] where delete_status=@svalue AND email LIKE '%' + @value + '%'";
                f = 0;

            }
            else if (dd_search.SelectedItem.Text == "Phone No")
            {
                query = "select seller_id,seller_name,city,email,address,phone_no from [dbo].[seller] where delete_status=@svalue AND phone_no LIKE '%' + @value + '%'";
                f = 1;

            }

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);

            try
            {

                con.Open();

                if (tb_search.Text.Length == 0)
                {

                    query = "select seller_id,seller_name,city,email,address,phone_no from [dbo].[seller] where delete_status=@svalue";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                if (f == 0 && tb_search.Text.Length != 0)
                    cmd.Parameters.AddWithValue("@value", tb_search.Text.ToLower());
                else
                    cmd.Parameters.AddWithValue("@value", tb_search.Text);
                if (sellergridviewadmin.Columns[8].Visible == false)
                    cmd.Parameters.AddWithValue("@svalue", 0);
                else
                    cmd.Parameters.AddWithValue("@svalue", 1);
                sellergridviewadmin.DataSource = cmd.ExecuteReader();
                sellergridviewadmin.DataBind();

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
        protected void signout_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login_admin.aspx?msg=Logged out");

        }

    }
}