using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial02JOELDAMERDJIAN
{
    public class Articulo
    {
        public string Nombre { get; set; }

        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public int CodigoBarras { get; set; }


        public Articulo()
        {

        }

        public Articulo (string linea)
        {
            string[] datos;

            datos = linea.Split(';');

            Nombre= datos[0];
            Codigo = Convert.ToInt32(datos[1]);
            Descripcion = datos[2]; 
            CodigoBarras = Convert.ToInt32(datos[3]);   

        }

        public string GenerarRegistro()
        {
            return $"{Nombre};{Codigo};{Descripcion};{CodigoBarras}";
        }

        public override string ToString()
        {
            return $"{Nombre} {Codigo} {Descripcion} {CodigoBarras}";
        }



    }
}
