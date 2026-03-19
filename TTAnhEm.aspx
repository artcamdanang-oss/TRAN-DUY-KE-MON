<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TTAnhEm.aspx.cs" Inherits="SoanPha.TTAnhEm" %>
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
        <h1>Cập nhật thứ tự anh chị em trong gia đình</h1>
        <asp:Button ID="cmdGhi" runat="server" Text="Ghi thứ tự anh chị em" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn ghi thông tin không?')" Width="402px" OnClick="cmdGhi_Click"/>
        
        <table>
            <tr>
                <td><strong>Họ Tên</strong></td>
                <td><strong>Thứ tự cũ</strong></td>
                <td><strong>Thứ tự mới</strong></td>
            </tr>
            <asp:Repeater ID="rpThuTu" runat="server">
                <ItemTemplate>
                    <tr>
                    <td><%#Eval("HoTen") %></td>
                    <td><%#Eval("ConThu") %></td>
                    <td><input type="text" name="txt<%#Eval("ConThu") %>" value="<%#Eval("ConThu") %>" style="background-color:  #CCFFFF; font-size:14px"> </input></td>
                    <tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        
    </div>
</asp:Content>
