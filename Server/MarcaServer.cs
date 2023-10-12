using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MarcaServer
    {
        public List<Marca> listar()
        {
            List<Marca> listaMarcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Id = (int)datos.Lector["Id"];

                    listaMarcas.Add(aux);
                }

                return listaMarcas;
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

        public int guardar(string nuevaMarca)
        {
            int idMarca = -1;
            string descripcion = nuevaMarca;

            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setConsulta($"INSERT INTO MARCAS(Descripcion) VALUES('{descripcion}');" + "SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID;");
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    idMarca = (int)db.Lector["ID"];
                }

                return idMarca;
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

        public int modificar(string descripcion, int idMarca)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "UPDATE MARCAS SET Descripcion = @descripcion WHERE Id = @idMarca";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@descripcion", descripcion);
                db.setearParametro("@idMarca", idMarca);
                rowsAffected = db.ejecutarAccion();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { db.cerrarConexion(); }
        }

        public int eliminar(int idMarca)
        {
            AccesoDatos db = new AccesoDatos();

            string query = "DELETE FROM MARCAS WHERE Id = @idMarca";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@idMarca", idMarca);
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
        public Marca buscarPorDescripcion(string descripcion)
        {
            Marca marca = null;
            AccesoDatos db = new AccesoDatos();
            string query = $"SELECT Id, Descripcion FROM MARCAS WHERE Descripcion = @descripcion";
            try
            {
                db.setConsulta(query);
                db.setearParametro("@descripcion", descripcion);
                db.ejecutarLectura();
                if (db.Lector.Read())
                {
                    marca = new Marca();
                    marca.Descripcion = (string)db.Lector["Descripcion"];
                    marca.Id = (int)db.Lector["Id"];
                }
                return marca;
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
