using Domain;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            ArticuloNegocio negocio = new ArticuloNegocio();

            ListaArticulos = negocio.listarArticulos();

            ImagenesNegocio negocioImagen = new ImagenesNegocio();

            List<string> listaUrlImagenes = new List<string>();

            if(Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    idArticuloSeleccionado = Convert.ToInt32(Request.QueryString["id"]);

                    ListaImagenes = negocioImagen.listarImagenes(idArticuloSeleccionado);

                    for (int i = 0; i < ListaArticulos.Count; i++)
                    {
                        if (idArticuloSeleccionado == ListaArticulos[i].Id)
                        {
                            articulo = ListaArticulos[i];
                        }
                    }

                    repRepetidorImagenes.DataSource = ListaImagenes;
                    repRepetidorImagenes.DataBind();
                    lblNombre.Text = articulo.Nombre;
                    lblDescripcion.Text = articulo.Descripcion;
                    lblPrecio.Text = Math.Round(articulo.Precio,2).ToString();
                }
            }else
            {
                lblError.Text = "Articulo no encontrado.";
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Carrito carrito = new Carrito();

            List<Carrito> ListaCarrito;

                if (!IsPostBack)
            {
                idArticuloSeleccionado = Convert.ToInt32(Request.QueryString["id"]);

                for (int i = 0; i < ListaArticulos.Count; i++)
                {
                    if (idArticuloSeleccionado == ListaArticulos[i].Id)
                    {
                        articulo = ListaArticulos[i];
                    }
                }
                carrito.IdArticulo = articulo.Id;
                carrito.articulo = articulo;
                carrito.Cantidad = Convert.ToInt32(txtCantidad.Text);
            }
            if (Session["ListaCarrito"] != null)
            {
                ListaCarrito = (List<Carrito>)Session["ListaCarrito"];
            }
            else
            {
                ListaCarrito = new List<Carrito>();
            }

            ListaCarrito.Add(carrito);

            Session["ListaCarrito"] = ListaCarrito;

            Response.Redirect("Default.aspx");
        }
    }
}