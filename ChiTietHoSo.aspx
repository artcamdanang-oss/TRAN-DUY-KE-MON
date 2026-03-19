<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ChiTietHoSo.aspx.cs" Inherits="SoanPha.ChiTietHoSo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script  type="text/javascript">
        function resizeTextBox(txt) {
            if (window.event.keyCode == 13) {
                txt.style.height = "1px";
                txt.style.height = (1 + txt.scrollHeight) + "px";
            }
        }
        function resizeTextBox() {
            txt = document.getElementById("ContentPlaceHolder1_txtGhiChu");
            txt.style.height = "1px";
            txt.style.height = (1 + txt.scrollHeight) + "px";
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
        <h1>Chi tiết thông tin thành viên</h1>       
        <table>
            <tr>
                <td style="width:50%"><asp:Image ID="imgHoSo" runat="server" Height="186px" Width="142px" /></td>
                <td><asp:Image ID="imgVoChong" runat="server" Height="186px" Width="142px" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblHoTen" runat="server" style="font-weight: 700"></asp:Label>
                    <%
                        if (Session["type"].ToString().ToUpper().Equals("USER") == false)
                        { %>
                    &nbsp; <asp:FileUpload ID="upHinhAnh" runat="server" /><asp:Button ID="cmdUpHA" runat="server" Text="Upload" OnClick="cmdUpHA_Click" OnClientClick="return MSGBOX('Bạn có muốn ghi hình ảnh cho hồ sơ không?')" /><asp:Button ID="cmdDelHA" runat="server" Text="Delete"  OnClientClick="return MSGBOX('Bạn có muốn xóa hình ảnh cho hồ sơ không?')" OnClick="cmdDelHA_Click" />
                    <%} %>
                </td>
                <td><asp:Label ID="lblHoTenVoChong" runat="server" style="font-weight: 700"></asp:Label>
                    <%
                        if (Session["type"].ToString().ToUpper().Equals("USER") == false)
                        { %>
                    &nbsp; <asp:FileUpload ID="upHinhAnhVC" runat="server" /><asp:Button ID="cmdUpHAVC" runat="server" Text="Upload"  OnClientClick="return MSGBOX('Bạn có muốn ghi hình ảnh cho hồ sơ vợ chồng không?')" OnClick="cmdUpHAVC_Click" /><asp:Button ID="cmdDelHAVC" runat="server" Text="Delete"  OnClientClick="return MSGBOX('Bạn có muốn xóa hình ảnh cho hồ sơ vợ chồng không?')" OnClick="cmdDelHAVC_Click" />
                    <%} %>
                </td>
            </tr>
        </table> 
        <br/>
        <table>
            <tr>
                <td style="width:109px"><strong>HỌ VÀ TÊN</strong></td>
                <td style="width:17px">:</td>
                <td colspan="4"><asp:TextBox ID="txtHoTen" runat="server" Width="100%" BackColor="#CCFFFF" Font-Size="Medium"></asp:TextBox></td>
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
                <td><asp:TextBox ID="txtConThu" runat="server"  Width="40px" BackColor="#CCFFFF" Font-Size="Medium"></asp:TextBox>&nbsp;
                    Quan hệ : <asp:DropDownList ID="cboLoaiCon" runat="server">
                        <asp:ListItem Value="0"  Selected="True">Con ruột</asp:ListItem>
                        <asp:ListItem Value="1">Con nuôi</asp:ListItem>
                        <asp:ListItem Value="2">Con riêng (bố)</asp:ListItem>
                        <asp:ListItem Value="3">Con riêng (mẹ)</asp:ListItem>
                    </asp:DropDownList></td>
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
                <td>Dương Lịch</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgayMatDL" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
                <td>Âm Lịch</td>
                <td>:</td>
                <td><asp:TextBox ID="txtNgayMatAL" runat="server"  Width="100%" Font-Size="Medium"></asp:TextBox></td>
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
                <td><asp:TextBox ID="txtHoTenVC" runat="server"  Width="100%" BackColor="#CCFFFF" Font-Size="Medium"></asp:TextBox></td>
                <td>Thứ Tự V/C</td>
                <td>:</td>
                <td><asp:TextBox ID="txtThuTuVC" runat="server" Text="1" BackColor="#CCFFFF" Width="60px" Font-Size="Medium"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkDaLyHon" runat="server" Text="Đã ly hôn" BorderStyle="None" Height="22px" /></td>
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
                <td colspan="6"><asp:TextBox ID="txtGhiChu" runat="server" TextMode="MultiLine" Width="100%" ReadOnly="True" onkeyup="resizeTextBox(this)" Ondblclick="resizeTextBox()" Rows="5" Font-Size="Medium"></asp:TextBox>
                    <asp:HyperLink ID="note" runat="server" OnClick="resizeTextBox()" Font-Size="Smaller" ForeColor="#003399">Ấn Enter hoặc kích đúp vào ô dữ liệu để mở rộng khung</asp:HyperLink></td>
            </tr>
            <%
                if (Session["type"].ToString().ToUpper().Equals("USER") == false)
                { %>
            <tr>
                <td colspan="6" >
                    <asp:Button ID="cmdGhi" runat="server" Text="Ghi thông tin" Height="34px" Font-Bold="True" Font-Size="Medium" OnClick="cmdGhi_Click1" OnClientClick="return MSGBOX('Bạn có muốn ghi thông tin hồ sơ không?')" />                    
                    <asp:Button ID="cmdThemCon" runat="server" Text="Thêm con (full)" Height="34px" Font-Size="Medium" OnClick="cmdThemCon_Click" OnClientClick="target ='_blank';"/>
                    <asp:Button ID="cmdThem" runat="server" Text="Thêm con" Height="34px" Font-Size="Medium" OnClientClick="target ='_blank';" OnClick="cmdThem_Click"/>
                    <asp:Button ID="cmdThemVoChong" runat="server" Text="Thêm vợ/chồng" Height="34px" Font-Size="Medium" OnClick="cmdThemVoChong_Click" OnClientClick="target ='_blank';"/>
                    <asp:Button ID="cmdTTAnhEm" runat="server" Text="Thứ tự anh em" Height="34px" Font-Size="Medium" OnClick="cmdTTAnhEm_Click"  OnClientClick="target ='_blank';"/>
                    <asp:Button ID="cmdTTVoChong" runat="server" Text="Thứ tự vợ chồng" Height="34px" Font-Size="Medium" OnClick="cmdTTVoChong_Click" OnClientClick="target ='_blank';"/>
                    <asp:Button ID="cmdXoaHoSo" runat="server" Text="Xóa hồ sơ" Height="34px" Font-Size="Medium" OnClick="cmdXoaHoSo_Click" OnClientClick="return MSGBOX('Bạn có muốn xóa hồ sơ không?')"/>
                    <asp:Button ID="cmdDoiChaMe" runat="server" Text="Đổi cha mẹ" Height="34px" Font-Size="Medium" OnClick="cmdDoiChaMe_Click" />
                </td>
            </tr>
            <%} %>
            <tr>
                <td colspan="6" >
                    <asp:Label ID="lblThongBao" runat="server" ForeColor="#CC0000"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="6" >
                    <asp:Label ID="lblGiaDinh" runat="server" Font-Bold="True" ></asp:Label><br/><br/>
                    <asp:Label ID="lblAnhEm" runat="server" Font-Bold="True"></asp:Label><br/>
                    <asp:Label ID="lblConCai" runat="server"  Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
    </div>    
</asp:Content>
