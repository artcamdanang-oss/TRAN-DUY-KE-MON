<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="XemChiTiet.aspx.cs" Inherits="SoanPha.XemChiTiet" %>
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
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ndcontent">
    <%
        if ((Boolean)Session["login"] == false)
        {
            if ((Boolean)Session["public"] != true) Response.Redirect("default.aspx");
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
                </td>
                <td><asp:Label ID="lblHoTenVoChong" runat="server" style="font-weight: 700"></asp:Label>
                </td>
            </tr>
        </table> 
        <table>
            <tr>
                <td class="auto-style1"><asp:Label ID="lblThongTin" runat="server" Font-Bold="False" Font-Size="Large" ></asp:Label><br/></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblGiaDinh" runat="server" Font-Bold="True" ></asp:Label><br/><br/>
                    <asp:Label ID="lblAnhEm" runat="server" Font-Bold="True"></asp:Label><br/>
                    <asp:Label ID="lblConCai" runat="server"  Font-Bold="True"></asp:Label>
                </td>
            </tr>            
            <tr>
                <td>
                    <asp:TextBox ID="txtGhiChu" runat="server" TextMode="MultiLine" Width="100%" ReadOnly="True" onkeyup="resizeTextBox(this)" Ondblclick="resizeTextBox()" Font-Size="Large" Rows="10"></asp:TextBox>
                    <asp:HyperLink ID="note" runat="server" OnClick="resizeTextBox()" Font-Size="Smaller" ForeColor="#003399">Ấn Enter hoặc kích đúp vào ô dữ liệu để mở rộng khung</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
