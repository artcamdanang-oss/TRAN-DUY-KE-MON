
<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TTVoChong.aspx.cs" Inherits="SoanPha.TTVoChong" %>
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
        <h1>Cập nhật thứ tự vợ/chồng trong gia đình</h1>
        <asp:Button ID="cmdGhi" runat="server" Text="Ghi thứ tự vợ/chồng" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn ghi thông tin không?')" Width="402px" OnClick="cmdGhi_Click"/>
        <table>
            <tr>
                <td style="width:109px"><strong>HỌ VÀ TÊN</strong></td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtHoTen" runat="server"  Width="100%" BackColor="#6699FF" ReadOnly="true" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" ><strong>THÔNG TIN VỀ VỢ/CHỒNG</strong></td>
            </tr>
        </table>
        <table>
            <tr>
                <td><strong>Họ tên</strong></td>
                <td><strong>Thứ tự cũ</strong></td>
                <td><strong>Thứ tự mới</strong></td>
            </tr>
            <asp:Repeater ID="rpThuTu" runat="server">
                <ItemTemplate>
                    <tr>
                    <td><%#Eval("HoTenVoChong") %></td>
                    <td><%#Eval("ThuTuVoChong") %></td>
                    <td><input type="text" name="txt<%#Eval("ThuTuVoChong") %>" value="<%#Eval("ThuTuVoChong") %>" style="background-color:  #CCFFFF; font-size: 14px"> </input></td>
                    <tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        
    </div>
</asp:Content>
