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
    public partial class issue_book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void b_click(object sender, EventArgs e)
        {
            int email=0, book_id=0,qty=0;
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "select count(*) from member WHERE email=@email";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", tb_member_email_id.Text);
            try
            {
                con.Open();
                int exist =(int) cmd.ExecuteScalar();
                if (exist > 0)
                {
                   email = 1;
                    query = "select count(*) from books where book_id=@id";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", tb_book_id.Text);
                    exist = (int)cmd.ExecuteScalar();
                    if (exist > 0)
                    { book_id = 1; }
                    else
                        status.Text = "book_id is invalid";
                }
                else
                    status.Text = "Invalid email ID";
                if (email == 1 && book_id == 1)
                {
                    query = "select count(*) from books where book_id=@id AND total_qty>0";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", tb_book_id.Text);
                    qty = (int)cmd.ExecuteScalar();
                    if (qty > 0)
                    { qty = 1; status.Text = "Quantity is available"; }
                    else
                        status.Text = "Quantity is not available";
                }
                if (email == 1 && book_id == 1 && qty==1)
                {
                    query = "select count(*) from status where book_id=@id AND email=@email AND actual_date_of_return IS NULL";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", tb_book_id.Text);
                    cmd.Parameters.AddWithValue("@email", tb_member_email_id.Text);
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)//book is not issued already
                    {
                        query = "select count(*) from status where email=@email AND actual_date_of_return IS NULL";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@email", tb_member_email_id.Text);
                        count = (int)cmd.ExecuteScalar();
                        if (count == 3)
                            status1.Text = "already issued 3 books";
                        else
                        {
                            query = "insert into status (email,book_id) VALUES(@email,@id)";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@email", tb_member_email_id.Text);
                            cmd.Parameters.AddWithValue("@id", tb_book_id.Text);
                            int x = cmd.ExecuteNonQuery();
                            status.Text = "Inserted";
                            query = "UPDATE [dbo].[books] SET total_qty=total_qty-1 WHERE book_id=@id";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@id", tb_book_id.Text);
                            x = cmd.ExecuteNonQuery();
                        }
                    }
                    else
                        status1.Text = "Can't be issued";
                }  
               
            }
            catch(Exception err)
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