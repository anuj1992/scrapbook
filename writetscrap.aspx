<%@ Page Title="" Language="C#" MasterPageFile="~/afterlogin.master" AutoEventWireup="true" CodeFile="writetscrap.aspx.cs" Inherits="writetscrap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="bird"></div>
<div class="userName">Write for <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </div>
<div class="picContainer">
    <div id="Backpic">
        <asp:Image ID="Image1" runat="server" /></div>
    <div id="pic">
        <asp:Image ID="Image2" runat="server" /></div>
    <!--overlapFrame-->
    <div id="frame"></div>
</div>

<div id="testimonial">
    <div class="innerHeading">
             <asp:TextBox ID="txttitle" runat="server" CssClass="formTextBox" placeholder="Give him/her tittle"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 ControlToValidate="txttitle" Display="Dynamic" 
                 ErrorMessage="Title Should not be blank">*</asp:RequiredFieldValidator>
    </div>
    <div class="txtCOntainer" id="ex3">
        <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" CssClass="multi" placeholder="About him/her...."></asp:TextBox>
        
          
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtdescription" Display="Dynamic" 
            ErrorMessage="Description for the person is not provided">*</asp:RequiredFieldValidator>
        
          
    </div>
    <asp:Button ID="btnsubmit" runat="server" Text="Submit Post" CssClass="btn1" 
        onclick="btnsubmit_Click"/>
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
</div>

</asp:Content>

