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
    public partial class Add_book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void b_click(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "select count(*) from books where book_name=@name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", tb_book_name.Text.ToLower());
           
            try
            {
                con.Open();
                int exist = (int)cmd.ExecuteScalar();
                if (exist>0)
                {
                    status.Text = "Already exist";
                    
                }
                else
                {
                    query = "insert into [dbo].[books] (book_name,author_name,language,description,total_qty,mrp,pub_year,length,publisher_id,seller_id,section_id,Edition) VALUES(@book_name,@author_name,@language,@description,@qty,@mrp,@pub_year,@length,@pub_id,@seller_id,@section_id,@edition)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@book_name", tb_book_name.Text.ToLower());
                    cmd.Parameters.AddWithValue("@author_name", tb_author_name.Text.ToLower());
                    cmd.Parameters.AddWithValue("@language", tb_language.Text.ToLower());
                    cmd.Parameters.AddWithValue("@description", tb_description.Text.ToLower());
                    cmd.Parameters.AddWithValue("@qty", tb_quantity.Text);
                    cmd.Parameters.AddWithValue("@mrp", tb_mrp.Text);
                    cmd.Parameters.AddWithValue("@pub_year", tb_pub_year.Text);
                    cmd.Parameters.AddWithValue("@length", tb_noofpages.Text);
                    cmd.Parameters.AddWithValue("@pub_id", dd_publisher_name.SelectedValue);
                    cmd.Parameters.AddWithValue("@seller_id", dd_seller_name.SelectedValue);
                    cmd.Parameters.AddWithValue("@section_id", dd_section.SelectedValue);
                    cmd.Parameters.AddWithValue("@edition", tb_edition.Text);
                    int added = cmd.ExecuteNonQuery();
                  //  query = "update [dbo].[section] SET no_of_books=no_of_books+1 WHERE section_id=@id";
                   // cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@id", dd_section.SelectedValue);
                  // added = cmd.ExecuteNonQuery();
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
       
    }
}