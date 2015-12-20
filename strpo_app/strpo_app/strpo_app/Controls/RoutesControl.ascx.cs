using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace strpo_app.Admin
{
    public partial class RoutesControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Name
        {
            get
            {
                return textBox_name.Text;
            }
            set
            {
                textBox_name.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return textBox_description.Text;
            }
            set
            {
                textBox_description.Text = value;
            }
        }

        public int BeginStop
        {
            get
            {
                return beginStop.StopId;
            }
            set
            {
                beginStop.StopId = value;
            }
        }

        public int EndStop
        {
            get
            {
                return endStop.StopId;
            }
            set
            {
                endStop.StopId = value;
            }
        }
    }
}