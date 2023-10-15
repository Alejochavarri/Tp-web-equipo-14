using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Tp_web_equipo_14;

namespace TPWeb_equipo_14
{
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Articulos> articulos { get; set; }
        public int indice { get; set; }
        public bool hayArticulo { get; set; }
        public Articulos articulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            hayArticulo = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    articulos = (List<Articulos>)Session["ListaArticulos"];
                    int parametro = int.Parse(Request.QueryString["id"]);
                    indice = 0;
                    foreach (var articulo in articulos)
                    {

                        if (articulo.ID == parametro)
                        {
                            hayArticulo = true;
                            Session.Add("Articulo", articulo);
                            break;
                        }
                        indice++;
                    }

                }
                else
                {
                    lblError.Text = "NO SE RECIBIO NINGUN ARTICULO";
                }
            }
            else
            {
                hayArticulo = true;
            }

            if (hayArticulo)
            {
                cargarArticulo();
            }
            else
            {
                lblError.Text = "NO EXISTE PRODUCTO CON ESE ID";
            }
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

        protected string cargarImagen(string url)
        {
            ImagenServer imagenNegocio = new ImagenServer();
            if (imagenNegocio.VerificarUrlImagen(url))
            {
                return url;
            }

            return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
        }

        protected void cargarArticulo()
        {
            articulo = Session["Articulo"] as Articulos;
            tituloArticulo.Text = articulo.Nombre;
            descArticulo.Text = "Descpricion: " + articulo.Descripcion;
            marcaArticulo.Text = "Marca: " + articulo.Marca.ToString();
            categoriaArticulo.Text = "Categoria: " + articulo.Categoria.ToString(); ;
            precioArticulo.Text = "Precio: $" + articulo.Precio.ToString();
        }
    }
}