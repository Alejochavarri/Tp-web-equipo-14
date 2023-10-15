using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

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
            Response.Redirect("Carrito.aspx", false);
        }
    }
}