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

public partial class testimonial : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["mycon"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        string username;
        if (Session["userid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            CreateButtons();
            if (!IsPostBack)
            {
                string picid;
                SqlDataAdapter da2 = new SqlDataAdapter("select * from login where userid='" + Session["userid"].ToString() + "'", con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                username=ds2.Tables[0].Rows[0]["username"].ToString();
                lbltitle.Text =  CultureInfo.CurrentCulture.TextInfo.ToTitleCase(username.ToLower());
                Session["pid"] = ds2.Tables[0].Rows[0]["picid"].ToString();
                Image1.ImageUrl = Session["pid"].ToString();
                Image2.ImageUrl = Session["pid"].ToString();
            }
        }
    }

    void CreateButtons()
    {
       SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=scrapbook;Integrated Security=True");
             SqlCommand cmd1 = new SqlCommand("select * from scrapbook where recieverid='" + Session["userid"].ToString() + "'", con);
              SqlDataAdapter da1 = new SqlDataAdapter();
              da1.SelectCommand = cmd1;
              DataSet ds1 = new DataSet();
              da1.Fill(ds1, "scrapbook");
              for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
              {
                  LinkButton btn = new LinkButton();
                  SqlDataAdapter da2 = new SqlDataAdapter("select * from login where userid='" + ds1.Tables[0].Rows[i]["senderid"].ToString() + "'", con);
                  DataSet ds2 = new DataSet();
                  da2.Fill(ds2);
                 // name = ds2.Tables[0].Rows[0]["username"].ToString();
                  btn.Text =ds2.Tables[0].Rows[0]["username"].ToString();
                  btn.ID = ds2.Tables[0].Rows[0]["userid"].ToString();
                  btn.CssClass = "username";
                  usr.Controls.Add(btn);
                 
                 // dynamiclink.Visible = true;
                  btn.Click += new EventHandler(btn_Click);
              }

       // }
    }

    void btn_Click(object sender, EventArgs e)
    {

        string senderid,name;
        LinkButton btn = sender as LinkButton;
       // Response.Write("<script language='javascript'>alert('Button "+ btn.Text+" has been clicked');</script>");
        //Response.Redirect("writetscrap.aspx");

        senderid = btn.ID;

        SqlDataAdapter da2 = new SqlDataAdapter("select * from scrapbook where senderid='" + senderid + "' and recieverid='"+Session["userid"].ToString()+"'", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        lbldescription.Text = ds2.Tables[0].Rows[0]["description"].ToString();
        lbltitle.Text = ds2.Tables[0].Rows[0]["title"].ToString();
      // =btn.Text;
       name = btn.Text.ToLower();
      

        txtsendername.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
       

    }
}