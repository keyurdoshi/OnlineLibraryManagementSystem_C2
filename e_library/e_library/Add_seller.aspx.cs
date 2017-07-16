using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_library
{
    public partial class Add_seller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void B_click(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "select count(*) from [dbo].[seller] where seller_name=@name AND city=@city";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", tb_name.Text.ToLower());
            cmd.Parameters.AddWithValue("@city", tb_city.Text.ToLower());
            try
            {
                con.Open();
                int exist = (int)cmd.ExecuteScalar();
                if (exist > 0)
                    status.Text = "already exist";
                else
                {
                    query = "insert into [dbo].[seller] (seller_name,city,address,email,phone_no) VALUES (@name,@city,@addr,@email,@phone_no)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", tb_name.Text.ToLower());
                    cmd.Parameters.AddWithValue("@city", tb_city.Text.ToLower());
                    cmd.Parameters.AddWithValue("@addr", tb_addr.Text);
                    cmd.Parameters.AddWithValue("@email", tb_email.Text);
                    cmd.Parameters.AddWithValue("@phone_no", tb_contactno.Text);
                    int x = cmd.ExecuteNonQuery();
                    status.Text = "inserted in seller";
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