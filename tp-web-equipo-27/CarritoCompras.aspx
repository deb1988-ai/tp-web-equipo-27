<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoCompras.aspx.cs" Inherits="tp_web_equipo_27.CarritoCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:GridView runat="server" CssClass="table" ID="dgvCarrito" AutoGenerateColumns ="false" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Articulo.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio" DataField="Articulo.Precio" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="mensaje" runat="server" Text=""></asp:Label>
    <% if(Session.Count !=0)
            {
            %>
    <div class="container text-center">
  <div class="row">
    <div class="col">
    </div>
    <div class="col">
    </div>
    <div class="col">
      <asp:Label ID="LabelTotalText" runat="server" Text="Total:" CssClass="text-bg-light p-3"></asp:Label><asp:Label ID="LabelTotal" runat="server" Text="Label" CssClass="text-bg-light p-3"></asp:Label>
    </div>
  </div>
</div>
    
    <br />
    <asp:Button ID="ButtonVaciar" runat="server" Text="Vaciar carrito" OnClick="ButtonVaciar_Click" />
          <%  }%>
</asp:Content>
