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

        protected void VerCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarritoCompras.aspx");
        }
    }
}