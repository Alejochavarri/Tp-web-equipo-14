using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class CategoriaServer
    {
        public List<Categoria> listar()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Id = (int)datos.Lector["Id"];
                    listaCategorias.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return listaCategorias;
        }



        public Categoria buscarPorDescripcion(string descripcion)
        {
            Categoria categoria = null;
            AccesoDatos db = new AccesoDatos();
            string query = "SELECT Id, Descripcion FROM CATEGORIAS WHERE Descripcion = @descripcion";
            try
            {
                db.setConsulta(query);
                db.setearParametro("@descripcion", descripcion);
                db.ejecutarLectura();
                if (db.Lector.Read())
                {
                    categoria = new Categoria();
                    categoria.Descripcion = (string)db.Lector["Descripcion"];
                    categoria.Id = (int)db.Lector["Id"];
                }

                return categoria;
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

        public int guardar(string nuevaCategoria)
        {
            int idCategoria = -1;
            string descripcion = nuevaCategoria;
            string query = "INSERT INTO CATEGORIAS(Descripcion) VALUES(@descripcion);" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;";
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setConsulta(query);
                db.setearParametro("@descripcion", descripcion);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    idCategoria = (int)db.Lector["ID"];
                }

                return idCategoria;
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
        public int modificar(string descripcion, int idCategoria)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "UPDATE CATEGORIAS SET Descripcion = @descripcion WHERE Id = @idCategoria";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@descripcion", descripcion);
                db.setearParametro("@idCategoria", idCategoria);
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

        public int eliminar(int idCategoria)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "DELETE FROM CATEGORIAS WHERE Id = @idCategoria";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@idCategoria", idCategoria);
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