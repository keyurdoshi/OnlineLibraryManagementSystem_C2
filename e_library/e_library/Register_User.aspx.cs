using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace e_library
{
    public partial class Register_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            branch_dd.Items.Add("Computer Engineering");
            branch_dd.Items.Add("Chemical Engineering");
            branch_dd.Items.Add("Mechanical Engineering");
            branch_dd.Items.Add("Civil Engineering");
            branch_dd.Items.Add("Information Technology");
            category_dd.Items.Add("Student");
            category_dd.Items.Add("Professor");
        }

        protected void Button1_register_Click(object sender, EventArgs e)
        {
            // string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\Visual Studio 2015\Projects\library\library\App_Data\user.mdf;Integrated Security=True";
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);


            try
            {
                con.Open();
                string query = "select count(*) from [dbo].[member] where email=@email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", tb_email.Text);
                int exists = (int)cmd.ExecuteScalar();
                if (exists > 0)
                    status.Text = "Email already exists";
                else
                {
                    query = "insert into [dbo].[member] (member_name,email,password,phone_no,branch,Category) VALUES(@name,@email,@password,@contact,@branch,@category)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name",tb_name.Text);
                    cmd.Parameters.AddWithValue("@email",tb_email.Text);
                    cmd.Parameters.AddWithValue("@password", tb_pwd.Text);
                    cmd.Parameters.AddWithValue("@contact",tb_contact.Text);
                    cmd.Parameters.AddWithValue("@branch", branch_dd.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@category", category_dd.SelectedItem.Text);
                    exists = cmd.ExecuteNonQuery();
                    Response.Redirect("~/Login_user.aspx");
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