using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Carrito
    {
        public int IdArticulo { get; set; }

        public int Cantidad { get; set; }

        public Articulo Articulo { get; set; }
    }
}
