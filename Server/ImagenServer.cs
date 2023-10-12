using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ImagenServer
    {
        public int guardar(Imagen imagen)
        {
            int idImagen = -1;
            int idArticulo = imagen.IdArticulo;
            string urlImagen = imagen.UrlImagen;
            string query = "INSERT INTO IMAGENES(IdArticulo, ImagenUrl) VALUES(@idArticulo, @urlImagen); SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID";
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.setConsulta(query);
                db.setearParametro("@idArticulo", idArticulo);
                db.setearParametro("@urlImagen", urlImagen);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    idImagen = (int)db.Lector["ID"];
                }

                return idImagen;
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

        public int modificar(int idImagen, string url)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "UPDATE IMAGENES SET ImagenUrl = @url  where Id = @idImagen";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@url", url);
                db.setearParametro("@idImagen", idImagen);
                rowsAffected = db.ejecutarAccion();
                return rowsAffected;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public int eliminar(int idArticuloImagen)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "DELETE FROM IMAGENES WHERE IdArticulo = @idArticuloImagen";
            int rowsAffected = 0;
            try
            {
                db.setConsulta(query);
                db.setearParametro("@idArticuloImagen", idArticuloImagen);
                rowsAffected = db.ejecutarAccion();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Imagen> imagenesArticulo(int idArticulo)
        {
            AccesoDatos db = new AccesoDatos();
            string query = "SELECT IdArticulo, ImagenUrl, Id FROM IMAGENES WHERE IdArticulo = @idArticulo";
            List<Imagen> imagenes = new List<Imagen>();

            try
            {
                db.setConsulta(query);
                db.setearParametro("@idArticulo", idArticulo);
                db.ejecutarLectura();
                while (db.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)db.Lector["Id"];
                    imagen.UrlImagen = (string)db.Lector["ImagenUrl"];
                    imagen.IdArticulo = (int)db.Lector["IdArticulo"];
                    imagenes.Add(imagen);
                }

                return imagenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
