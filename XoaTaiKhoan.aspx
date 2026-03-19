<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="XoaTaiKhoan.aspx.cs" Inherits="SoanPha.XoaTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ndcontent">
    <%
        if ((Boolean)Session["login"] == false)
        {
            Response.Redirect("default.aspx");
        }
    %>
        <h1>Xác nhận xóa bỏ tài khoản</h1>
        <p><span class="auto-style1"><strong>Bạn đã chắc chắn muốn xóa tài khoản, khi xóa thì tài khoản sẽ không thể khôi phục lại được?</strong></span></p>
        <asp:Button ID="cmdXoa" runat="server" Text="Chấp nhận xóa tài khoản" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có chắc chắc muốn xóa tài khoản không?')" OnClick="cmdXoa_Click" />
        <table>
        <asp:Repeater ID="rpTaiKhoan" runat="server">
            <ItemTemplate>
                <tr>
                    <td style="width:120px"><strong>Tên đăng nhập</strong></td>
                    <td style="width:17px">:</td>
                    <td><%#Eval("TenDN") %></td>
                </tr>
                <tr>
                    <td><strong>Họ và tên</strong></td>
                    <td>:</td>
                    <td><%#Eval("HoTen") %></td>
                </tr>
                <tr>
                    <td>Ghi chú</td>
                    <td>:</td>
                    <td><%#Eval("GhiChu") %></td>
                </tr>                
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
