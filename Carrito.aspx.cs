using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPWeb_equipo_14;

namespace Tp_web_equipo_14
{
    public partial class Carrito1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarritoServer carrito = Session["Carrito"] as CarritoServer;

                if (carrito != null && carrito.ObtenerArticulos().Count > 0)
                {
                    rptCarrito.DataSource = carrito.ObtenerArticulos();
                    rptCarrito.DataBind();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }


            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int indice = Convert.ToInt32(btnEliminar.CommandArgument);
            EliminarArticulo(indice);
            MostrarCarrito();
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            // TODO: Llevar a pagar articulos del carrito
        }

        private void MostrarCarrito()
        {
            CarritoServer carrito = Session["Carrito"] as CarritoServer;
            if (carrito != null)
            {
                rptCarrito.DataSource = carrito.ObtenerArticulos();
                rptCarrito.DataBind();
            }
        }

        private void EliminarArticulo(int indice)
        {
            CarritoServer carrito = Session["Carrito"] as CarritoServer;
            if (carrito != null)
            {
                List<Articulos> articulos = carrito.ObtenerArticulos();
                if (indice >= 0 && indice < articulos.Count)
                {
                    articulos.RemoveAt(indice);
                    Session["Carrito"] = carrito;
                }
            }
        }


        protected string ObtenerTotalCarrito()
        {
            CarritoServer carrito = Session["Carrito"] as CarritoServer;

            if (carrito != null)
            {
                decimal total = carrito.ObtenerTotal();
                return total.ToString("C");
            }

            return "$0.00";
        }
    }
}