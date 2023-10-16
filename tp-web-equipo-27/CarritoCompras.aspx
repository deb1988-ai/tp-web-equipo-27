<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoCompras.aspx.cs" Inherits="tp_web_equipo_27.CarritoCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:GridView runat="server" CssClass="table" ID="dgvCarrito" AutoGenerateColumns="false" DataKeyNames="IdArticulo" OnRowCommand="dgvCarrito_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Articulo.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio" DataField="Articulo.Precio" DataFormatString="{0:N} $" />
            <asp:TemplateField HeaderText="Eliminar Artículo">
                <ItemTemplate>
                    <asp:LinkButton Text="Eliminar" runat="server" ID="btnEliminar" CommandName="btnEliminar" CommandArgument='<%#Eval("IdArticulo") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="mensaje" runat="server" Text=""></asp:Label>
    <% if (Session.Count != 0)
        {
    %>
    <div class="container text-center">
        <div class="row">
            <div class="col">
            </div>
            <div class="col">
            </div>
            <div class="col">
            </div>
            <div class="col">
            </div>
            <div class="col alert alert-info">
                <asp:Label ID="LabelTotalText" runat="server" Text="Total: "></asp:Label><asp:Label ID="LabelTotal" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <br />
    <div class="row">
        <div class="col">
        </div>
        <div class="col">
        </div>
        <div class="col">
            <asp:Button ID="ButtonVaciar" runat="server" Text="Vaciar carrito" OnClick="ButtonVaciar_Click" CssClass="btn btn-danger" />
        </div>
        <div class="col">
        </div>


    </div>

    <%  }%>
</asp:Content>
