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
                l.Text = Session["user"].ToString();

            }
        }
        protected void book_click(object sender, EventArgs e)
        {
            history.Visible = false;
            warning.Visible = false;
            Current.Visible = false;
            historygridview.Visible = false;
            homegridview.Visible = false;
            bookgridview.Visible = true;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name from [dbo].[books]";
                SqlCommand cmd = new SqlCommand(query, con);
                bookgridview.DataSource = cmd.ExecuteReader() ;
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
        protected void bookdetail_click(object sender,EventArgs e)
        {
            history.Visible = false;
            warning.Visible = false;
            Current.Visible = false;
            historygridview.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = false;
            bookdetailview.Visible = true;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,language,description,length,Edition from [dbo].[books] where book_id=@id";
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
        
     
        protected void issue_click(Object sender,EventArgs e)
        {
            
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            //it will get value of the first column in a selected row
            //label with id status is defined above the button which will display contain of first column

            //find the control with id "tb" and store it as Textbox
            //here id "tb" is defined in template..<asp:texbox id="tb"/>

            //label with id temp will display the value which is in the textbox
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select count(*) from status where book_id=@id AND email=@email AND actual_date_of_return IS NULL";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
            cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
            int count = (int)cmd.ExecuteScalar();
            if (count == 0)//book is not issued already
            {
                query = "select count(*) from status where email=@email AND actual_date_of_return IS NULL";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                count = (int)cmd.ExecuteScalar();
                if (count == 3)
                    status.Text = "already issued 3 books";
                else
                {
                    query = "insert into status (email,book_id,book_name,author_name) VALUES(@email,@id,@name,@authorname)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                    cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                    cmd.Parameters.AddWithValue("@name", (string)gvr.Cells[1].Text);
                        cmd.Parameters.AddWithValue("@authorname", (string)gvr.Cells[2].Text);
                    int x = cmd.ExecuteNonQuery();
                    status.Text = "Inserted";
                    query = "UPDATE [dbo].[books] SET total_qty=total_qty-1 WHERE book_id=@id";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                    x = cmd.ExecuteNonQuery();
                }
            }
            else
                status.Text = "Can't be issued";
        
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
            history.Visible = true;
            warning.Visible = true;
            Current.Visible = true;
            historygridview.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = true;
            /*    string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
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
            }*/

        }
        protected void return_click(object sender,EventArgs e)
        {
            bookdetailview.Visible = false;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "update [dbo].[status] SET actual_date_of_return=GETDATE() where email=@email AND book_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", Session["user"].ToString());
                cmd.Parameters.AddWithValue("@id", (string)gvr.Cells[0].Text);
                cmd.ExecuteNonQuery();
                status.Text = "returned";

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
            bookgridview.Visible = false;
            homegridview.Visible = false;
            historygridview.Visible = false;

        }

        protected void faq_click(object sender, EventArgs e)
        {

            bookgridview.Visible = false;
            homegridview.Visible = false;
            historygridview.Visible = false;
        }

        protected void warning_click(object sender, EventArgs e)
        {
            historygridview.Visible = false;
            bookgridview.Visible = false;
            homegridview.Visible = false;
            history.Visible = true;
            warning.Visible = true;
            Current.Visible = true;

           
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
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
            history.Visible = true;
            warning.Visible = true;
            Current.Visible = true;
            historygridview.Visible =true;
            bookgridview.Visible = false;
            homegridview.Visible = false;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                string query = "select book_id,book_name,author_name,date_of_issue,actual_date_of_return from [dbo].[status] where email=@email";
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

            bookgridview.Visible = false;
            homegridview.Visible = true;
            history.Visible = true;
            warning.Visible = true;
            Current.Visible = true;

            bookgridview.Visible = false;
            homegridview.Visible = true;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
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
    }
}