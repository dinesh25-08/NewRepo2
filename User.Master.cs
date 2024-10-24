using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationonWeb
{
    public partial class User : System.Web.UI.MasterPage
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conf = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            conn = new SqlConnection(conf);
            conn.Open();
            if (Session["Myid"] != null)
            {
                string q = "select *from cred where uid='" + Session["Myid"].ToString() + "'";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                string name = rdr["name"].ToString();
                
                Label1.Text = name;
            }
            else
            {
                Response.Write("<script>alert('Invalid Session');window.location.href='Login.aspx'</script>");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string em, npass, cpass,opass;
            em = Session["MyUser"].ToString();
            opass=TextBox2.Text;
            npass = TextBox3.Text;
            cpass = TextBox4.Text;

            string myq = $"select *from cred where uemail='" + em + "' or uname='" + em + "' ";
            SqlCommand command = new SqlCommand(myq, conn);
            SqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            string uname = rdr["uname"].ToString();
            string uemail = rdr["uemail"].ToString();
            string old = rdr["upass"].ToString();

            if (old.Equals(opass))
            {

                if (npass.Equals(cpass))
                {
                    string q = "exec resetPasswordproc '" + uemail + "','" + npass + "' ";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Password Changed Successfully')</script>");
                    resetInfo();

                }

            }
            else
            {
                Response.Write("<script>alert('Old Password not Matched')</script>");

            }


        }

        public void resetInfo()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";

        }
    }
}