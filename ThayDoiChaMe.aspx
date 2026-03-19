<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ThayDoiChaMe.aspx.cs" Inherits="SoanPha.ThayDoiChaMe" %>
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
                <td style="width:109px"><strong>Tìm cha mẹ </strong></td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtHoTenTim" runat="server"  Width="350px" Height="30px" BackColor="#CCFFFF" Font-Size="Medium"></asp:TextBox>&nbsp; <asp:Button ID="cmdTimKiem" runat="server" Text="Tìm kiếm" Height="34px" Font-Bold="True" Font-Size="Medium" OnClick="cmdTimKiem_Click" /></td>
            </tr>
        </table> 
        
        <table>
            <tr>
                <td><strong>Họ Tên</strong></td>
                <td style="width:100px"><strong>Ngày Sinh</strong></td>
                <td style="width:80px"><strong>Con Thứ</strong></td>
                <td style="width:200px"><strong>Vợ / Chồng</strong></td>
                <td style="width:80px"><strong>Thứ Tự</strong></td>
                <td style="width:100px"><strong>Cập nhật</strong></td>
            </tr>
            <asp:Repeater ID="rpKetQua" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("HoTen") %></td>
                        <td><%#Eval("NgaySinh") %></td>
                        <td><%#Eval("ConThu") %></td>
                        <td><%#Eval("HoTenVoChong") %></td>
                        <td><%#Eval("ThuTuVoChong") %></td>
                        <td><a href="CapNhatChaMe.aspx?MaHoSo=<%=Request["MaHoSo"]%>&MaBoMe=<%#Eval("MaHoSo") %>">Lựa chọn</td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>         
    </div>
</asp:Content>
