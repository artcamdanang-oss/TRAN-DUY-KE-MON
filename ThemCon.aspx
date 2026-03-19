<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ThemCon.aspx.cs" Inherits="SoanPha.ThemCon" %>
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
        <h1>Thêm hồ sơ là con của thành viên đang xem</h1>
        <table>
            <tr>
                <td style="width:109px"><strong>HỌ VÀ TÊN</strong></td>
                <td style="width:17px">:</td>
                <td ><asp:TextBox ID="txtHoTen" runat="server"  Width="100%" Height="30px" BackColor="#CCFFFF" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgaySinh" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Con Thứ</td>
                <td>:</td>
                <td><asp:TextBox ID="txtConThu" runat="server"  Width="50px" Height="30px" BackColor="#6699FF" ReadOnly="True" Font-Size="Large"></asp:TextBox>&nbsp;
                    Quan hệ : <asp:DropDownList ID="cboLoaiCon" runat="server" Font-Size="Medium">
                        <asp:ListItem Value="0" Selected="True">Con ruột</asp:ListItem>
                        <asp:ListItem Value="1">Con nuôi</asp:ListItem>
                        <asp:ListItem Value="2">Con riêng (bố)</asp:ListItem>
                        <asp:ListItem Value="3">Con riêng (mẹ)</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>Giới Tính</td>
                <td>:</td>
                <td><asp:DropDownList ID="cboGioiTinh" runat="server" Width="100%" Font-Size="Large">
                        <asp:ListItem Value="0" Selected="True">Nam</asp:ListItem>
                        <asp:ListItem Value="1">Nữ</asp:ListItem>
                        <asp:ListItem Value="2">Không Rõ</asp:ListItem>
                    </asp:DropDownList></td>         
            </tr>
            <tr>
                <td>Nơi Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNoiSinh" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>         
            </tr>
            <tr>
                <td>Địa Chỉ</td>
                <td>:</td>
                <td><asp:TextBox ID="txtDiaChi" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>         
            </tr>
            <tr>
                <td colspan="3"><strong>THÔNG TIN VỀ BỐ MẸ</strong></td>
            </tr>
            <tr>
                <td colspan="3">Họ Tên Bố : <asp:TextBox ID="txtHoTenBo" runat="server" ReadOnly="true" BackColor="#6699FF" Height="30px" Font-Size="Large"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                - Họ Tên Mẹ : <asp:TextBox ID="txtHoTenMe" runat="server" ReadOnly="true" BackColor="#6699FF" Height="30px" Font-Size="Large"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" ><strong>THÔNG TIN VỀ VỢ CHỒNG</strong></td>                
            </tr>
            <tr>
                <td>Vợ / Chồng</td>
                <td>:</td>
                <td><asp:TextBox ID="txtHoTenVC" runat="server"  Width="100%" Height="30px" BackColor="#CCFFFF" Font-Size="Large"></asp:TextBox></td>
            </tr> 
            <tr> 
                <td>Thứ Tự V/C</td>
                <td>:</td>
                <td><asp:TextBox ID="txtThuTuVC" runat="server" Text="1" BackColor="#6699FF" Width="60px" Height="30px" ReadOnly="True" Font-Size="Large"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkDaLyHon" runat="server" Text="Đã ly hôn" BorderStyle="None" Height="22px" /></td>
            </tr>        
            <tr>
                <td>Nơi Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNoiSinhVC" runat="server"  Width="100%" Height="30px" Font-Size="Large"></asp:TextBox></td>         
            </tr>    
            <tr>
                <td colspan="3" ><asp:Button ID="cmdGhi1" runat="server" Text="Ghi thông tin hồ sơ" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn ghi thông tin hồ sơ không?')" Width="402px" OnClick="cmdGhi_Click" /></td>
            </tr>
        </table>     
    </div>
</asp:Content>
