<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="QLHoToc.aspx.cs" Inherits="SoanPha.QLHoToc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ndcontent">
    <%
        if ((Boolean)Session["login"] == false)
        {
            Response.Redirect("default.aspx");
        }
    %>
        <h1>Quản lý thông tin chi tiết họ tộc</h1>        
        <asp:Button ID="cmdGhi" runat="server" Text="Ghi thông tin họ tộc" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn ghi thông tin họ tộc không?')" OnClick="cmdGhi_Click" />
        <table>
            <tr>
                <td style="width:109px"><strong>Mã họ tộc</strong></td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtMaHoToc" runat="server"  Width="100%" Height="30px" BackColor="#6699FF" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Họ tộc</strong></td>
                <td>:</td>
                <td><asp:TextBox ID="txtTenHoToc" runat="server"  Width="100%" Height="30px" BackColor="#6699FF" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Đời thứ</td>
                <td>:</td>
                <td><asp:TextBox ID="txtDoiThu" runat="server"  Width="100%" Height="30px" Text="1" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Chia sẻ</td>
                <td>:</td>
                <td><asp:DropDownList ID="cboChiaSe" runat="server" Font-Size="Large" Width="100%"  >
                        <asp:ListItem Value="0"  Selected="True">Công khai (public)</asp:ListItem>
                        <asp:ListItem Value="1">Riêng tư (private)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Thủy tổ (ông)</td>
                <td>:</td>
                <td><asp:TextBox ID="txtToOng" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày giỗ</td>
                <td>:</td>
                <td><asp:TextBox ID="txtGioOng" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Thủy tổ (bà)</td>
                <td>:</td>
                <td><asp:TextBox ID="txtToBa" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày giỗ</td>
                <td>:</td>
                <td><asp:TextBox ID="txtGioBa" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ghi chú</td>
                <td>:</td>
                <td><asp:TextBox ID="txtGhiChu" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
        </table>
    </div>
</asp:Content>
