using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWeb_equipo_14
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string UrlImagen { get; set; }
        public override string ToString()
        {
            return UrlImagen;
        }
    }
}
