<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ThemHoSo.aspx.cs" Inherits="SoanPha.ThemHoSo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
    <script  type="text/javascript">
        function resizeTextBox(txt) {
            if (window.event.keyCode == 13) {
                txt.style.height = "1px";
                txt.style.height = (1 + txt.scrollHeight) + "px";
            }
        }
    </script>
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
        <asp:Button ID="cmdGhi" runat="server" Text="Ghi thông tin hồ sơ" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn ghi thông tin hồ sơ không?')" Width="402px" OnClick="cmdGhi_Click" />
        <table>
            <tr>
                <td style="width:109px"><strong>HỌ VÀ TÊN</strong></td>
                <td style="width:17px">:</td>
                <td colspan="4"><asp:TextBox ID="txtHoTen" runat="server"  Width="100%" BackColor="#CCFFFF" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width:109px">Thường Gọi</td>
                <td style="width:17px">:</td>
                <td style="width:370px"><asp:TextBox ID="txtThuongGoi" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td style="width:109px">Tên Hiệu</td>
                <td style="width:17px">:</td>
                <td><asp:TextBox ID="txtTenHieu" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgaySinh" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Con Thứ</td>
                <td>:</td>
                <td><asp:TextBox ID="txtConThu" runat="server"  Width="40px" BackColor="#6699FF" ReadOnly="True" Font-Size="Medium"></asp:TextBox>&nbsp;
                    Quan hệ : <asp:DropDownList ID="cboLoaiCon" runat="server" Font-Size="Medium">
                        <asp:ListItem Value="0"  Selected="True">Con ruột</asp:ListItem>
                        <asp:ListItem Value="1">Con nuôi</asp:ListItem>
                        <asp:ListItem Value="2">Con riêng (bố)</asp:ListItem>
                        <asp:ListItem Value="3">Con riêng (mẹ)</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Giới Tính</td>
                <td>:</td>
                <td><asp:DropDownList ID="cboGioiTinh" runat="server" Width="100%" Font-Size="Medium">
                        <asp:ListItem Value="0" Selected="True">Nam</asp:ListItem>
                        <asp:ListItem Value="1">Nữ</asp:ListItem>
                        <asp:ListItem Value="2">Không Rõ</asp:ListItem>
                    </asp:DropDownList></td>
                <td>Số CMTND</td>
                <td>:</td>
                <td><asp:TextBox ID="txtCMTND" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Điện Thoại</td>
                <td>:</td>
                <td><asp:TextBox ID="txtDienThoai" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Số Hộ Chiếu</td>
                <td>:</td>
                <td><asp:TextBox ID="txtHoChieu" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email</td>
                <td>:</td>
                <td><asp:TextBox ID="txtEmail" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Quốc Tịch</td>
                <td>:</td>
                <td><asp:TextBox ID="txtQuocTich" runat="server" Width="100%" Text="Việt Nam" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nơi Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNoiSinh" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Dân tộc</td>
                <td>:</td>
                <td><asp:TextBox ID="txtDanToc" runat="server" Width="100%" Text="Kinh" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nơi Ở Hiện Tại</td>
                <td>:</td>
                <td><asp:TextBox ID="txtDiaChi" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Tôn giáo</td>
                <td>:</td>
                <td><asp:TextBox ID="txtTonGiao" runat="server" Width="100%" Text="Không" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" ><strong>THÔNG TIN VỀ NGÀY MẤT VÀ NƠI AN TÁNG</strong></td>
            </tr>
            <tr>
                <td class="auto-style1">Dương Lịch</td>
                <td class="auto-style1">:</td>
                <td class="auto-style1"><asp:TextBox ID="txtNgayMatDL" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td class="auto-style1">Âm Lịch</td>
                <td class="auto-style1">:</td>
                <td class="auto-style1"><asp:TextBox ID="txtNgayMatAL" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nơi An Táng</td>
                <td>:</td>
                <td colspan="4"><asp:TextBox ID="txtNoiAnTang" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>     
            <tr>
                <td colspan="6"><strong>THÔNG TIN VỀ BỐ MẸ</strong></td>
            </tr>
            <tr>
                <td>Họ Tên Bố</td>
                <td>:</td>
                <td><asp:TextBox ID="txtHoTenBo" runat="server" ReadOnly="true" Width="100%" BackColor="#6699FF" Font-Size="Medium"></asp:TextBox></td>
                <td>Họ Tên Mẹ</td>
                <td>:</td>
                <td><asp:TextBox ID="txtHoTenMe" runat="server" ReadOnly="true" Width="100%" BackColor="#6699FF" Font-Size="Medium"></asp:TextBox></td>
            </tr>

            <tr>
                <td colspan="6" ><strong>THÔNG TIN VỀ VỢ CHỒNG</strong></td>                
            </tr>
            <tr>
                <td>Vợ / Chồng</td>
                <td>:</td>
                <td><asp:TextBox ID="txtHoTenVC" runat="server"  Width="100%" BackColor="#CCFFFF"></asp:TextBox></td>
                <td>Thứ Tự V/C</td>
                <td>:</td>
                <td><asp:TextBox ID="txtThuTuVC" runat="server" Text="1" BackColor="#6699FF" Width="60px" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkDaLyHon" runat="server" Text="Đã ly hôn" BorderStyle="None" Height="22px" /></td>
            </tr>
            <tr>
                <td>Ngày Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgaySinhVC" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Điện Thoại</td>
                <td>:</td>
                <td><asp:TextBox ID="txtDienThoaiVC" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nơi Sinh</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNoiSinhVC" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Email</td>
                <td>:</td>
                <td><asp:TextBox ID="txtEmailVC" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày Mất DL</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgayMatDLVC" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Ngày Mất ÂL</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgayMatALVC" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td >Nơi An Táng</td>
                <td>:</td>
                <td colspan="4"><asp:TextBox ID="txtNoiAnTangVC" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" ><strong>THÔNG TIN GHI CHÚ THÊM</strong></td>
            </tr>
            <tr>
                <td colspan="6"><asp:TextBox ID="txtGhiChu" runat="server" Width="100%" TextMode="MultiLine" Rows="7" Font-Size="Medium"  onkeyup="resizeTextBox(this)" Height="92px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" ><asp:Button ID="cmdGhi1" runat="server" Text="Ghi thông tin hồ sơ" Height="34px" Font-Bold="True" Font-Size="Medium" OnClientClick="return MSGBOX('Bạn có muốn ghi thông tin hồ sơ không?')" Width="402px" OnClick="cmdGhi_Click" /></td>
            </tr>
        </table>     
    </div>
</asp:Content>
