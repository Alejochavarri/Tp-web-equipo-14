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
        public List<Articulos> ListaArticulos { get; set; }
        ArticuloServer articuloServer;

        public Default()
        {
            articuloServer = new ArticuloServer();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaArticulos = articuloServer.listar();
                Session.Add("ListaArticulos", ListaArticulos);

                rptArticulos.DataSource = ListaArticulos;
                rptArticulos.DataBind();
            }

            ListaArticulos = (List<Articulos>)Session["ListaArticulos"];
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

            
            Articulos articulo = articuloServer.buscarPorId(idArticulo);
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

        public string cargarImagen(string url)
        {
            ImagenServer imagenNegocio = new ImagenServer();
            if (imagenNegocio.VerificarUrlImagen(url))
            {
                return string.Format("<img src='{0}' class='card-img-top' />", url);
            }

            return "<img src='https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg' class='card-img-top' />";
        }
    }
}