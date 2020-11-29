using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capadatos;

namespace Capanegocio
{
    public class Ncategoria
    {

        public static string Insertar(string nombre, string descripcion)
        {
            Dcategoria obj = new Dcategoria
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
            return obj.Insertar(obj);
        }


        public static string Editar(int idcategoria,string nombre, string descripcion)
        {
            Dcategoria obj = new Dcategoria
            {
                Idcategoria = idcategoria,
                Nombre = nombre,
                Descripcion = descripcion
            };
            return obj.Editar(obj);
        }

        public static string Eliminar(int idcategoria)
        {
            Dcategoria obj = new Dcategoria
            {
                Idcategoria = idcategoria
            };
            return obj.Eliminar(obj);
        }


        public static DataTable Mostrar()
        {
            return new Dcategoria().Mostrar();
        }


        public static DataTable Buscarnombre(string texto)
        {
            Dcategoria obj = new Dcategoria
            {
                Texto = texto
            };
            return obj.Buscarnombre(obj);
        }


    }
}
