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
using System.Globalization;

public partial class writetscrap : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["mycon"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                string recvname;
                recvname = Request.QueryString["uname"].ToString();
                Label1.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(recvname.ToLower());
                SqlDataAdapter da3 = new SqlDataAdapter("select * from login where userid='"+Request.QueryString["uid"].ToString()+"'", con);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                Image1.ImageUrl = ds3.Tables[0].Rows[0]["picid"].ToString();
                Image2.ImageUrl = ds3.Tables[0].Rows[0]["picid"].ToString();

                SqlDataAdapter da2 = new SqlDataAdapter("select * from scrapbook where senderid='" + Session["userid"].ToString() + "' and recieverid='" + Request.QueryString["uid"].ToString() + "'", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    txttitle.Text = ds2.Tables[0].Rows[0]["title"].ToString();
                    txtdescription.Text = ds2.Tables[0].Rows[0]["description"].ToString();
                }
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string recid,receivername;
        recid = Request.QueryString["uid"].ToString();
        SqlDataAdapter da = new SqlDataAdapter("select * from login where userid='"+recid+"'",con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        receivername = ds.Tables[0].Rows[0]["username"].ToString();
        SqlDataAdapter da2 = new SqlDataAdapter("select * from scrapbook where senderid='" + Session["userid"].ToString() + "' and recieverid='" + recid +"'", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        if (ds2.Tables[0].Rows.Count == 0)
        {

            SqlCommand cmd = new SqlCommand("insert into scrapbook(senderid,recieverid,description,title)values(@senderid,@recieverid,@description,@title)", con);
            cmd.Parameters.Add("@senderid", SqlDbType.VarChar).Value = Session["userid"].ToString();
            cmd.Parameters.Add("@recieverid", SqlDbType.VarChar).Value = Request.QueryString["uid"].ToString();
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = txtdescription.Text;
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = txttitle.Text;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                Response.Write("<script language='javascript'>alert('You have been successfully written for " + receivername + "  ..!!!!');</script>");

            }
        }
        else
        {
            SqlCommand cmd = new SqlCommand("update scrapbook set title=@title,description=@description where senderid='" + Session["userid"].ToString() + "' and recieverid='" + recid + "'", con);
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = txtdescription.Text;
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = txttitle.Text;
            con.Open();
          int j=  cmd.ExecuteNonQuery();
            con.Close();
            if (j > 0)
            {
                Response.Write("<script language='javascript'>alert('You have been successfully updated your views for " + receivername + "  ..!!!!');</script>");

            }

        }

        
        
    }
}