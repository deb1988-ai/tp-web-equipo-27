using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace tp_web_equipo_27
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        public int idArticuloSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarArticulos();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            List<Categorias> categorias = new List<Categorias>();
            categorias = categoriaNegocio.listar();

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            List<Marcas> marcas = new List<Marcas>();
            marcas = marcaNegocio.listarMarcas();


            if (!IsPostBack)
            {
                ListItem item0 = new ListItem("--------", "0");
                ListItem item1 = new ListItem("Categoria", "1");
                ListItem item2 = new ListItem("Marca", "2");
                DropDownListFiltro.Items.Add(item0);
                DropDownListFiltro.Items.Add(item1);
                DropDownListFiltro.Items.Add(item2);
                DropDownListCategoria.DataSource = categorias;
                DropDownListCategoria.DataBind();
                DropDownListMarca.DataSource = marcas;
                DropDownListMarca.DataBind();
                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("Producto.aspx?id=" + id);
        }

        protected void DropDownListFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

        }

        protected void ButtonFiltrar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarArticulos();
            List<Articulo> listaFiltrada = new List<Articulo>();

        }

        protected void DropDownListMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}