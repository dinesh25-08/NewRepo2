using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationonWeb
{
    public partial class ManageUser : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conf = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            conn = new SqlConnection(conf);
            conn.Open();

            if (!IsPostBack)
            {
                fetchData();
            }
        }

        public void fetchData()
        {
            string q = "exec userListproc";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                string id = e.CommandArgument.ToString();

                string q = "SELECT * FROM cred WHERE uid='"+id+"'";
                SqlCommand cmd = new SqlCommand(q, conn);                
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                string status = rd["ustatus"].ToString();
                string newStatus = " ";

                if (status == "Active")
                {
                    newStatus = "Inactive";
                }
                else
                {
                    newStatus = "Active";
                }                

                string updateQuery = "UPDATE cred SET ustatus = '"+newStatus+"' WHERE uid = '"+id+"' ";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.ExecuteNonQuery();

                fetchData();

               
                Response.Write("<script>alert('User status updated to " + newStatus + "');</script>");
            }
        } 



    }
}
