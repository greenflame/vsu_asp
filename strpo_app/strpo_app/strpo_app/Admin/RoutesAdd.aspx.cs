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
    public partial class RoutesAdd : System.Web.UI.Page
    {
        private int LastBeginStopId
        {
            get
            {
                return Session["LastBeginStopId"] == null ? -1 :(Int32)Session["LastBeginStopId"];
            }
            set
            {
                Session["LastBeginStopId"] = value;
            }
        }

        private int LastEndStopId
        {
            get
            {
                return Session["LastEndStopId"] == null ? -1 : (Int32)Session["LastEndStopId"];
            }
            set
            {
                Session["LastEndStopId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LastBeginStopId != -1)
                {
                    routesControl.BeginStop = LastBeginStopId;
                }
                if (LastEndStopId != -1)
                {
                    routesControl.EndStop = LastEndStopId;
                }
            }
        }

        protected void button_add_Click(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "INSERT INTO [Routes] (Name,Description,Begin_stop,End_stop) values (@name,@description,@begin_stop,@end_stop)";

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

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();

                        LastBeginStopId = routesControl.BeginStop;
                        LastEndStopId = routesControl.EndStop;

                        Response.Redirect("RoutesView.aspx");
                    }
                    catch (SqlException)
                    {
                        statusLabel.InnerText = "Insert error";
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