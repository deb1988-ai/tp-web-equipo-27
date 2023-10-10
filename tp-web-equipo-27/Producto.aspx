<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="tp_web_equipo_27.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-md">
        <div id="carouselExampleIndicators" class="carousel slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">

                <%
                    try
                    {
                        if (idArticuloSeleccionado != null)
                        {
                            foreach (dominio.Imagenes imagen in ListaImagenes)
                            {

                %>
                <div class="carousel-item active">
                    <img src="<%:imagen.ImagenUrl%>" class="d-block w-100" alt="...">
                </div>
                <%
                    }
                %>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
            <%
                    }
                    else
                    {

                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            %>


            <div class="card-body">
                <ul class="list-group">
                    <li class="list-group-item">
                        <asp:Label ID="lblNombre" CssClass="card-title" runat="server" Text=""></asp:Label>
                    </li>
                    <li class="list-group-item">
                        <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label></li>
                    <li class="list-group-item">
                        <asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label></li>
                    <li class="list-group-item">
                        <asp:Label ID="lblMarca" runat="server" Text=""></asp:Label></li>
                    <li class="list-group-item">
                        <asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label></li>
                </ul>

                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" Text="1"></asp:TextBox>
                <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar al carrito" OnClick="ButtonAgregar_Click" />

            </div>
        </div>
</asp:Content>
