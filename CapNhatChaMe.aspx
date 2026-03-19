<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CapNhatChaMe.aspx.cs" Inherits="SoanPha.CapNhatChaMe" %>
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
        <h1>Cập nhật lại cha mẹ cho thành viên đang chọn</h1>
        <table>
            <tr>
                <td style="width:109px"><strong>HỌ VÀ TÊN</strong></td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtHoTen" runat="server"  Width="100%" Height="30px" BackColor="#6699FF" ReadOnly="true" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3"><strong>THÔNG TIN CHA MẸ MỚI</strong></td>
            </tr>
            <tr>
                <td style="width:109px"><strong>HỌ TÊN CHA</strong></td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtHoTenCha" runat="server"  Width="100%" Height="30px" BackColor="#6699FF" ReadOnly="true" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width:109px"><strong>HỌ TÊN MẸ</strong></td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtHoTenMe" runat="server"  Width="100%" Height="30px" BackColor="#6699FF" ReadOnly="true" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblThongBao" runat="server" ForeColor="#333399"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3"><asp:Button ID="cmdGhi" runat="server" Text="Ghi thay đổi" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn thay đổi cha mẹ cho hồ sơ không?')" OnClick="cmdGhi_Click"/></td>
            </tr>
        </table> 
    </div>
</asp:Content>
