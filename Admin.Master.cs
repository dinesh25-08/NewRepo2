using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationonWeb
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string conf = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            conn = new SqlConnection(conf);
            conn.Open();
            if (Session["MyUser"]!=null)
            {
                string q = "select *from cred where uemail='" + Session["MyUser"].ToString() + "'or uname='" + Session["MyUser"].ToString() +"'";
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
            string user, pass, email, contact, role="User", status="Active", file, name;
            user = TextBox2.Text;
            pass = TextBox3.Text;
            email = TextBox4.Text;
            contact = TextBox5.Text;
            name = TextBox6.Text;

            FileUpload1.SaveAs(Server.MapPath("Profile/") + Path.GetFileName(FileUpload1.FileName));
            file = "Profile/" + Path.GetFileName(FileUpload1.FileName);

            string myq = $"select *from cred where uemail='"+email+"' or uname='"+user+"' ";
            SqlCommand command = new SqlCommand(myq, conn);
            SqlDataReader rdr = command.ExecuteReader();
            

            if (rdr.HasRows)
            {
                rdr.Read(); // Read the first row

                string exmail = rdr["uemail"].ToString();
                string exname = rdr["uname"].ToString();

                if (exmail.Equals(email))
                {
                    Response.Write("<script>alert('Email already exists')</script>");
                }
                else if (exname.Equals(user))
                {
                    Response.Write("<script>alert('Username already exists')</script>");
                }
            }
            else
            {
                // If no existing user is found, proceed with the registration
                rdr.Close(); // Close the SqlDataReader before executing another command

                string q = $"EXEC RegisterProc '{user}', '{pass}', '{email}', '{contact}', '{role}', '{file}', '{status}', '{name}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('User Details Added successfully')</script>");
                resetInfo(); // Reset the form fields
            }



        }


        public void resetInfo()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string em, npass, cpass, opass;
            em = Session["MyUser"].ToString();
            opass = TextBox7.Text;
            npass = TextBox8.Text;
            cpass = TextBox9.Text;

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
    }
}