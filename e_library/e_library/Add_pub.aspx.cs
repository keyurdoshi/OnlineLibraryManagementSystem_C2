using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace e_library
{
    public partial class Add_publisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void B_click(object sender, EventArgs e)
        {

            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "select count(*) from [dbo].[publisher] where pub_name=@name AND city=@city";
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
                    query = "insert into [dbo].[publisher] (pub_name,city,address,email,phone_no) VALUES (@name,@city,@addr,@email,@phone_no)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", tb_name.Text.ToLower());
                    cmd.Parameters.AddWithValue("@city", tb_city.Text.ToLower());
                    cmd.Parameters.AddWithValue("@addr", tb_addr.Text);
                    cmd.Parameters.AddWithValue("@email", tb_email.Text);
                    cmd.Parameters.AddWithValue("@phone_no", tb_contactno.Text);
                    int x = cmd.ExecuteNonQuery();
                    status.Text = "inserted in publisher";
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