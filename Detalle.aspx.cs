using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Tp_web_equipo_14.Server;

namespace TPWeb_equipo_14
{
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Articulos> listaArticulos { get; set; }
        public Articulos item;
        public List<Imagen> listaImagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloServer articuloServer = new ArticuloServer();
            listaArticulos = articuloServer.listar();
            item = new Articulos();
            int id = int.Parse((Request.QueryString["id"]).ToString());
            item = listaArticulos[id];
            listaImagenes = item.Imagen;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CarritoServer carrito = Session["Carrito"] as CarritoServer;
            ArticuloServer articuloNegocio = new ArticuloServer();

            int idArticulo = int.Parse(Request.QueryString["id"]);
            Articulos articulo = articuloNegocio.buscarPorId(idArticulo);
            carrito.AgregarArticulo(articulo);
            Session["Carrito"] = carrito;



            var masterPage = this.Master as Site1;
            masterPage.ActualizarContenidoCarrito();
        }
    }
}