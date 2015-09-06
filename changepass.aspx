<%@ Page Title="" Language="C#" MasterPageFile="~/afterlogin.master" AutoEventWireup="true" CodeFile="changepass.aspx.cs" Inherits="changepass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="bird"></div>
    <div class="testiHeading"> Change Password</div>
    <div id="testimonial">
        <div class="chngpss">
              <asp:TextBox ID="txtoldpassword" runat="server" placeholder="Old Password"  
                  CssClass="formTextBox" TextMode="Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  Display="Dynamic" ErrorMessage="Old Should not be blank" 
                  ControlToValidate="txtoldpassword">*</asp:RequiredFieldValidator>
              <br />
              <asp:TextBox ID="txtnewpass" runat="server" placeholder="New Password"  
                  CssClass="formTextBox" TextMode="Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  Display="Dynamic" ErrorMessage="New Password Should not be blank" 
                  ControlToValidate="txtnewpass">*</asp:RequiredFieldValidator>
              <br />
              <asp:TextBox ID="txtconfirmpass" runat="server" placeholder="Confirm Password"  
                  CssClass="formTextBox" TextMode="Password" >
                  </asp:TextBox>
              
              <asp:CompareValidator ID="CompareValidator1" runat="server" 
                  ControlToCompare="txtnewpass" ControlToValidate="txtconfirmpass" 
                  Display="Dynamic" ErrorMessage="New and Confirm password do not match">*</asp:CompareValidator>
              
              <br />
              <asp:Button ID="btnchangepass" runat="server" Text="Change Password"  
                  CssClass="btn" onclick="btnchangepass_Click"/>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                  ShowMessageBox="True" ShowSummary="False" />
        </div>
    </div>
</asp:Content>

