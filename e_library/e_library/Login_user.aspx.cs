using System;
using System.Data.SqlClient;

namespace e_library
{
    public partial class Login_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            status.Text = Request.QueryString["msg"];
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string selectSQL = "select * from [dbo].[member] where email=@email AND password=@password";
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@email", tb_email.Text);
                cmd.Parameters.AddWithValue("@password", tb_pwd.Text);
                reader = cmd.ExecuteReader();
                if (reader.Read() == false)
                {
                    status.Text = "Invalid Username or Password.";
                }
                else
                {
                    Session["user"] = tb_email.Text;
                    Response.Redirect("Home.aspx");
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