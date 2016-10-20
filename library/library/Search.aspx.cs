using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace library
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (Session["user"] == null)
            //    Response.Redirect("~/login.aspx?msg=Please Log in");
          //else
           // {
                dd_search.Items.Add("Name");
                dd_search.Items.Add("Branch");

           // }
        }
        protected void search_b_click(Object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\documents\visual studio 2015\Projects\library\library\App_Data\user.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "select * from member where Name=@value OR Branch=@value";
            SqlCommand cmd = new SqlCommand(query, con);
           
            //cmd.Parameters.AddWithValue("@category", dd_search.SelectedItem.Text);
          cmd.Parameters.AddWithValue("@value", tb_search.Text);
           
           /* SqlDataReader reader;
            try
            {
                con.Open();
                
                reader = cmd.ExecuteReader();
               
                    
                while (reader.Read())
                    status.Text = reader["Email"].ToString();

            }
            catch(Exception err)
            {
                status.Text = err.Message;
            }
            finally
            {
                con.Close();
            }*/
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    
            DataSet ds = new DataSet();
            adapter.Fill(ds, "member");
            
            //Perform the binding.
            gv_search.DataSource = ds;
            gv_search.DataBind();


    
        }
        
        }
}