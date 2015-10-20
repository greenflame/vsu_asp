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
    public partial class Routes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlDataSource ds = new SqlDataSource(
                    System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                    "select * from Routes");
                gridView_routes.DataSource = ds;
                gridView_routes.DataBind();
            }
        }

        protected void gridView_routes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "DELETE FROM [Routes] WHERE Name=@name";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Name", Convert.ToString(gridView_routes.DataKeys[e.RowIndex].Values["Name"]));

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        gridView_routes.DataBind();
                        statusLabel.InnerText = "Deleted succesfill";
                    }
                    catch (SqlException ex)
                    {
                        statusLabel.InnerText = "Delete error";
                    }
                }
            }
        }

        protected void button_add_Click(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "INSERT INTO [Routes] (Name,Description) values (@name,@description)";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@name", textBox_name.Text);
                    comm.Parameters.AddWithValue("@description", textBox_description.Text);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();

                        gridView_routes.DataBind();
                        textBox_name.Text = "";
                        textBox_description.Text = "";

                        statusLabel.InnerText = "Inserted succesfill";
                    }
                    catch (SqlException ex)
                    {
                        statusLabel.InnerText = "Insert error";
                    }
                }
            }
        }

        protected void gridView_routes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect(String.Format("RoutesEdit.aspx?name={0}&description={1}",
                (string)gridView_routes.DataKeys[e.NewEditIndex].Values["Name"],
                (string)gridView_routes.DataKeys[e.NewEditIndex].Values["Description"]));
        }
    }
}