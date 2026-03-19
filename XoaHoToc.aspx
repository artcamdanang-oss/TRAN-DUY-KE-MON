<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="XoaHoToc.aspx.cs" Inherits="SoanPha.XoaHoToc" %>
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
        <h1>Xác nhận xóa bỏ họ tộc</h1>
        <p><span class="auto-style1"><strong>Bạn đã chắc chắn muốn xóa họ tộc, khi xóa bỏ thì mọi thông tin về họ tộc sẽ không thể khôi phục lại được?</strong></span></p>
        <asp:Button ID="cmdXoa" runat="server" Text="Chấp nhận xóa họ tộc" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có chắc chắc muốn xóa họ tộc không?')" OnClick="cmdXoa_Click" />
        <table>
        <asp:Repeater ID="rpHoToc" runat="server">
            <ItemTemplate>
                <tr>
                    <td style="width:109px"><strong>Mã họ tộc</strong></td>
                    <td style="width:17px">:</td>
                    <td><%#Eval("MaHoToc") %></td>
                </tr>
                <tr>
                    <td><strong>Họ tộc</strong></td>
                    <td>:</td>
                    <td><%#Eval("TenHoToc") %></td>
                </tr>
                <tr>
                    <td>Thủy tổ (ông)</td>
                    <td>:</td>
                    <td><%#Eval("TenToOng") %></td>
                </tr>
                <tr>
                    <td>Ngày giỗ</td>
                    <td>:</td>
                    <td><%#Eval("GioToOng") %></td>
                </tr>
                <tr>
                    <td>Thủy tổ (bà)</td>
                    <td>:</td>
                    <td><%#Eval("TenToBa") %></td>
                </tr>
                <tr>
                    <td>Ngày giỗ</td>
                    <td>:</td>
                    <td><%#Eval("GioToBa") %></td>
                </tr>
                <tr>
                    <td>Ghi chú</td>
                    <td>:</td>
                    <td><%#Eval("GhiChuHoToc") %></td>
                </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
