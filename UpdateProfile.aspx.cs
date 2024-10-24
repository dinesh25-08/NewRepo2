using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationonWeb
{
    
    public partial class UpdateProfile : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf= ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            conn = new SqlConnection(cnf);
            conn.Open();

            if (!IsPostBack)
            {
                Updatedetails();
            }

        }

        public void Updatedetails() {

            string qs = Session["Myid"].ToString();
            string q = "Select *from cred where uid='" + qs + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataList1.DataSource = rdr;
            DataList1.DataBind();            

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {


            if (e.CommandName == "update")
            {
                            
                string id = e.CommandArgument.ToString();
                TextBox tb1 = (TextBox)e.Item.FindControl("TextBox5");
                TextBox tb2 = (TextBox)e.Item.FindControl("TextBox6");
                TextBox tb3 = (TextBox)e.Item.FindControl("TextBox7");
                TextBox tb4 = (TextBox)e.Item.FindControl("TextBox8");
                FileUpload file = (FileUpload)e.Item.FindControl("FileUpload1");

                string x=string.Empty;
                if (file != null) {
                    file.SaveAs(Server.MapPath("Profile/") + Path.GetFileName(file.FileName));
                    x = "Profile/" + Path.GetFileName(file.FileName);
                }               
                                
                string q = "Update cred set name='" + tb1.Text + "',uname='" + tb2.Text + "',uemail='" + tb3.Text + "',ucontact='" + tb4.Text + "',uprofile='" + x + "' where uid='" + id + "'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                Response.Redirect("Userprofile.aspx");                           
                
            }

        }

    }
}