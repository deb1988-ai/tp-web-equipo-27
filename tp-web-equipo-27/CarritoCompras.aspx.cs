using Domain;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_27
{
    public partial class CarritoCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio Negocio = new ArticuloNegocio();
            if(Session.Count != 0 )
            {
                List<Carrito> listaArticulosCarrito = (List<Carrito>)Session[""];
                dgvCarrito.DataSource = Session;
                dgvCarrito.DataBind();
            } else
            {
                mensaje.Text = "El carrito se encuentra vacio.";
            }
            
        }
    }
}