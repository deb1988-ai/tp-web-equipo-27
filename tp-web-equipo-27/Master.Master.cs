﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_27
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Carrito> ListaCarrito;

            if (Session["ListaCarrito"] != null)
            {
                ListaCarrito = (List<Carrito>)Session["ListaCarrito"];
                contadorCarrito.InnerText = ListaCarrito.Count().ToString();
            }

        }
    }
}