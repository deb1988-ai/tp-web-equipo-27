using Domain;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace tp_web_equipo_27
{
    public partial class Producto : System.Web.UI.Page
    {
        public int idArticuloSeleccionado { get; set; }

        public Articulo articulo = new Articulo();
        public List<Articulo> ListaArticulos { get; set; }
        public List<Imagenes> ListaImagenes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            idArticuloSeleccionado = Convert.ToInt32(Request.QueryString["id"]);

            ArticuloNegocio negocio = new ArticuloNegocio();

            ListaArticulos = negocio.listarArticulos();

            ImagenesNegocio negocioImagen = new ImagenesNegocio();

            List<string> listaUrlImagenes = new List<string>();

            if(Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    ListaImagenes = negocioImagen.listarImagenes(idArticuloSeleccionado);

                    foreach (var item in ListaArticulos)
                    {
                        if(idArticuloSeleccionado == item.Id)
                        {
                            articulo = item;
                            articulo.ListaImagenes = item.ListaImagenes;
                        }
                    }
                    if (Session[idArticuloSeleccionado.ToString()] != null)
                    {
                        txtCantidad.Text = idArticuloSeleccionado.ToString();
                    }
                    foreach (var item in articulo.ListaImagenes)
                    {
                        listaUrlImagenes.Add(item.ImagenUrl);
                    }
                  
                    lblNombre.Text = articulo.Nombre;
                    lblDescripcion.Text = articulo.Descripcion;
                    lblMarca.Text = articulo.Marca.Descripcion;
                    lblPrecio.Text = Math.Round(articulo.Precio,2).ToString();
                }
            }
            else
            {
                lblError.Text = "Articulo no encontrado.";
                Response.Redirect("Default.aspx");

            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Carrito carrito = new Carrito();

            ArticuloNegocio negocio = new ArticuloNegocio();

            ListaArticulos = negocio.listarArticulos();
            
            Articulo articulo = new Articulo();

            if (!IsPostBack)
            {
                idArticuloSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
                carrito.Articulo = articulo;
                
            }
            carrito.Cantidad = Convert.ToInt32(txtCantidad.Text);

            if (Session[idArticuloSeleccionado.ToString()] != null)
           {
                Session[idArticuloSeleccionado.ToString()] = (int)Session[idArticuloSeleccionado.ToString()]+1;
            }
           else
           {
                Session.Add(idArticuloSeleccionado.ToString(), carrito.Cantidad);
            }             
            Response.Redirect("Default.aspx");
        }
    }
}