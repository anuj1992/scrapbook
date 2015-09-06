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

public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["mycon"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        SqlCommand com2 = new SqlCommand("select * from login where email=@email and password=@pass", con);
        com2.Parameters.Add("@email", SqlDbType.VarChar).Value = TextBox1.Text;
        com2.Parameters.Add("@pass", SqlDbType.VarChar).Value = TextBox2.Text;
        SqlDataAdapter da1 = new SqlDataAdapter();
        DataSet ds1 = new DataSet();
        da1.SelectCommand = com2;
        da1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script language='javascript'>alert('Invalid Username or Password..!!!!');</script>");
            
            // HyperLink1.Visible = true;
        }
        else
        {
            Session["userid"] = ds1.Tables[0].Rows[0]["userid"].ToString();
            Response.Redirect("myprofile.aspx");
        }
    }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
}