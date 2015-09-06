<%@ Page Title="" Language="C#" MasterPageFile="~/afterlogin.master" AutoEventWireup="true" CodeFile="uploadpic.aspx.cs" Inherits="uploadpic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="bird"></div>
    <div class="testiHeading"> Profile Pic</div>
    <div id="testimonial">
     <div id="UplodPIc">
         <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
             <asp:Image ID="Image1" runat="server" Height="80px" Width="80px" /> <br /> 
             <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn1" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
             ControlToValidate="FileUpload1" Display="Dynamic" 
             ErrorMessage="Browse your file">*</asp:RequiredFieldValidator>
         <br />
             <asp:Button ID="btnsubmit" runat="server" Text="Upload" CssClass="btn1" 
                 onclick="btnsubmit_Click" />      
         <br />
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
             ShowMessageBox="True" ShowSummary="False" />
        </div>
    </div>

</asp:Content>

