using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPWeb_equipo_14;

namespace Tp_web_equipo_14
{
    public class Carrito
    {
        public List<Articulos> ArticulosC { get; set; }

        public Carrito()
        {
            ArticulosC = new List<Articulos>();
        }
    }
}