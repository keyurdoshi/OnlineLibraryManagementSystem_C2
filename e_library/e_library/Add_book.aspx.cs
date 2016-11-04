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
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "select seller_id,seller_name from [dbo].[seller]";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            dd_seller_name.DataSource = cmd.ExecuteReader();
            dd_seller_name.DataTextField = "seller_name";
            dd_seller_name.DataValueField = "seller_id";
            dd_seller_name.DataBind();
            con.Close();
            con.Open();
              query = "select pub_id,pub_name from [dbo].[publisher]";
                   cmd = new SqlCommand(query, con);
                   dd_publisher_name.DataSource = cmd.ExecuteReader();
                   dd_publisher_name.DataTextField = "pub_name";
                   dd_publisher_name.DataValueField = "pub_id";
                     dd_publisher_name.DataBind();
            con.Close();
            con.Open();
            query = "select section_id,section_name from [dbo].[section]";
                cmd = new SqlCommand(query, con);
                dd_section.DataSource = cmd.ExecuteReader();
                dd_section.DataTextField = "section_name";
                dd_section.DataValueField = "section_id";
                dd_section.DataBind();
            con.Close();
           
           
        }
        protected void b_click(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "select count(*) from [dbo].[books] where book_name=@name";
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
                    query = "insert into [dbo].[books] (book_name,author_name,language,description,total_qty,mrp,pub_year,length,pub_name,seller_name,section_name,Edition) VALUES(@book_name,@author_name,@language,@description,@qty,@mrp,@pub_year,@length,@pub_name,@seller_name,@section_name,@edition)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@book_name", tb_book_name.Text.ToLower());
                    cmd.Parameters.AddWithValue("@author_name", tb_author_name.Text.ToLower());
                    cmd.Parameters.AddWithValue("@language", tb_language.Text.ToLower());
                    cmd.Parameters.AddWithValue("@description", tb_description.Text.ToLower());
                    cmd.Parameters.AddWithValue("@qty", tb_quantity.Text);
                    cmd.Parameters.AddWithValue("@mrp", tb_mrp.Text);
                    cmd.Parameters.AddWithValue("@pub_year", tb_pub_year.Text);
                    cmd.Parameters.AddWithValue("@length", tb_noofpages.Text);
                    cmd.Parameters.AddWithValue("@pub_name", dd_publisher_name.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@seller_name", dd_seller_name.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@section_name", dd_section.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@edition", tb_edition.Text);
                    int added = cmd.ExecuteNonQuery();
                    status.Text = "inserted";
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