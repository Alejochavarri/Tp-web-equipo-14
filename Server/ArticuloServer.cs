using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Data.SqlTypes;
using System.Net;

namespace Server
{
    public class ArticuloServer
    {
        public List<Articulos> listar()
        {
            List<Articulos> Catalogo = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT A.*, M.Descripcion AS Desc_Marca, C.Descripcion AS Desc_Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                datos.ejecutarLectura();
                while (datos.lector.Read())
                {
                    Articulos aux = new Articulos();

                    int idArticulo = (int)datos.Lector["Id"];
                    aux.ID = idArticulo;
                    //if (!(datos.Lector["Codigo"] is DBNull)) aux.Codigo = (string)datos.Lector["Codigo"];
                    if (datos.lector.IsDBNull(datos.lector.GetOrdinal("Codigo")))
                    {
                        aux.Codigo = "";
                    }
                    else
                    {
                        aux.Codigo = (String)datos.lector["Codigo"];
                    }
                    //if (!(datos.Lector["Nombre"] is DBNull)) aux.Nombre = (string)datos.Lector["Nombre"];
                    if (datos.lector.IsDBNull(datos.lector.GetOrdinal("Nombre")))
                    {
                        aux.Nombre = "";
                    }
                    else
                    {
                        aux.Nombre = (String)datos.lector["Nombre"];
                    }
                    //if (!(datos.Lector["Descripcion"] is DBNull)) aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (datos.lector.IsDBNull(datos.lector.GetOrdinal("Descripcion")))
                    {
                        aux.Descripcion = "";
                    }
                    else
                    {
                        aux.Descripcion = (String)datos.lector["Descripcion"];
                    }
                    //if (!(datos.Lector["Precio"] is DBNull)) aux.Precio = (decimal)datos.Lector["Precio"];
                    if (datos.lector.IsDBNull(datos.lector.GetOrdinal("Precio")))
                    {
                        aux.Precio = 0;
                    }
                    else
                    {
                        aux.Precio = (decimal)datos.lector["Precio"];
                    }
                    ImagenServer imagenNegocio = new ImagenServer();
                    aux.Imagen = imagenNegocio.imagenesArticulo(idArticulo);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    //if (!(datos.Lector["Desc_Marca"] is DBNull)) aux.Marca.Descripcion = (string)datos.Lector["Desc_Marca"];
                    if (datos.lector.IsDBNull(datos.lector.GetOrdinal("Desc_Marca")))
                    {
                        aux.Marca.Descripcion = "";
                    }
                    else
                    {
                        aux.Marca.Descripcion = (String)datos.lector["Desc_Marca"];
                    }


                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    //if (!(datos.Lector["Desc_Categoria"] is DBNull)) aux.Categoria.Descripcion = (string)datos.Lector["Desc_Categoria"];
                    if (datos.lector.IsDBNull(datos.lector.GetOrdinal("Desc_Categoria")))
                    {
                        aux.Categoria.Descripcion = "";
                    }
                    else
                    {
                        aux.Categoria.Descripcion = (String)datos.lector["Desc_Categoria"];
                    }



                    Catalogo.Add(aux);

                }

                return Catalogo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Articulos> listarPorMarca(int idMarca)
        {
            AccesoDatos db = new AccesoDatos();
            List<Articulos> lista = new List<Articulos>();
            string query = "SELECT A.Id as Id, A.Codigo as Codigo, A.Precio as Precio, A.Nombre as Nombre, A.Descripcion as Descripcion, A.IdMarca as IdMarca, M.Descripcion as Marca, A.IdCategoria as IdCategoria, C.Descripcion as Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE A.IdMarca = @idMarca";
            try
            {
                db.setConsulta(query);
                db.setearParametro("@idMarca", idMarca);
                db.ejecutarLectura();
                while (db.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    int idArticulo = (int)db.Lector["Id"];
                    aux.ID = idArticulo;
                    if (!(db.Lector["Codigo"] is DBNull)) aux.Codigo = (string)db.Lector["Codigo"];
                    if (!(db.Lector["Nombre"] is DBNull)) aux.Nombre = (string)db.Lector["Nombre"];
                    if (!(db.Lector["Descripcion"] is DBNull)) aux.Descripcion = (string)db.Lector["Descripcion"];
                    if (!(db.Lector["Precio"] is DBNull)) aux.Precio = (decimal)db.Lector["Precio"];

                    ImagenServer imagenNegocio = new ImagenServer();
                    aux.Imagen = imagenNegocio.imagenesArticulo(idArticulo);
                
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)db.Lector["IdMarca"];
                    if (!(db.Lector["Marca"] is DBNull)) aux.Marca.Descripcion = (string)db.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)db.Lector["IdCategoria"];
                    if (!(db.Lector["Categoria"] is DBNull)) aux.Categoria.Descripcion = (string)db.Lector["Categoria"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }
        }
        public List<Articulos> listarPorCategoria(int idCategoria)
        {
            AccesoDatos db = new AccesoDatos();
            List<Articulos> lista = new List<Articulos>();
            string query = "SELECT A.Id as Id, A.Codigo as Codigo, A.Precio as Precio, A.Nombre as Nombre, A.Descripcion as Descripcion, A.IdMarca as IdMarca, M.Descripcion as Marca, A.IdCategoria as IdCategoria, C.Descripcion as Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE A.IdCategoria = @idCategoria";
            try
            {
                db.setConsulta(query);
                db.setearParametro("@idCategoria", idCategoria);
                db.ejecutarLectura();
                while (db.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    int idArticulo = (int)db.Lector["Id"];
                    aux.ID = idArticulo;
                    if (!(db.Lector["Codigo"] is DBNull)) aux.Codigo = (string)db.Lector["Codigo"];
                    if (!(db.Lector["Nombre"] is DBNull)) aux.Nombre = (string)db.Lector["Nombre"];
                    if (!(db.Lector["Descripcion"] is DBNull)) aux.Descripcion = (string)db.Lector["Descripcion"];
                    if (!(db.Lector["Precio"] is DBNull)) aux.Precio = (decimal)db.Lector["Precio"];

                    ImagenServer imagenNegocio = new ImagenServer();
                    aux.Imagen = imagenNegocio.imagenesArticulo(idArticulo);


                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)db.Lector["IdMarca"];
                    if (!(db.Lector["Marca"] is DBNull)) aux.Marca.Descripcion = (string)db.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)db.Lector["IdCategoria"];
                    if (!(db.Lector["Categoria"] is DBNull)) aux.Categoria.Descripcion = (string)db.Lector["Categoria"];
                

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }
        }
        public int guardar(Articulos nuevoArticulo)
        {
            int idArticulo = -1;
            string codigo = nuevoArticulo.Codigo;
            string nombre = nuevoArticulo.Nombre;
            string descripcion = nuevoArticulo.Descripcion;
            int idMarca = nuevoArticulo.Marca.Id;
            int idCategoria = nuevoArticulo.Categoria.Id;
            decimal precio = nuevoArticulo.Precio;

            string query = $"INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES(@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio);" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;";
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setConsulta(query);
                db.setearParametro("@nombre", nombre);
                db.setearParametro("@codigo", codigo);
                db.setearParametro("@descripcion", descripcion);
                db.setearParametro("@precio", precio);
                db.setearParametro("@idCategoria", idCategoria);
                db.setearParametro("@idMarca", idMarca);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    idArticulo = (int)db.Lector["ID"];
                }

                return idArticulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }

        }
        public int modificar(Articulos articulo)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "UPDATE ARTICULOS SET Nombre = @nombre, Codigo = @codigo, Descripcion = @descripcion, Precio = @precio, IdCategoria = @idCategoria, IdMarca = @idMarca WHERE id = @idArticulo";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@nombre", articulo.Nombre);
                db.setearParametro("@codigo", articulo.Codigo);
                db.setearParametro("@descripcion", articulo.Descripcion);
                db.setearParametro("@precio", articulo.Precio);
                db.setearParametro("@idCategoria", articulo.Categoria.Id);
                db.setearParametro("@idMarca", articulo.Marca.Id);
                db.setearParametro("@idArticulo", articulo.ID);
                rowsAffected = db.ejecutarAccion();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public int eliminar(int idArticulo)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "DELETE FROM ARTICULOS WHERE Id = @idArticulo";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@idArticulo", idArticulo);
                rowsAffected = db.ejecutarAccion();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }
        }

       

    }
}
