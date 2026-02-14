<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HistorySite.pages.Register1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../JS/Validate.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Register</h1>
    <table align="center">
        <tr>
            <td>
                User Name:
            </td>
            <td>
                <input type="text" name="userName" id="userName" />
            </td>
            <td>
                <div id="userNameAlert" class="alert" runat="server"></div>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <input type="password" name="password" id="password"/>
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
                <input type="text" name="firstName" id="firstName"/>
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
                <input type="text" name="lastName" id="lastName"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>birthday</td>
            <td>
                <input type="date" name="birthday" id = "birthday"/>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <input type="text" name="city" id="city"/>
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
                <input type="text" name="city" id="country"/>
            </td>
            <td>
                <div></div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button 
    ID="btnSubmit" 
    runat="server" 
    Text="Submit" 
    OnClientClick="return Validate();" 
     />

            </td>
            <td>
                <input type="reset" name="reset" />
            </td>
            <td></td>
        </tr>
        </table>
</asp:Content>
