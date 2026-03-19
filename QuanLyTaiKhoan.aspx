<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="QuanLyTaiKhoan.aspx.cs" Inherits="SoanPha.QuanLyTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ndcontent">
    <%
        if ((Boolean)Session["login"] == false || !Session["type"].ToString().ToUpper().Equals("ADMIN"))
        {
            Response.Redirect("default.aspx");
        }
    %>
    <h1>Quản lý tài khoản đăng nhập</h1>
    <table>
        <tr>
            <td>Tên đăng nhập</td>
            <td>Họ và tên</td>
            <td>Ghi chú</td>
            <td colspan="2"><a href="CapNhatTaiKhoan.aspx?ID=0&&TenDN=NULL>" target="_blank"> Thêm tài khoản mới</a></td>                
        </tr>
        <asp:ListView ID="lvTaiKhoan" runat="server">
        <ItemTemplate>
            <tr>
                <td><%#Eval("TenDN") %></td>
                <td><%#Eval("HoTen") %></td>
                <td><%#Eval("GhiChu") %></td>
                <td><a href="CapNhatTaiKhoan.aspx?ID=1&&TenDN=<%#Eval("TenDN") %>" target="_blank">Cập nhật</a></td>
                <td><a href="XoaTaiKhoan.aspx?TenDN=<%#Eval("TenDN") %>" target="_blank">Xóa tài khoản</a></td>
             </tr>
         </ItemTemplate>
         </asp:ListView>
    </table>
    </div>
</asp:Content>
