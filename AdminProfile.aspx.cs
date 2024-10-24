using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationonWeb
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conf = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            conn = new SqlConnection(conf);
            conn.Open();

            if (!IsPostBack)
            {
                UserDetails();
            }

        }

        public void UserDetails()
        {
            string sess = Session["MyUser"].ToString();

            string q = "exec Profileproc '" + sess + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader r = cmd.ExecuteReader();
            DataList1.DataSource = r;
            DataList1.DataBind();


        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect($"UpdateAdminProfile.aspx");

            }
        }
    }
}
