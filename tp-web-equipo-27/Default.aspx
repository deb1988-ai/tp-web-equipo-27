<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_web_equipo_27.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-1"></div>
        <div class="col">
            <br />
            <h1>Listado de artículos </h1>
            <p>Filtrar por:</p>
            <asp:DropDownList ID="DropDownListFiltro" runat="server" OnSelectedIndexChanged="DropDownListFiltro_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

            <%if (DropDownListFiltro.SelectedIndex > 0)
                {
            %>
            <%if (DropDownListFiltro.SelectedIndex == 1)
                {
            %>
            <asp:DropDownList ID="DropDownListCategoria" runat="server" OnSelectedIndexChanged="DropDownListCategoria_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <%  }
                else if (DropDownListFiltro.SelectedIndex == 2)
                { %>
            <asp:DropDownList ID="DropDownListMarca" runat="server" OnSelectedIndexChanged="DropDownListMarca_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <% }%>

            <asp:Button ID="ButtonFiltrar" runat="server" Text="Filtrar" OnClick="ButtonFiltrar_Click" CssClass="btn btn-light" AutoPostBack="true" />
            <%  } %>

            <div class="row row-cols-1 row-cols-md-3 g-4 p-3 mt-n1">

                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card h-100 mb-3 border-info bg-dark text-white text-center">
                                <div class="card-header">
                                    <%#Eval("Categoria") %>
                                </div>
                                <div id="carouselExampleIndicators" class="carousel slide">
                                    <div class="carousel-inner">
                                        <div class="carousel-item active">
                                            <img src="<%#Eval("ListaImagenes[0].ImagenUrl") %>" class="d-block" style="margin: auto; height: 180px" alt="...">
                                        </div>
                                    </div>
                                    <br />
                                    <div class="carousel-indicators">
                                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Precio") %></p>
                                    <asp:Button Text="Ver Producto" CssClass="btn btn-primary" runat="server" ID="btnDetalle" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnDetalle_Click" />
                                </div>
                                <div class="card-footer">
                                    <small class="text-white"><%#Eval("Marca") %></small>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <br />
        </div>
        <div class="col-1"></div>
    </div>

</asp:Content>
