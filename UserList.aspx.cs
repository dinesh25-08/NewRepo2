using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AuthenticationonWeb
{   
    public partial class UserList : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conf = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            conn= new SqlConnection(conf);
            conn.Open();
            if (!IsPostBack)
            {
                fetchData();
            }   

        }
        public void fetchData()
        {
            string q = "exec userListproc";
            SqlDataAdapter adapter = new SqlDataAdapter(q,conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            GridView1.DataSource = dataSet;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name=TextBox1.Text;
            string q = "exec searchUserproc '"+name+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            GridView1.DataSource = dataSet;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           Label l1=(Label) GridView1.Rows[e.RowIndex].FindControl("Label1");
            string line=l1.Text;
            string q = "exec userDeleteproc '" +line+ "'";
            SqlCommand cmd = new SqlCommand(q,conn);
            cmd.ExecuteNonQuery();        
            fetchData();
        }
    }
}