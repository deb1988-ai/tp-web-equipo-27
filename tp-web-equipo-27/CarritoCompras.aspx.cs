using Domain;
using dominio;
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
            Carrito carrito = new Carrito();
            List<Articulo> ListaArticulos = Negocio.listarArticulos();

            if (Session.Count != 0)
            {
                for(int i = 0; i<Session.Count; i++)
                {
                    foreach (Articulo item in ListaArticulos)
                    {
                        if(Session.Keys.Get(i) == item.Id.ToString())
                        {
                            carrito.Cantidad = (int)Session[item.Id.ToString()];
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
                LabelTotal.Text = total.ToString() + "$.";
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

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* var texto = dgvCarrito.SelectedRow.Cells[0].Text;
            var id = dgvCarrito.SelectedDataKey.Value.ToString();
            List<Carrito> listaArticulosCarrito = (List<Carrito>)Session["ListaCarrito"];
            for (int i = 0;i< listaArticulosCarrito.Count;i++) {
            if(Convert.ToInt32(id) == listaArticulosCarrito[i].IdArticulo)
                {
                    listaArticulosCarrito.RemoveAt(i);
                }
            }
            if(listaArticulosCarrito.Count > 0)
            {
                Session.Add("ListaCarrito", listaArticulosCarrito);
            Response.Redirect("CarritoCompras.aspx");
            }*/
        }

        protected void ButtonActualizar_Click(object sender, EventArgs e)
        {
           for(int i = 0; i< listaArticulosCarrito.Count; i++) 
            {
                int id = Convert.ToInt32(dgvCarrito.SelectedDataKey.Value.ToString());

                List<Carrito> aux = listaArticulosCarrito;
                Carrito ArticuloAEliminar = aux.Find(x => x.IdArticulo == id);
                Label1.Text = ArticuloAEliminar.IdArticulo.ToString();
                Session.Remove(ArticuloAEliminar.IdArticulo.ToString());
            }
            Response.Redirect("CarritoCompras.aspx");
        }
    }
}