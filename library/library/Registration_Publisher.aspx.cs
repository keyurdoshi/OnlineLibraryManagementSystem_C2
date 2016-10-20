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
    public partial class Registration_Publisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void B_click(object sender,EventArgs e)
        {
            string query = "select * from publisher where name=@name city=@city";
            string constr = "";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(con, query);
            cmd.Parameters.AddWithValue("@name", tb_name);
            cmd.Parameters.AddWithValue("@city", tb_city);
            SqlDataReader reader;
            if (reader.Read() == true)
                status.Text = "Publisher name already exists";
            else
            {
                string adsr = tb_addl1 + tb_addl2;
                query = "insert into publisher (name,address,city,contact_no,email) VALUES(@name,@address,@city,@contact_no,@email)";
                try
                {
                    cmd = new SqlCommand(con, query);
                    cmd.ExecuteNonQuery();
                    status.Text = "success";
                }
                catch(Exception e)
                {
                    status.Text = "fail";
                }
                  
            }
            con.Close();
            reader.Close();
          
    }
}