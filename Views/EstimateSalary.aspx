<%@ Page Title="EstimateSalary" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="EstimateSalary.aspx.cs" Inherits="EstimateSalary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Estimate salary</h2>

    <div class="row">
        <div class="col-md-4">
            <table style="width: 1800px; margin-top: 50px;">
                <tr>
                    <td nowrap="nowrap">
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium" ID="lblUser" Text="Id Employee"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" MaxLength="35" Width="100"></asp:TextBox>
                    </td>                
                    <td>
                        <asp:Button runat="server" ID="btnInfoAPI" Text="Get employees from API" OnClick="btnInfoAPI_Click"/>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnListInfo" Text="Get employees from DB" OnClick="btnListInfo_Click" />
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

        <table style="width: 1800px; margin-top: 50px;" border="1">
            <tr>
                <asp:GridView ID="gvInfoEmployees" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText ="Id" />
                        <asp:BoundField DataField="Name" HeaderText ="Name" />
                        <asp:BoundField DataField="contractTypeName" HeaderText ="Contract"  ItemStyle-Width="200px"/>
                        <asp:BoundField DataField="hourlySalary" HeaderText ="Salary per hour" ItemStyle-Width="180px" ItemStyle-Wrap="true" />
                        <asp:BoundField DataField="monthlySalary" HeaderText ="Salary per month" ItemStyle-Width="180px" />
                        <asp:BoundField DataField="totalSalary" HeaderText="Salary per year" ItemStyle-Width="180px" />
                    </Columns>
                    </asp:GridView>
            </tr>
        </table>
        </div>
    </div>
</asp:Content>