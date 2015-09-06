<%@ Page Title="" Language="C#" MasterPageFile="~/login.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Register | Scrapbook</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="registerUSer">
                    <div class="respective">Register Here</div>
                    <table width="100%">
                    <tr><td>
                        <asp:TextBox ID="txtcolgid" runat="server" placeholder="Your College ID"  class="textClass"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtcolgid" Display="Dynamic" 
                            ErrorMessage="College ID Should not be blank">*</asp:RequiredFieldValidator>
                    </td></tr>
                    <tr><td>
                        <asp:TextBox ID="txtemail" runat="server" placeholder="Email" class="textClass"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtemail" Display="Dynamic" 
                            ErrorMessage="Email-id Should not be blank">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtemail" Display="Dynamic" 
                            ErrorMessage="Email-id is  not in correct format" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                       </td></tr>
                    <tr><td>
                     
                          <asp:TextBox ID="txtnewpassword" runat="server" placeholder="New Password" 
                              class="textClass" TextMode="Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                              ControlToValidate="txtnewpassword" Display="Dynamic" 
                              ErrorMessage="New Password Should not be blank">*</asp:RequiredFieldValidator>
                   </td></tr>
                    <tr><td>
                        <asp:TextBox ID="txtconfirmpassword" runat="server" 
                            placeholder="Confirm Password" class="textClass" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="txtnewpassword" ControlToValidate="txtconfirmpassword" 
                            Display="Dynamic" ErrorMessage="Both Passwords do not match">*</asp:CompareValidator>
                    </td></tr>
                    <tr><td>
                        <asp:Button ID="Button2" runat="server" Text="Register" class="btn" 
                            onclick="Button2_Click" />
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" />
                      </td></tr>
                                            
                    </table>
            </div>
</asp:Content>

