<%@ Page Title="" Language="C#" MasterPageFile="~/login.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>login | Scrapbook</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div id="registerUSer">
                    <div class="respective">Login Here</div>
                    <table width="100%">
                    <tr><td>
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Email" class="textClass"></asp:TextBox>
                        </td></tr>
                    <tr><td><asp:TextBox ID="TextBox2" runat="server" placeholder="Password" 
                            class="textClass" TextMode="Password"></asp:TextBox>
                    </td></tr>
                   
                    <tr><td>
                        <asp:Button ID="btnlogin" runat="server" Text="Login" class="btn" 
                            onclick="btnlogin_Click" />
                        </td></tr>
                    <tr><td>
                        <asp:Button ID="btnregister" runat="server" Text="Click Here to Register" 
                            class="btn" onclick="btnregister_Click" />
                    </td></tr>
                                            
                    </table>
            </div>
</asp:Content>

