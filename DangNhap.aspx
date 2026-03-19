<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="SoanPha.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ndcontent">
        <h1>Đăng nhập hệ thống</h1>
        <br />
        <table>
            <tr>
                <td style="text-align: right; width: 150px">
                    <h4>Tên đăng nhập : </h4>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTenDN" Width="100%" Height="35px" Text="ad" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 150px">
                    <h4>Mật khẩu : </h4>
                </td>
                <td>
                    <asp:TextBox ID="txtMatKhau" TextMode="Password" autocomplete="new-password" runat="server" Width="100%" Height="35px" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="cmdDangNhap" runat="server" Text="Đăng Nhập" Height="34px" Width="139px" Font-Bold="True" Font-Size="Medium" OnClick="cmdDangNhap_Click" />
                    <h4>
                        <asp:Label ID="lblThongBao" runat="server" ForeColor="#CC0000"></asp:Label></h4>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
