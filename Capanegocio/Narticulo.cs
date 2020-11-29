using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capadatos;
using System.Data;

namespace Capanegocio
{
   public class Narticulo
    {
        //Método Insertar que llama al método Insertar de la clase DPresentacion
        //de la CapaDatos
        public static string Insertar(string codigo,string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion )
        {
            Darticulo Obj = new Darticulo
            {
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = descripcion,
                Imagen = imagen,
                Idcategoria = idcategoria,
                Idpresentacion = idpresentacion
            };
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DPresentacion
        //de la CapaDatos
        public static string Editar(int idarticulo,string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            Darticulo Obj = new Darticulo
            {
                Idarticulo = idarticulo,
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = descripcion,
                Imagen = imagen,
                Idcategoria = idcategoria,
                Idpresentacion = idpresentacion
            };
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DPresentacion
        //de la CapaDatos
        public static string Eliminar(int idpresentacion)
        {
            Darticulo Obj = new Darticulo
            {
                Idpresentacion = idpresentacion
            };
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DPresentacion
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Darticulo().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DPresentacion de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            Darticulo Obj = new Darticulo
            {
                TextoBuscar = textobuscar
            };
            return Obj.Buscarnombre(Obj);
        }
    }
}
