using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Server;
using Dominio;

namespace TPWeb_equipo_14
{
    public partial class Default : System.Web.UI.Page
    {
        public List <Articulos> listaArticulos {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloServer articuloServer = new ArticuloServer();
            listaArticulos = articuloServer.listar();
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
    }
}