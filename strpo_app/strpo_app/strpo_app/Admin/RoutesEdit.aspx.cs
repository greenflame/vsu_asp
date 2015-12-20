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
                FillFields();
            }
        }

        private void FillFields()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "SELECT * FROM [Routes] WHERE Name = @name";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@name", Request.QueryString["name"]);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = comm.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            routesControl.Name = reader.GetString(0);
                            routesControl.Description = reader.GetString(1);
                            routesControl.BeginStop = reader.GetInt32(2);
                            routesControl.EndStop = reader.GetInt32(3);
                        }
                        else
                        {
                            statusLabel.InnerText = "Record doesn't exist";
                        }
                    }
                    catch (SqlException)
                    {
                        statusLabel.InnerText = "Select error";
                    }
                }
            }
        }

        protected void button_update_Click(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "UPDATE [Routes] SET Name = @name, Description = @description, Begin_stop = @begin_stop, End_stop = @end_stop WHERE Name = @oldName";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@name", routesControl.Name);
                    comm.Parameters.AddWithValue("@description", routesControl.Description);
                    comm.Parameters.AddWithValue("@begin_stop", routesControl.BeginStop);
                    comm.Parameters.AddWithValue("@end_stop", routesControl.EndStop);
                    comm.Parameters.AddWithValue("@oldName", Request.QueryString["name"]);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();

                        Response.Redirect("RoutesView.aspx");
                    }
                    catch (SqlException)
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