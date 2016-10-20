using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace library
{
    public partial class registeruser : System.Web.UI.Page
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
      protected void reguser_b_click(object sender, EventArgs e)
        {
             string constr= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Documents\Visual Studio 2015\Projects\library\library\App_Data\user.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            
            
            try
            {
                con.Open();
                string query = "select count(*) from [dbo].[member] where Email=@email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", email_tb.Text);
                int exists = (int)cmd.ExecuteScalar();
                if (exists > 0)
                    status.Text = "Username already exists";
                else
                {
                    query="insert into [dbo].[member] (Name,Email,Password,Confirmpassword,Contact_no,Branch,Category) VALUES(@name,@email,@password,@confirmpassword,@contact,@branch,@category)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name_tb.Text);
                    cmd.Parameters.AddWithValue("@email", email_tb.Text);
                    cmd.Parameters.AddWithValue("@password", password_tb.Text);
                    cmd.Parameters.AddWithValue("@confirmpassword", confirmpassword_tb.Text);
                    cmd.Parameters.AddWithValue("@contact", contact_no_tb.Text);
                    cmd.Parameters.AddWithValue("@branch", branch_dd.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@category", category_dd.SelectedItem.Text);
                    exists = cmd.ExecuteNonQuery();

                    
                }
            }
            catch(Exception err)
            {
                status.Text = "error";
            }
            finally
            {
                con.Close();
            }
        }
    }
}