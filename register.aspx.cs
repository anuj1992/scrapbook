using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["mycon"]);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
         SqlCommand com2 = new SqlCommand("select * from login where idno=@id", con);
        com2.Parameters.Add("@id", SqlDbType.Int).Value =txtcolgid.Text;
        SqlDataAdapter da1 = new SqlDataAdapter();
        DataSet ds1 = new DataSet();
        da1.SelectCommand = com2;
        da1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count > 0)
        {
           // Label1.Text = "This Id Number '" + TextBox1.Text + "' is Already Registered";
            Response.Write("<script language='javascript'>alert('You have been already registered..!!!!');</script>");


        }
        else
        {

            SqlCommand com = new SqlCommand("select * from studentinfo where Idno=@id", con);
            com.Parameters.Add("@id", SqlDbType.Int).Value =txtcolgid.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = com;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                //  Label1.Text = "Id Number '" + TextBox1.Text + "' Seems to be Incorrect or does not belong to the Selected Branch ";
                Response.Write("<script language='javascript'>alert('Given Id Number does not Exist..!!!!');</script>");


            }
            else
            {
                int n;
                string userid;
                SqlDataAdapter da3 = new SqlDataAdapter("select * from login where email='"+txtemail.Text+"'", con);
                DataSet ds3 = new DataSet();
                // da1.SelectCommand = com3;
                da3.Fill(ds3);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script language='javascript'>alert('This email-id has been already registered..!!!!');</script>");

                }
                else
                {
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from login", con);
                    DataSet ds2 = new DataSet();
                    // da1.SelectCommand = com3;
                    da2.Fill(ds2);
                    n = ds2.Tables[0].Rows.Count;
                    if (n == 0)
                    {
                        userid = "U0001";
                    }
                    else
                    {
                        userid = "U000" + (n + 1).ToString();
                    }

                    SqlCommand cmd = new SqlCommand("insert into login(userid,username,password,idno,email)values(@userid,@username,@password,@idno,@email)", con);
                    cmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = userid;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = ds.Tables[0].Rows[0]["name"].ToString();
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtnewpassword.Text;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtemail.Text;
                    cmd.Parameters.Add("@idno", SqlDbType.VarChar).Value = txtcolgid.Text;
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    con.Close();
                    if (res > 0)
                    {
                        Response.Write("<script language='javascript'>alert('Your Registration Process has been successfully done..!!!!');</script>");
                        Response.Redirect("login.aspx");

                    }

                }
            }
        }
          
    }
}