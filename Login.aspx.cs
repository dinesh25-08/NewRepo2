using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

namespace AuthenticationonWeb
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
            conn = new SqlConnection(cnf);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string em = TextBox1.Text;
            string p = TextBox2.Text;
            string q = "exec auth_login_proc '" + em + "','" + p + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if ((rdr["uemail"].ToString().Equals(em) || rdr["uname"].ToString().Equals(em)) &&
                        rdr["upass"].ToString().Equals(p))
                    {
                        Session["MyUser"] = rdr["uemail"].ToString();
                        Session["Myid"] = rdr["uid"].ToString();

                        if (rdr["ustatus"].ToString().Equals("Active"))
                        {
                            if (rdr["urole"].ToString().Equals("Admin"))
                            {
                                Response.Redirect("AdminHome.aspx");
                            }
                            else if (rdr["urole"].ToString().Equals("User"))
                            {
                                Response.Redirect("UserPage.aspx");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Your account is Inactive');window.location.href='Login.aspx'</script>");
                        }
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentials');</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string gemail = TextBox3.Text;
            string gotp = getOTP();
            Session["GETOTP"] = gotp;
            Session["GETOTPExpiry"] = DateTime.Now.AddMinutes(2);
            SendEmail(gemail, gotp);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string cem = TextBox3.Text;
            string newpass = TextBox4.Text;
            string enterotp = TextBox7.Text;
            string q = "select * from cred where uemail='" + cem + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows && rdr.Read())
            {
                string t2 = rdr["name"].ToString();
                rdr.Close();

                string myotp = Session["GETOTP"]?.ToString();
                DateTime expiryTime = Session["GETOTPExpiry"] != null ? (DateTime)Session["GETOTPExpiry"] : DateTime.MinValue;

                if (myotp == enterotp && DateTime.Now <= expiryTime)
                {
                    string qr = "update cred set upass='" + newpass + "' where uemail='" + cem + "'";
                    SqlCommand cmdr = new SqlCommand(qr, conn);
                    cmdr.ExecuteNonQuery();

                    SendPasswordChangeEmail(cem, t2);
                    Response.Write("<script>alert('Password Reset Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Incorrect OTP or OTP has expired')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Email')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string gemail = TextBox5.Text;
            string gotp = getOTP();
            Session["GETOTP"] = gotp;
            Session["GETOTPExpiry"] = DateTime.Now.AddMinutes(2);
            SendEmail(gemail, gotp);
        }

        protected string getOTP()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString();
        }

        protected void SendEmail(string Toemail, string otp)
        {
            MailMessage gm = new MailMessage();
            gm.From = new MailAddress("dineshvelpula025@mail.com");
            gm.To.Add(Toemail);
            gm.Subject = "OTP Verification";
            gm.Body = $"Your OTP is : {otp}";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Credentials = new NetworkCredential("dineshvelpula025@gmail.com", "enamvzcbazrtnimk");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(gm);
        }

        protected void SendPasswordChangeEmail(string cem, string t2)
        {
            MailMessage gm = new MailMessage();
            gm.From = new MailAddress("dineshvelpula025@mail.com");
            gm.To.Add(cem);
            gm.Subject = "Password Changed Successfully";
            gm.Body = $"Hello {t2}!! \n\nYour Password Changed Successfully";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Credentials = new NetworkCredential("dineshvelpula025@gmail.com", "enamvzcbazrtnimk");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(gm);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string exotp, enotp;

            if (Session["GETOTP"] != null)
            {
                exotp = Session["GETOTP"].ToString();
                DateTime expiryTime = Session["GETOTPExpiry"] != null ? (DateTime)Session["GETOTPExpiry"] : DateTime.MinValue;

                enotp = TextBox6.Text;

                if (exotp.Equals(enotp) && DateTime.Now <= expiryTime)
                {
                    string id = TextBox5.Text;
                    string q = "select * from cred where uemail='" + id + "'";
                    SqlCommand cmd = new SqlCommand(q, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows && rdr.Read())
                    {
                        string role = rdr["urole"].ToString();
                        Session["MyUser"] = rdr["uemail"].ToString();
                        Session["Myid"] = rdr["uid"].ToString();

                        if (rdr["ustatus"].ToString().Equals("Active"))
                        {
                            if (role == "Admin")
                            {
                                Response.Redirect("AdminHome.aspx");
                            }
                            else if (role == "User")
                            {
                                Response.Redirect("UserPage.aspx");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Your account is Inactive');window.location.href='Login.aspx'</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Credentials');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Incorrect OTP or OTP has expired');</script>");
                }
            }
        }
    }
}
