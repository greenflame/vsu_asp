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
        private int CurrentPage
        {
            get { return (int)ViewState["CurrentPage"]; }
            set { ViewState["CurrentPage"] = value; }
        }

        private int PageCount
        {
            get { return (int)ViewState["PageCount"]; }
            set { ViewState["PageCount"] = value; }
        }

        private int PageSize
        {
            get { return (int)ViewState["PageSize"]; }
            set { ViewState["PageSize"] = value; }
        }

        private void InitPager()
        {
            SqlConnection conn = new SqlConnection(DefaultConnection);
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM [Routes]", conn);

            conn.Open();
            int recordsCount = (int)cmd.ExecuteScalar();
            conn.Close();

            // Initing fields
            PageSize = 4;
            CurrentPage = 0;
            PageCount = recordsCount / PageSize + (recordsCount % PageSize != 0 ? 1 : 0);
        }

        private string DefaultConnection
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitPager();
            }
            DataUpdate();
        }

        private void DataUpdate()
        {
            // Table update
            string[] fields = new string[] { "Name", "Description", "Begin_stop", "End_stop" };
            string[] dirs = new string[] { "asc", "desc" };

            string sortField = fields[0];
            if (!string.IsNullOrEmpty(SortBy.Value))
            {
                sortField = fields[int.Parse(SortBy.Value)];
            }

            string sortDir = dirs[0];
            if (!string.IsNullOrEmpty(SortDir.Value))
            {
                sortDir = dirs[int.Parse(SortDir.Value)];
            }

            int startRow = CurrentPage * PageSize + 1;
            int endRow = (CurrentPage + 1) * PageSize;

            string sql = string.Format(@"select * from (select row_number() 
                over(order by t0.{0} {1}) as row_number,
                t0.Name,
                t0.Description,
                t0.Begin_stop,
                t0.End_stop
                from RoutesStopNames AS t0) as t1 where t1.row_number between {2} and {3}",
                sortField, sortDir, startRow, endRow);

            SqlDataSource ds = new SqlDataSource(DefaultConnection, sql);
            gridView_routes.DataSource = ds;
            gridView_routes.DataBind();

            // Pager update
            label_curPage.Text = string.Format("page {0} of {1}", CurrentPage + 1, PageCount);
            linkButton_forward.Enabled = CurrentPage < PageCount - 1;
            linkButton_back.Enabled = CurrentPage > 0;
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
                        DataUpdate();
                        statusLabel.InnerText = "Deleted succesfill";
                    }
                    catch (SqlException)
                    {
                        statusLabel.InnerText = "Delete error";
                    }
                }
            }

            DataUpdate();
        }

        protected void gridView_routes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect(String.Format("RoutesEdit.aspx?name={0}",
                (string)gridView_routes.DataKeys[e.NewEditIndex].Values["Name"]));
        }

        protected void button_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoutesAdd.aspx");
        }

        protected void linkButton_back_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            DataUpdate();
        }

        protected void linkButton_forward_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            DataUpdate();
        }
    }
}