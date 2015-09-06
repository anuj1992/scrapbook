<%@ Page Title="" Language="C#" MasterPageFile="~/afterlogin.master" AutoEventWireup="true" CodeFile="myprofile.aspx.cs" Inherits="testimonial" %>
<%@import Namespace="System.Data" %>
<%@import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>My Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="bird"></div>
<div class="testiHeading">My Profile</div>

<div class="picContainer">
    <div id="Backpic">
        <asp:Image ID="Image1" runat="server" /></div>
    <div id="pic">
        <asp:Image ID="Image2" runat="server" /></div>
    <!--overlapFrame-->
    <div id="frame"></div>
</div>

<!--leftListContainer-->
<div class="RecieveScrapUSerlistContainer">
    <div class="userlistheading">Recieved Scraps </div>
    <div class="userList" id="ex3">
      

        <div id="linkdevider">
                     <div class="" id="usr" runat="server"> </div> 
            
        </div>
    </div>
</div>
<!--testimonialContainer--->
<div id="testimonial">
    <div class="innerHeading">
        <asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label></div>
    <div class="txtCOntainer" id="ex3">
        <asp:Label ID="lbldescription" runat="server" Text=""></asp:Label>
          <!-----senderName-->
          <div class="fromSnderName">-from-</div>
          <div class="fromSnderName1">
              <asp:Label ID="txtsendername" runat="server" Text=""></asp:Label> </div>
          <br /><br /><br /><br />
    </div>
    
</div>
<!--userlist---->
<div class="userlistFrame">
    <div class="userlistheading">Write for </div>
    <div class="userList" id="ex3">
        <div id="usernamehover">
           <%SqlConnection con1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=scrapbook;Integrated Security=True");
             SqlCommand cmd = new SqlCommand("select * from login where userid!='" + Session["userid"].ToString() + "' ORDER BY username", con1);
              SqlDataAdapter da = new SqlDataAdapter();
              da.SelectCommand = cmd;
              DataSet ds = new DataSet();
              da.Fill(ds, "login");
              foreach (DataRow dr in ds.Tables[0].Rows)
              { %>
              <%string pid, path, venue, date, id;
                pid = dr["userid"].ToString();

                path = dr["username"].ToString();%>
            <div class="username"><a href="writetscrap.aspx?uid=<%=pid %>&uname=<%=path %>"><%=path%></a></div><%} %>
           
        </div>
    </div>
</div>
</asp:Content>

