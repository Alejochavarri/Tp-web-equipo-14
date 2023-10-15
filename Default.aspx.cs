using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tp_web_equipo_14.Server;

namespace TPWeb_equipo_14
{
    public partial class Default : System.Web.UI.Page
    {
        public List <Articulos> listaArticulos {  get; set; }
        ArticuloServer articuloServerC = new ArticuloServer();

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloServer articuloServer = new ArticuloServer();

            listaArticulos = articuloServer.listar();
            


            Articulos variable = new Articulos();
        }

        protected void btnAceptar(object sender, EventArgs e)
        {
            int idElemento = 1;
            Response.Redirect("Detalle.aspx?id=" + idElemento,false);
        }
        protected void VerDetalle_Click(object sender, EventArgs e)
        {
            int idElemento = 0;
            Response.Redirect("Detalle.aspx?id=" + idElemento, false);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CarritoServer carrito = Session["Carrito"] as CarritoServer;

            Button btnAgregar = (Button)sender;
            int idArticulo = int.Parse(btnAgregar.CommandArgument);

            
            Articulos articulo = articuloServerC.buscarPorId(idArticulo);
            carrito.AgregarArticulo(articulo);
            Session["Carrito"] = carrito;


            var masterPage = this.Master as Site1;
            masterPage.ActualizarContenidoCarrito();
        }
        protected string GetButtonCommandArgument(object dataItem)
        {
            var item = (Articulos)dataItem;
            return item.ID.ToString();
        }
    }
}