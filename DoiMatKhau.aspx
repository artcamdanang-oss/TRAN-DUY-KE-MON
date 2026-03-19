<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="SoanPha.DoiMatKhau" %>
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
        <h1>Thay đổi mật khẩu đăng nhập</h1>
        <table>
            <tr>
                <td style="width:109px"><strong>HỌ VÀ TÊN</strong></td>
                <td style="width:17px">:</td>
                <td ><asp:TextBox ID="txtHoTen" runat="server" Width="100%" Height="30px"  BackColor="#6699FF" ReadOnly="True" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>TÀI KHOẢN</strong></td>
                <td>:</td>
                <td ><asp:TextBox ID="txtTaiKhoan" autocomplete="new-password" runat="server"  Width="100%" Height="30px"  BackColor="#6699FF" ReadOnly="True" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nhập mật khẩu</td>
                <td>:</td>
                <td><asp:TextBox ID="txtMatKhau" TextMode="Password" autocomplete="new-password" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Mật khẩu mới</td>
                <td>:</td>
                <td><asp:TextBox ID="txtMatKhauMoi1" TextMode="Password" autocomplete="new-password" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nhập lại</td>
                <td>:</td>
                <td><asp:TextBox ID="txtMatKhauMoi2" TextMode="Password" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>
            </tr>  
            <tr>
                <td colspan="3" ><asp:Button ID="cmdGhi" runat="server" Text="Ghi mật khẩu" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn muốn kiểm tra và ghi mật khẩu mới không?')" Width="402px" OnClick="cmdGhi_Click" /></td>
            </tr>
        </table>  
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label>   
    </div>
</asp:Content>
