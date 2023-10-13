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
                List<Carrito> listaArticulosCarrito = (List<Carrito>)Session["ListaCarrito"];
                dgvCarrito.DataSource = listaArticulosCarrito;
                dgvCarrito.DataBind();
            } else
            {
                mensaje.Text = "El carrito se encuentra vacio.";
            }
            
        }

        protected void ButtonVaciar_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("CarritoCompras.aspx");
            }
            catch (Exception ex)
            {
                mensaje.Text = ex.ToString();
                throw;
            }
        }
    }
}