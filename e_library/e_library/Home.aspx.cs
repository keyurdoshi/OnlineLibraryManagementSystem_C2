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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (Session["user"] == null)
                Response.Redirect("~/Login_user.aspx?msg=Please log in");
            else
            {
                faq1.Visible = false;
                contact_us1.Visible = false;
                status.Visible = false;
                search.Visible = false;
                Current.Visible = false;
                warning.Visible = false;
                history.Visible = false;
                accountview.Visible = true;
                historygridview.Visible = false;
                homegridview.Visible = false;
                bookgridview.Visible = false;
                l.Text = Session["user"].ToString();

            }
        }
        protected void account_click(object sender,EventArgs e)
        {
            faq1.Visible = false;
            contact_us1.Visible = false;
            status.Visible = false;
            search.Visible = false;
            Current.Visible = false;
            warning.Visible = false;
            history.Visible = false;
            accountview.Visible = true;
            historygridview.Visible = false;
            homegridview.Visible = false;
            bookgridview.Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select member_id,member_name,email,branch,phone_no,category from [dbo].[member] where email=@email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email",Session["user"].ToString());
                accountview.DataSource = cmd.ExecuteReader();
                accountview.DataBind();
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
        protected void book_click(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            bookdetailview.Visible = false;
            status.Visible = false;
            faq1.Visible = false;
            contact_us1.Visible = false;
            search.Visible = true;
            accountview.Visible = false;
            Current.Visible = false;
            warning.Visible = false;
            history.Visible = false;
            historygridview.Visible = false;
            homegridview.Visible = false;
            bookgridview.Visible = true;
           
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,Edition from [dbo].[books] where delete_status=0";
                SqlCommand cmd = new SqlCommand(query, con);
                bookgridview.DataSource = cmd.ExecuteReader();
                bookgridview.DataBind();

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
        protected void bookdetail_click(object sender, EventArgs e)
        {
            faq1.Visible = false;
            contact_us1.Visible = false;
            status.Visible = false;
            search.Visible =false;
            accountview.Visible = false;
            Current.Visible = false;
            warning.Visible = false;
            history.Visible = false;
            historygridview.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = false;
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
                

               cmd.Parameters.AddWithValue("@id",(string)gvr.Cells[0].Text);
             
                
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
        protected void issue_click(Object sender, EventArgs e)
        {
            search.Visible = true;
            bookgridview.Visible = true;
            accountview.Visible = false;
            homegridview.Visible = false;
            Button btn = (Button)sender;


            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select count(*) from status where book_id=@id AND email=@email AND actual_date_of_return IS NULL";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    query = "select count(*) from status where email=@email AND actual_date_of_return IS NULL";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                    count = (int)cmd.ExecuteScalar();
                    if (count == 3)
                    {
                        status.Visible = true;

                        status.Text = "Already issued 3 books";
                    }
                    else
                    {
                        query = "insert into status (email,book_id,book_name,author_name) VALUES(@email,@id,@name,@authorname)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                        cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                        cmd.Parameters.AddWithValue("@name", (string)gvr.Cells[1].Text);
                        cmd.Parameters.AddWithValue("@authorname", (string)gvr.Cells[2].Text);
                        int x = cmd.ExecuteNonQuery();

                        query = "UPDATE [dbo].[books] SET total_qty=total_qty-1 WHERE book_id=@id";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                        x = cmd.ExecuteNonQuery();
                        Label label = (Label)gvr.Cells[10].FindControl("l");
                        label.Visible = true;
                        Button b = (Button)gvr.Cells[10].FindControl("issue");
                        b.Visible = false;
                    }
                }
                else
                { 
                    status.Visible = true;
                    status.Text = "Same book is already issued";
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
        protected void home_click(object sender, EventArgs e)
        {
            faq1.Visible = false;
            contact_us1.Visible = false;
            status.Visible = false;
            accountview.Visible = false;
            Current.Visible = true;
            warning.Visible = true;
            history.Visible = true;
            bookdetailview.Visible = false;
            search.Visible = false;
            historygridview.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = true;

        }
        protected void return_click(object sender, EventArgs e)
        {
            Current.Visible = true;
            warning.Visible = true;
            history.Visible = true;
            status.Visible = false;
            bookdetailview.Visible = false;
            accountview.Visible = false;
            homegridview.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "update [dbo].[status] SET actual_date_of_return=GETDATE() where email=@email AND book_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                cmd.ExecuteNonQuery();
                query = "UPDATE [dbo].[books] SET total_qty=total_qty+1 WHERE book_id=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                int x = cmd.ExecuteNonQuery();
                Label label1 = (Label)gvr.Cells[6].FindControl("l1");
                label1.Visible = true;
                Button b = (Button)gvr.Cells[6].FindControl("return");
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
        protected void contactus_click(object sender, EventArgs e)
        {
            status.Visible = false;
            accountview.Visible = false;
            search.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = false;
            historygridview.Visible = false;
            Current.Visible = false;
            warning.Visible = false;
            history.Visible = false;
            faq1.Visible = false;
            contact_us1.Visible = true;
        }
        protected void faq_click(object sender, EventArgs e)
        {
            status.Visible = false;
            accountview.Visible = false;
            search.Visible = false;
            Current.Visible = false;
            warning.Visible = false;
            history.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = false;
            historygridview.Visible = false;
            contact_us1.Visible = false;
            faq1.Visible = true;
        }
        protected void warning_click(object sender, EventArgs e)
        {
            faq1.Visible = false;
            contact_us1.Visible = false;
            status.Visible = false;
            search.Visible = false;
            accountview.Visible = false;
            historygridview.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = false;

            Current.Visible = true;
            warning.Visible = true;
            history.Visible = true;


            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,date_of_issue,date_of_return from [dbo].[status] where email=@email AND actual_date_of_return > GETDATE()";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                homegridview.DataSource = cmd.ExecuteReader();
                homegridview.DataBind();

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
        protected void history_click(object sender, EventArgs e)
        {
            faq1.Visible = false;
            contact_us1.Visible = false;
            search.Visible = false;;
            status.Visible = false;
            bookdetailview.Visible = false;
            accountview.Visible = false;
            Current.Visible = true;
            warning.Visible = true;
            history.Visible = true;
            historygridview.Visible = true;
            bookgridview.Visible = false;
            homegridview.Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,date_of_issue,actual_date_of_return from [dbo].[status] where email=@email AND actual_date_of_return IS NOT NULL ORDER BY actual_date_of_return DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                historygridview.DataSource = cmd.ExecuteReader();
                historygridview.DataBind();

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
        protected void current_Click(object sender, EventArgs e)
        {
            faq1.Visible = false;
            contact_us1.Visible = false;
            status.Visible = false;
            search.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = true;
            accountview.Visible = false;
            Current.Visible = true;
            warning.Visible = true;
            history.Visible = true;
            bookgridview.Visible = false;
            homegridview.Visible = true;
            historygridview.Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,date_of_issue,date_of_return from [dbo].[status] where email=@email AND actual_date_of_return IS NULL";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                homegridview.DataSource = cmd.ExecuteReader();
                homegridview.DataBind();

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
        protected void signout_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();

            Response.Redirect("~/Login_user.aspx?msg=Logged out");
        }
        protected void b_Search(object sender, EventArgs e)
        {   int f = 0;
            faq1.Visible = false;
            contact_us1.Visible = false;
            accountview.Visible = false;
            l_search.Visible = false;
            search.Visible = true;
            Current.Visible = false;
            warning.Visible = false;
            history.Visible = false;
            historygridview.Visible = false;
            homegridview.Visible = false;
            bookgridview.Visible = true;


            string query = null;
            if (dd_search.SelectedItem.Text == "Book ID")
            {
                query = " select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0 AND book_id=@value";
                f = 1;
            }
            else if (dd_search.SelectedItem.Text == "Book Name")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0 AND book_name LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Author Name")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0 AND author_name LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Section Name")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0 AND section_name LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Publisher Name")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0 AND pub_name LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Description")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0 AND description LIKE '%'+ @value + '%'";
                f = 0;
            }
            else if (dd_search.SelectedItem.Text == "Language")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,Edition from [dbo].[books] WHERE  delete_status=0 AND language LIKE '%'+ @value + '%'";
                f = 0;

            }
            else if (dd_search.SelectedItem.Text == "Publisher Year")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0 AND pub_yaer=@value";
                f = 1;
            }
            else if (dd_search.SelectedItem.Text == "Edition")
            {
                query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0 AND Edition=@value";
                f = 1;
            }

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);

            try
            {

                con.Open();

                if (tb_search.Text.Length == 0)
                {

                    query = "select book_id,book_name,author_name,section_name,description,length,language,pub_year,pub_name,seller_name,mrp,total_qty,Edition from [dbo].[books] where delete_status=0";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                if (f == 0 && tb_search.Text.Length != 0)
                    cmd.Parameters.AddWithValue("@value", tb_search.Text.ToLower());
                else
                    cmd.Parameters.AddWithValue("@value", tb_search.Text);
              
               bookgridview.DataSource = cmd.ExecuteReader();
                bookgridview.DataBind();

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
       
    }
}