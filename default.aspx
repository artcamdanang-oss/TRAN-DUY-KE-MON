<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="SoanPha.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ndcontent">
        <h1>Danh Sách Họ Tộc</h1>
        <%
            if ((Boolean)Session["login"] == false)
            {
        %>
        <br />
        <table>
            <tr>
                <td>Mã họ tộc</td>
                <td>Tên họ tộc</td>
                <td>Thủy tổ</td>
                <td>Ngày giỗ</td>
                <td>Thủy tổ bà</td>
                <td>Ngày giỗ</td>
                <td>Trưởng tộc</td>
                <td>Ghi chú</td>
            </tr>
            <asp:ListView ID="lvHoTocD" runat="server" OnPagePropertiesChanging="lvHoTocD_PagePropertiesChanging">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("MaHoToc") %></td>
                        <%#Eval("MaNguoiLap").ToString().ToUpper().Equals("ZON")==true ? 
                                "<td><a href='GiaPha.aspx?IDHoToc=" + Eval("IDHoToc") + "'>" + Eval("TenHoToc") + "</a></td>" 
                                : "<td>" + Eval("TenHoToc") + "</td>" %>
                        <td><%#Eval("TenToOng") %></td>
                        <td><%#Eval("GioToOng") %></td>
                        <td><%#Eval("TenToBa") %></td>
                        <td><%#Eval("GioToBa") %></td>
                        <td><%#Eval("TenTruongHo") %></td>
                        <td><%#Eval("GhiChuHoToc") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
         Trang : <asp:DataPager ID="rpD" runat="server" PageSize="20" PagedControlID="lvHoTocD">
            <Fields>                
                <asp:NumericPagerField  ButtonCount="30" />
            </Fields>
        </asp:DataPager>
        <%       
            }
        %>
        <%
            else
            {
        %>
        <%
            if (Session["type"].ToString().ToUpper().Equals("USER") == false)
            {
        %>
        <table>
            <tr>
                <td>Mã họ tộc</td>
                <td>Tên họ tộc</td>
                <td>Chia sẻ</td>
                <td colspan="2"><a href="QLHoToc.aspx?ID=0&IDHoToc=0" target="_blank">Thêm họ tộc</a></td>
            </tr>
            <asp:ListView ID="lvHoToc" runat="server" OnPagePropertiesChanging="lvHoToc_PagePropertiesChanging">
                <ItemTemplate>
                    <tr>
                        <td><a href="GiaPha.aspx?IDHoToc=<%#Eval("IDHoToc") %>" target="_blank"><%#Eval("MaHoToc") %></a></td>
                        <td><a href="GiaPha.aspx?IDHoToc=<%#Eval("IDHoToc") %>"><%#Eval("TenHoToc") %></a></td>
                        <td><%#Eval("MaNguoiLap").ToString().ToUpper().Equals("ZON")==true ? "Công khai" : "" %></td>
                        <td><a href="QLHoToc.aspx?ID=1&IDHoToc=<%#Eval("IDHoToc") %>" target="_blank">Cập nhật</a></td>
                        <td><a href="XoaHoToc.aspx?IDHoToc=<%#Eval("IDHoToc")%>" target="_blank" onclick="return confirm('Bạn có thực sự chắc chắn muốn xóa họ tộc không?')">Xóa họ tộc</a></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
        Trang : <asp:DataPager ID="rpHT" runat="server" PageSize="20" PagedControlID="lvHoToc">
            <Fields>                
                <asp:NumericPagerField  ButtonCount="30" />
            </Fields>
        </asp:DataPager>
        <%}
            else
            {
        %>
        <table>
            <tr>
                <td>Mã họ tộc</td>
                <td>Tên họ tộc</td>
                <td>Thủy tổ</td>
                <td>Ngày giỗ</td>
                <td>Thủy tổ bà</td>
                <td>Ngày giỗ</td>
                <td>Trưởng tộc</td>
                <td>Ghi chú</td>
            </tr>
            <asp:ListView ID="lvHoTocV" runat="server" OnPagePropertiesChanging="lvHoTocV_PagePropertiesChanging">
                <ItemTemplate>
                    <tr>
                        <td><a href="GiaPha.aspx?IDHoToc=<%#Eval("IDHoToc") %>" target="_blank"><%#Eval("MaHoToc") %></a></td>
                        <td><a href="GiaPha.aspx?IDHoToc=<%#Eval("IDHoToc") %>"><%#Eval("TenHoToc") %></a></td>
                        <td><%#Eval("TenToOng") %></td>
                        <td><%#Eval("GioToOng") %></td>
                        <td><%#Eval("TenToBa") %></td>
                        <td><%#Eval("GioToBa") %></td>
                        <td><%#Eval("TenTruongHo") %></td>
                        <td><%#Eval("GhiChuHoToc") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>
         Trang : <asp:DataPager ID="rpV" runat="server" PageSize="20" PagedControlID="lvHoTocV">
            <Fields>                
                <asp:NumericPagerField  ButtonCount="30" />
            </Fields>
        </asp:DataPager>
        <%  }
        %>

        <%
            }
        %>
    </div>
</asp:Content>
