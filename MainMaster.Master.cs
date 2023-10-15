using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tp_web_equipo_14;

namespace TPWeb_equipo_14
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public List<Marca> listaMarca { get; set; }
        public List<Categoria> listaCategoria { get; set; }
        public CarritoServer Carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Carrito = Session["Carrito"] as CarritoServer;
            if (Carrito == null)
            {
                Carrito = new CarritoServer();
                Session["Carrito"] = Carrito;
            }

            if (!IsPostBack)
            {
                MostrarCarritoEnModal(Carrito);
            }
        }

        protected void MostrarCarritoEnModal(CarritoServer carrito)
        {
            lblCantidad.Text = carrito.ObtenerArticulos().Count().ToString();
            if (carrito.ObtenerArticulos().Count() > 0)
            {
                rptModal.DataSource = carrito.ObtenerArticulos();
                rptModal.DataBind();
            }
            
        }

        public void ActualizarContenidoCarrito()
        {
            CarritoServer carrito = Session["Carrito"] as CarritoServer;
            MostrarCarritoEnModal(carrito);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnAgregar = (Button)sender;
            int idArticulo = int.Parse(btnAgregar.CommandArgument);
            Carrito.QuitarArticulo(idArticulo);
            Session["Carrito"] = Carrito;
            ActualizarContenidoCarrito();
        }
    }
}