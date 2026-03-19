<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ThemVoChong.aspx.cs" Inherits="SoanPha.ThemVoChong" %>
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
        <h1>Thêm hồ sơ vợ/chồng cho thành viên đang chọn</h1>
        <asp:Button ID="cmdGhi" runat="server" Text="Ghi hồ sơ vợ/chồng" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn ghi hồ sơ vợ/chồng không?')" OnClick="cmdGhi_Click" />
        <table>
            <tr>
                <td style="width:109px"><strong>HỌ VÀ TÊN</strong></td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtHoTen" runat="server"  Width="100%" Height="30px" BackColor="#6699FF" ReadOnly="true" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" ><strong>THÔNG TIN VỀ VỢ CHỒNG</strong></td>
            </tr>
            <tr>
                <td style="width:109px">Vợ / Chồng</td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtHoTenVC" runat="server"  Width="100%" Height="30px" BackColor="#CCFFFF" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Thứ Tự V/C</td>
                <td>:</td>
                <td><asp:TextBox ID="txtThuTuVC" runat="server" Text="1" BackColor="#6699FF" Width="60px" Height="30px" ReadOnly="True" Font-Size="Large"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkDaLyHon" runat="server" Text="Đã ly hôn" BorderStyle="None" Height="22px" /></td>
            </tr>
            <tr>
                <td>Ngày Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgaySinhVC" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Điện Thoại</td>
                <td>:</td>
                <td><asp:TextBox ID="txtDienThoaiVC" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nơi Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNoiSinhVC" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>    
                <td>Email</td>
                <td>:</td>
                <td><asp:TextBox ID="txtEmailVC" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày Mất DL</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgayMatDLVC" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>    
                <td>Ngày Mất ÂL</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgayMatALVC" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td >Nơi An Táng</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNoiAnTangVC" runat="server"  Width="100%" Height="30px" Font-Size="Medium"></asp:TextBox></td>
            </tr>
        </table>     
    </div>
</asp:Content>
