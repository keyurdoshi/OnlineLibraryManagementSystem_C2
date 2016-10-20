using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace library
{
    public partial class Addsysdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void b_click(Object sender,EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\documents\visual studio 2015\Projects\library\library\App_Data\user.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
           
            try
            {
                con.Open();
                string query = "insert into [dbo].[temp] (name) VALUES(@name)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", tb.Text);
                cmd.ExecuteNonQuery();
                status.Text = "success";

            }
            catch (Exception err)
            {
                status.Text =err.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}