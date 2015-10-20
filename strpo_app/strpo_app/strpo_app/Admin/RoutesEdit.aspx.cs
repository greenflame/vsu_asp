using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace strpo_app.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                textBox_name.Text = Request.QueryString["name"];
                textBox_description.Text = Request.QueryString["description"];
            }
        }

        protected void button_update_Click(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "UPDATE [Routes] SET Name = @name, Description = @description WHERE Name = @oldName";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@name", textBox_name.Text);
                    comm.Parameters.AddWithValue("@description", textBox_description.Text);
                    comm.Parameters.AddWithValue("@oldName", Request.QueryString["name"]);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();

                        Response.Redirect("RoutesView.aspx");
                    }
                    catch (SqlException ex)
                    {
                        statusLabel.InnerText = "Update error";
                    }
                }
            }
        }

        protected void button_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoutesView.aspx");
        }
    }
}