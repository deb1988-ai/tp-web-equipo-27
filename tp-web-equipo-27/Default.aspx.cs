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
            ListItem item0 = new ListItem("--------", "0");
            ListItem item1 = new ListItem("Categoria", "1");
            ListItem item2 = new ListItem("Marca", "2");
            DropDownListFiltro.Items.Add(item0);
            DropDownListFiltro.Items.Add(item1);
            DropDownListFiltro.Items.Add(item2);

            if (!IsPostBack)
            {
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

        protected void DropDownListFiltroSeleccionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListFiltroSeleccionado.Items.Clear();
            if (DropDownListFiltro.SelectedItem.ToString() == "Categoria")
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categorias> categorias = new List<Categorias>();
                categorias = categoriaNegocio.listar();
                foreach (Categorias item in categorias)
                {DropDownListFiltroSeleccionado.Items.Add(item.Descripcion.ToString());  
                }
            }
            else if( DropDownListFiltro.SelectedItem.ToString() == "Marca")
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marcas> marcas = new List<Marcas>();
                marcas = marcaNegocio.listarMarcas();
                foreach (Marcas item in marcas)
                {

                    DropDownListFiltroSeleccionado.Items.Add(item.Descripcion.ToString());
                }
            }
        }
    }
}