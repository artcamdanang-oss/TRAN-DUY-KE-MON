<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CapNhatTaiKhoan.aspx.cs" Inherits="SoanPha.CapNhatTaiKhoan" %>
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
        <h1>Quản lý thông tin tài khoản đăng nhập</h1>        
        <asp:Button ID="cmdGhi" runat="server" Text="Ghi tài khoản" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn ghi thông tin tài khoản không?')" OnClick="cmdGhi_Click"/>
        <table>
            <tr>
                <td style="width:130px"><strong>Tên đăng nhập</strong></td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtTenDN" runat="server"  Width="100%" Height="30px" BackColor="#6699FF" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Họ và tên</strong></td>
                <td>:</td>
                <td><asp:TextBox ID="txtHoTen" runat="server"  Width="100%" Height="30px" BackColor="#6699FF" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Mật khẩu</td>
                <td>:</td>
                <td><asp:TextBox ID="txtMatKhau" TextMode="Password" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Loại tài khoản</td>
                <td>:</td>
                <td><asp:DropDownList ID="cboPhanQuyen" runat="server"  Width="100%"  Font-Size="Large">
                        <asp:ListItem Value="0">Chỉ xem (user)</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">Cập nhật (editer)</asp:ListItem>
                        <asp:ListItem Value="2">Quản trị (admin)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Ghi chú</td>
                <td>:</td>
                <td><asp:TextBox ID="txtGhiChu" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Họ tộc chọn : </td>
                <td>:</td>
                <td><asp:Label ID="lblHoToc" runat="server" Font-Size="Medium"></asp:Label></td>
            </tr>
            <tr>
                <td>Họ tộc</td>
                <td>:</td>
                <td><asp:CheckBoxList ID="chkDSHoToc" runat="server"></asp:CheckBoxList></td>
            </tr>
        </table>
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
