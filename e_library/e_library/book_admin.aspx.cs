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
            if (Session["admin"] == null)
            {
                Response.Redirect("~/login_Admin.aspx?msg=Please Log in");
            }
            countbook();
            

        }
        protected void badd_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Add_book.aspx");
        }
        protected void countbook()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select count(*) from [dbo].[books] where delete_status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                int x = (int)cmd.ExecuteScalar();
                bcount.Text = "Blocked: " + x;
                query = "select count(*) from [dbo].[books] where delete_status=0";
                cmd = new SqlCommand(query, con);
                x = (int)cmd.ExecuteScalar();
                ubcount.Text = "Unblocked: " + x;
                query = "select count(*) from [dbo].[books] ";
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
        protected void book_available(object sender, EventArgs e)
        {
            bookgridviewadmin.Visible = true;
            currentissue.Visible = false;
            search.Visible = true;
            l_search.Visible = false;
            bookgridviewadmin.Columns[16].Visible = false;
            bookgridviewadmin.Columns[14].Visible = true;
            bookgridviewadmin.Columns[15].Visible = true;
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
        protected void block_click(object sender, EventArgs e)
        {

            l_search.Visible = false;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label l = (Label)gvr.Cells[0].FindControl("l_book_id");
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[books] SET delete_status=1 where book_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l.Text);
                int y = cmd.ExecuteNonQuery();
                Label l1 = (Label)gvr.Cells[16].FindControl("l1");
                l1.Visible = true;
                Button b = (Button)gvr.Cells[16].FindControl("block");
                b.Visible = false;
                countbook();
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
        protected void book_archived(object sender, EventArgs e)
        {
            currentissue.Visible = false;
            search.Visible = true;
            l_search.Visible = false;
            bookgridviewadmin.Visible = true;
            bookgridviewadmin.Columns[16].Visible = true;
            bookgridviewadmin.Columns[14].Visible = false;
            bookgridviewadmin.Columns[15].Visible = false;
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
            Label l1 = (Label)gvr.Cells[0].FindControl("l_book_id");
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "Update [dbo].[books] SET delete_status=0 where book_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l1.Text);

                int x = cmd.ExecuteNonQuery();

                Label l = (Label)gvr.Cells[16].FindControl("l");
                l.Visible = true;
                Button b = (Button)gvr.Cells[16].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[16].FindControl("fdelete");
                b.Visible = false;
                query = "select count(*) from [dbo].[books] where delete_status=1";
                cmd = new SqlCommand(query, con);
                x = (int)cmd.ExecuteScalar();
                bcount.Text = "Blocked: " + x;

                countbook();
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
            bookgridviewadmin.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label l1 = (Label)gvr.Cells[0].FindControl("l_book_id");
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {

                con.Open();
                string query = "DELETE from [dbo].[books] where book_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l1.Text);
                cmd.ExecuteNonQuery();
                Label l = (Label)gvr.Cells[15].FindControl("l");
                l.Text = "Deleted";
                l.Visible = true;
                Button b = (Button)gvr.Cells[15].FindControl("unblock");
                b.Visible = false;
                b = (Button)gvr.Cells[15].FindControl("fdelete");
                b.Visible = false;
                query = "select count(*) from [dbo].[books] where delete_status=0";
                cmd = new SqlCommand(query, con);
                int x = (int)cmd.ExecuteScalar();
                bcount.Text = "Blocked: " + x;
                countbook();
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
        protected void b_Search(object sender, EventArgs e)
        {
            int f = 0;
            string query = null;
            if (dd_search.SelectedItem.Text == "Book ID")
            {
                query = " select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue AND book_id=@value";
                f = 1;
            }
            else if (dd_search.SelectedItem.Text == "Book Name")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue AND book_name LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Author Name")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue AND author_name LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Section Name")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue AND section_name LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Publisher Name")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue AND pub_name LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Description")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue AND description LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Language")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] WHERE  delete_status=@svalue AND language LIKE '%'+ @value + '%'";
                f = 0;

            }
            else if (dd_search.SelectedItem.Text == "Publisher Year")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue AND pub_year=@value";
                f = 1;
            }
            else if (dd_search.SelectedItem.Text == "Edition")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue AND Edition=@value";
                f = 1;
            }

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);

            try
            {

                con.Open();

                if (tb_search.Text.Length == 0)
                {

                    query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=@svalue";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                if (f == 0 && tb_search.Text.Length != 0)
                    cmd.Parameters.AddWithValue("@value", tb_search.Text.ToLower());
                else
                    cmd.Parameters.AddWithValue("@value", tb_search.Text);
                if (bookgridviewadmin.Columns[16].Visible == false)
                    cmd.Parameters.AddWithValue("@svalue", 0);
                else
                    cmd.Parameters.AddWithValue("@svalue", 1);
                bookgridviewadmin.DataSource = cmd.ExecuteReader();
                bookgridviewadmin.DataBind();
                bookgridviewadmin.Visible = true;

            }
            catch (Exception err)
            {
                l_search.Visible = true;
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
        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            bookgridviewadmin.EditIndex = -1;
            object o = null;
            book_available(o, e);
        }
        protected void EditBook(object sender, GridViewEditEventArgs e)
        {
            bookgridviewadmin.EditIndex = e.NewEditIndex;
            object o = null;
            book_available(o, e);
        }
        protected void UpdateBook(object sender, GridViewUpdateEventArgs e)
        {
            string BookID = ((Label)bookgridviewadmin.Rows[e.RowIndex].FindControl("l_book_id")).Text;
            string Edition = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_Edition")).Text;
            string bookName = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_book_name")).Text;
            string author_name = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_author_name")).Text;
            string Section = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_section_name")).Text;
            string Description = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_description")).Text;
            string pages = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_length")).Text;
            string Language = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_language")).Text;
            string pub_year = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_pub_year")).Text;
            string pub_name = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_pub_name")).Text;
            string seller_name = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_seller_name")).Text;
            string Price = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_mrp")).Text;
            string Quantity = ((TextBox)bookgridviewadmin.Rows[e.RowIndex].FindControl("txt_total_qty")).Text;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "Update [dbo].[books] SET author_name=@author_name,section_name=@section_name,seller_name=@seller_name,book_name=@book_name,description=@description,language=@language,total_qty=@total_qty,mrp=@mrp,pub_year=@pub_year,pub_name=@pub_name,@Edition=@edition,length=@length where book_id=@id";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@edition", Edition);
            cmd.Parameters.AddWithValue("@id", BookID);
            cmd.Parameters.AddWithValue("@author_name", author_name);
            cmd.Parameters.AddWithValue("@section_name", Section);
            cmd.Parameters.AddWithValue("@seller_name", seller_name);
            cmd.Parameters.AddWithValue("@book_name", bookName);
            cmd.Parameters.AddWithValue("@description", Description);
            cmd.Parameters.AddWithValue("@language", Language);
            cmd.Parameters.AddWithValue("@total_qty", Quantity);
            cmd.Parameters.AddWithValue("@mrp", Price);
            cmd.Parameters.AddWithValue("@pub_year", pub_year);
            cmd.Parameters.AddWithValue("@pub_name", pub_name);
            cmd.Parameters.AddWithValue("@length", pages);
     cmd.ExecuteNonQuery();
            con.Close();
            bookgridviewadmin.EditIndex = -1;
            object o = null;
            book_available(o, e);

        }
        protected void status_click(object sender,EventArgs e)
        {
            search.Visible = false;
            count.Visible = false;
           
            bookgridviewadmin.Visible = false;

            homegridview.Visible = true;
            currentissue.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label l = (Label)gvr.Cells[0].FindControl("l_book_id");
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select count(*) from [dbo].[status] where book_id=@id AND actual_date_of_return IS  NULL";
                 SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l.Text);
                int c = (int)cmd.ExecuteScalar();
                c_count.Visible = true;
                c_count.Text = "Currently issued:"+c.ToString();
                query = "select email ,date_of_issue,date_of_return from [dbo].[status] where book_id=@id AND actual_date_of_return IS  NULL";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id",l.Text);
                homegridview.DataSource = cmd.ExecuteReader();
                homegridview.DataBind();

            }
            catch (Exception err)
            {
                c_count.Visible = true;
                c_count.Text = err.Message;
            }
            finally
            {
                con.Close();
            }

        }
        protected void home_Click(object sender,EventArgs e)
        {
            Response.Redirect("~/HomeAdmin.aspx");
        }
    }
}