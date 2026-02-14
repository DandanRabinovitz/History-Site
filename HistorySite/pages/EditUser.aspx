<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="HistorySite.pages.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1 style="text-align:center">Edit User - UpdateCommand</h1>
    <table align="center">
        <tr>
            <td>Password</td>
            <td>
                <input type="text" name="password" id="password" runat="server"/>
            </td>
            <td>
                <div id="passwordAlert" class="alert"></div>
            </td>
        </tr>
        <tr>
            <td>
                first Name:
            </td>
            <td>
                <input type="text" name="firstName" id="firstName" runat="server"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>
                Last Name:
            </td>
            <td>
                <input type="text" name="lastName" id="lastName" runat="server"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>birthday</td>
            <td>
                <input type="date" name="birthday" id="birthday" runat="server" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <input type="text" name="city" id="city" runat="server"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
    <td>
        Country:
    </td>
    <td>
        <input type="text" name="country" id="country" runat="server"/>
    </td>
    <td>
        <div></div>
    </td>
</tr>
        <tr>
            <td>
                admin:
            </td>
            <td>
                <input type="checkbox" name="admin" id="admin" runat="server"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>
                <input type="button" name="Update" id="Update" runat="server" value ="Update" onserverclick ="UpdateUser" />
            </td>
            <td>
                <input type="reset" name="reset" />
            </td>
            <td></td>
        </tr>
        </table>

    <div runat="server" id="message"></div>
</asp:Content>
