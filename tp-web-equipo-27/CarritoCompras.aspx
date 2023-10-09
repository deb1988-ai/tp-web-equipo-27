<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoCompras.aspx.cs" Inherits="tp_web_equipo_27.CarritoCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:GridView runat="server" CssClass="table" ID="dgvCarrito">

    </asp:GridView>
    <asp:Label ID="mensaje" runat="server" Text=""></asp:Label>
</asp:Content>
