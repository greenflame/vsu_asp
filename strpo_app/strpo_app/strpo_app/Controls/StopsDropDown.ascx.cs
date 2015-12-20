using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace strpo_app.Controls
{
    public partial class StopsDropDown : System.Web.UI.UserControl
    {
        public int StopId
        {
            get
            {
                List<StopRecord> stops = GetAllStops();
                return stops[dropDown.SelectedIndex].Id;
            }
            set
            {
                FillDropDown();

                List<StopRecord> stops = GetAllStops();

                for (int i = 0; i < stops.Count; i++)
                {
                    if(stops[i].Id == value)
                    {
                        dropDown.SelectedIndex = i;
                        return;
                    }
                }

                throw new Exception("Invalid id");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillDropDown();
            }
        }

        private class StopRecord
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public StopRecord(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        private List<StopRecord> GetAllStops()
        {
            List<StopRecord> stops = new List<StopRecord>();

            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "SELECT * FROM [Stops]";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = query;

                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        stops.Add(new StopRecord(id, name));
                    }
                }
            }

            return stops;
        }

        private void FillDropDown()
        {
            if (dropDown.Items.Count != 0)
            {
                return;
            }

            List<StopRecord> stops = GetAllStops();

            foreach(StopRecord stop in stops)
            {
                dropDown.Items.Add(stop.Name);
            }
        }
    }
}