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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

public partial class uploadpic : System.Web.UI.Page
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
                Image1.ImageUrl = Session["pid"].ToString();
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string[] validFileTypes = { "jpg", "jpeg", "JPG", "JPEG", "png", "PNG" };
                string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                bool isValidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile)
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Invalid File. Please upload a File with extension " +
                                   string.Join(",", validFileTypes);
                }
                else
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string targetPath = Server.MapPath("profilepic/" + filename);
                    Stream strm = FileUpload1.PostedFile.InputStream;
                    var targetFile = targetPath;

                    string str1 = Server.MapPath("~/profilepic/");
                    FileUpload1.SaveAs(str1 + "" + FileUpload1.PostedFile.FileName);
                    GenerateThumbnails(0.5, strm, targetFile);
                    SqlCommand cmd = new SqlCommand("update login set picid=@picid where userid=@uid", con);
                    cmd.Parameters.Add("@picid", SqlDbType.VarChar).Value = "~/profilepic/" + FileUpload1.FileName;
                    cmd.Parameters.Add("@uid", SqlDbType.VarChar).Value = Session["userid"].ToString();


                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Response.Write("<script language='javascript'>alert('Your Profile Picture uploaded succesfully..!!!!');</script>");
                        Session["pid"] = "~/profilepic/" + FileUpload1.FileName;
                        Image1.ImageUrl = Session["pid"].ToString();

                    }

                }
            }
            catch (Exception ex)
            {
               // Response.Write("<script language='javascript'>alert('Your File name is too long rename it and upload again "+ex.Message+"');</script>");
                Label1.Text="Your File name is too long rename it and upload again "+ex.Message+"";

            }
        }
       

    }
    private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            var newWidth = (int)(image.Width * scaleFactor);
            var newHeight = (int)(image.Height * scaleFactor);
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }
}