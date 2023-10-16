using dominio;
using Domain;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_27
{
    public partial class CarritoCompras : System.Web.UI.Page
    {
        private decimal total = 0;

        List<Carrito> listaArticulosCarrito =  new List<Carrito>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio Negocio = new ArticuloNegocio();
            Carrito carrito;
            List<Articulo> ListaArticulos = Negocio.listarArticulos();

            if (Session.Count != 0)
            {
                for(int i = 0; i<Session.Count; i++)
                {
                    foreach (Articulo item in ListaArticulos)
                    {
                        carrito = new Carrito();
                        if(Session.Keys.Get(i) == item.Id.ToString())
                        {
                            carrito.Cantidad = Convert.ToInt32(Session[item.Id.ToString()]);
                            carrito.IdArticulo = item.Id;
                            carrito.Articulo = item;
                            listaArticulosCarrito.Add(carrito);
                        }
                    }
                }
                dgvCarrito.DataSource = listaArticulosCarrito;
                dgvCarrito.DataBind();
                foreach (Carrito item in listaArticulosCarrito)
                {
                    total += item.Cantidad * item.Articulo.Precio;
                }
                LabelTotal.Text = total.ToString("N2") + " $.";
            }
            else
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

       protected void ButtonActualizar_Click(object sender, EventArgs e)
        {
           List<int> listaArticulosActualizar = new List<int>();

            foreach (GridViewRow row in dgvCarrito.Rows)
            {
                TextBox txtValor = (row.Cells[3].FindControl("txtCantidad") as TextBox);
                int ArticuloId = Convert.ToInt32(dgvCarrito.DataKeys[row.RowIndex].Value);
                string cantidad = txtValor.Text;

                Session[ArticuloId.ToString()] = cantidad;
            }

            /*foreach (GridViewRow row in dgvCarrito.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    int ArticuloId = Convert.ToInt32(dgvCarrito.DataKeys[row.RowIndex].Value);
                    int cantidad = int.Parse(((TextBox)row.Cells[3].FindControl("txtCantidad")).Text);
                    Label1.Text = ArticuloId.ToString();
                    Session[ArticuloId.ToString()] = cantidad;
                }
            }*/
           Response.Redirect("CarritoCompras.aspx");
        }

        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEliminar")
            {
                int ArticuloId = Convert.ToInt32(e.CommandArgument.ToString());
                
                    Session.Remove(ArticuloId.ToString());

                Response.Redirect("CarritoCompras.aspx");
            }
        }
    }
}