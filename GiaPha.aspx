<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GiaPha.aspx.cs" Inherits="SoanPha.GiaPha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <%
        if ((Boolean)Session["login"] == false)
        {
            if ((Boolean)Session["public"] != true) Response.Redirect("default.aspx");
        }
    %>
    <%
        if (Session["type"].ToString().ToUpper().Equals("USER")==false)
        { %>
    <asp:Button ID="cmdXuatGP" runat="server" Text="Xuất gia phả ra excel" OnClick="cmdXuatGP_Click"  OnClientClick="return MSGBOX('Bạn có muốn xuất gia phả ra tập tin excel không?')" />
    &nbsp;
    <asp:Button ID="cmdNhapGiaPha" runat="server" Text="Nhập gia phả từ excel" OnClientClick="return MSGBOX('Bạn có muốn nhập gia phả từ tập tin excel không?')" Width="203px" OnClick="cmdNhapGiaPha_Click" />
    &nbsp;&nbsp;
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <%} %>
    <asp:Repeater ID="rpHoToc" runat="server">
        <ItemTemplate>
            <h1>Cây gia phả : <%#Eval("TenHoToc") %> </h1>
        </ItemTemplate>
    </asp:Repeater>    
    <asp:TreeView ID="tvGiaPha" runat="server" Font-Names="Verdana" Font-Size="12pt" ShowLines="True" ForeColor="#00274F" Width="100%">
    </asp:TreeView>
    <asp:Label id="lblExportExcel" runat="server"></asp:Label>
</asp:Content>
