<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Serialize object.</h2>

    <div class="row">
        <div class="col-md-4">
            <table style="width: 800px; margin-top: 50px;">
                <tr>
                    <td>
                        <asp:TextBox ID="txtResult" runat="server" MaxLength="35" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" ID="btnSerialize" Text="Generate serialization" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" ID="lblResponse"></asp:Label>
                     </td>
                </tr>
        </table>
        </div>
    </div>
</asp:Content>
