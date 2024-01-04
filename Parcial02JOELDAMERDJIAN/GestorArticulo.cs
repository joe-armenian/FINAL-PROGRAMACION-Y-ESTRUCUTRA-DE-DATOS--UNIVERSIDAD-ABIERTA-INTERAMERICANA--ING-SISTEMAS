using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial02JOELDAMERDJIAN
{
   public class GestorArticulo
    {
        public string Ruta { get; set; }

        public GestorArticulo(string ruta)
        {
            Ruta = ruta;
        }

        public void RegistrarArticulo(Articulo articulo)
        {
            FileStream fs= new FileStream(Ruta,FileMode.Append,FileAccess.Write);   

            using (StreamWriter sw= new StreamWriter(fs)) 
            {

                sw.WriteLine(articulo.GenerarRegistro());

            }

            fs.Close();

        }

        public void EliminarArticulo(int numero)
        {
            string output=string.Empty;

            FileStream fs= new FileStream(Ruta,FileMode.OpenOrCreate,FileAccess.Read);  

            using (StreamReader sr= new StreamReader(fs)) 
            {
              string linea=sr.ReadLine();
              
                while (linea!=null)
                {
                    Articulo articulo= new Articulo(linea);

                    if (articulo.Codigo!=numero) 
                    {
                        output += linea + Environment.NewLine; 
                    }
                    linea=sr.ReadLine();
                }

            }
            fs.Close();

            fs = new FileStream(Ruta, FileMode.Truncate, FileAccess.Write);

            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(output);
            }
           
           fs.Close();
        
        
        }


        public void ModificarArticulo(int numero,Articulo articuloModificado)
        {
            string output = string.Empty;

            FileStream fs = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader sr = new StreamReader(fs))
            {
                string linea = sr.ReadLine();

                while (linea != null)
                {
                    Articulo articulo = new Articulo(linea);

                    if (articulo.Codigo == numero)
                    {
                        articulo = articuloModificado;
                    }

                    output += articulo.GenerarRegistro() + Environment.NewLine;

                    linea = sr.ReadLine();
                }

            }
            fs.Close();

            fs = new FileStream(Ruta, FileMode.Truncate, FileAccess.Write);

            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(output);
            }

            fs.Close();


        }



        public List<Articulo> ListarArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();

            FileStream fs = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader sr = new StreamReader(fs))
            {
                string linea = sr.ReadLine();

                while (linea != null)
                {
                    Articulo articulo = new Articulo(linea);
                    articulos.Add(articulo);
                    linea = sr.ReadLine();
                }

            }
            fs.Close();

            return articulos;
        }









    }
}
