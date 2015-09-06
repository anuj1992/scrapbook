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

public partial class changepass : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["mycon"]);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnchangepass_Click(object sender, EventArgs e)
    {
        SqlCommand com = new SqlCommand("update login set password=@pass where userid=@uid", con);
        com.Parameters.Add("@pass", SqlDbType.VarChar).Value =txtnewpass.Text ;
        com.Parameters.Add("@uid", SqlDbType.VarChar).Value = Session["userid"].ToString();
        con.Open();
       int i= com.ExecuteNonQuery();
        con.Close();
        if (i > 0)
        {
            Response.Write("<script language='javascript'>alert('You password changed succesfully..!!!!');</script>");

        }
    }
   
}