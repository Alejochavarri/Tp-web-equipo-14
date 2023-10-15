using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPWeb_equipo_14;

namespace Tp_web_equipo_14.Server
{
    public class CarritoServer
    {
        private Carrito Carrito;

        public CarritoServer()
        {
            Carrito = new Carrito();
        }

        public void AgregarArticulo(Articulos articulo)
        {
            Carrito.ArticulosC.Add(articulo);
        }

        public void QuitarArticulo(int idArticulo)
        {
            Articulos articulo = Carrito.ArticulosC.FirstOrDefault(a => a.ID == idArticulo);
            if (articulo != null)
            {
                Carrito.ArticulosC.Remove(articulo);
            }
        }

        public List<Articulos> ObtenerArticulos()
        {
            return Carrito.ArticulosC;
        }

        public decimal ObtenerTotal()
        {
            decimal total = 0;

            foreach (var item in ObtenerArticulos())
            {
                total += item.Precio;
            }

            return total;
        }
    }
}