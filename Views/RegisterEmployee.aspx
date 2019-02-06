<%@ Page Title="RegisterEmployee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="RegisterEmployee.aspx.cs" Inherits="RegisterEmployee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register employees.</h2>

    <div class="row">
        <div class="col-md-4">
            <table style="width: 800px; margin-top: 50px;">
                <tr>
                    <td nowrap="nowrap">
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium" ID="lblName" Text="Employee name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium" ID="lblLastName" Text="Employee lastName"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium" ID="LblContract" Text="Contract type"></asp:Label>
                    </td>
                    <td>
                       <asp:DropDownList ID="cmbContractType" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium" ID="LblHourlySalary" Text="Hourly salary"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBoxHourlySalary" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium" ID="LblMonthlySalary" Text="Monthly salary"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtBoxMonthlySalary" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnCheckRegister" Text="Register" />
                    </td>
                </tr>
        </table>
            <table style="width: 800px; margin-top: 50px;">
                <tr>
                    <td nowrap="nowrap">
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" ID="lblResponse"></asp:Label>
                     </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>