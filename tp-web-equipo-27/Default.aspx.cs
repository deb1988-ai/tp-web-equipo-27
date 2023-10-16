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
        public string FiltroSeleccionado { get; set; }
        public string CategoriaSeleccionada { get; set; }
        public  string MarcaSeleccionada { get; set; }

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

            FiltroSeleccionado = Request.QueryString["Filtro"];
            CategoriaSeleccionada = Request.QueryString["Categoria"];
            MarcaSeleccionada = Request.QueryString["Marca"];

            List<Articulo> ListaFiltrada = new List<Articulo>();

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
                if (Request.QueryString["Filtro"]!= null)
                {
                    if (FiltroSeleccionado == "1")
                    {
                        for (int i = 0; i < ListaArticulos.Count; i++)
                        {
                            if (ListaArticulos[i].Categoria.Descripcion == CategoriaSeleccionada)
                            {
                                ListaFiltrada.Add(ListaArticulos[i]);
                            }
                        }
                        repRepetidor.DataSource = ListaFiltrada;
                        repRepetidor.DataBind();
                    }
                    else if (FiltroSeleccionado == "2")
                    {
                        for (int i = 0; i < ListaArticulos.Count; i++)
                        {
                            if (ListaArticulos[i].Marca.Descripcion == MarcaSeleccionada)
                            {
                                ListaFiltrada.Add(ListaArticulos[i]);
                            }
                        }
                        repRepetidor.DataSource = ListaFiltrada;
                        repRepetidor.DataBind();
                    }
                } 
                else
                {
                    repRepetidor.DataSource = ListaArticulos;
                    repRepetidor.DataBind();
                }
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
            string filtro = DropDownListFiltro.SelectedIndex.ToString();
            if(DropDownListFiltro.SelectedIndex == 1)
            {
                string opcion = DropDownListCategoria.SelectedItem.ToString();
                Response.Redirect("Default.aspx?Filtro=" + filtro + "&Categoria=" + opcion, false);
            } else if (DropDownListFiltro.SelectedIndex == 2)
            {
                string opcion = DropDownListMarca.SelectedItem.ToString();
                Response.Redirect("Default.aspx?Filtro=" + filtro + "&Marca=" + opcion, false);
            }
        }

        protected void DropDownListMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}