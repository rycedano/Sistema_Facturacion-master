using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capadatos;
using System.Data;

namespace Capanegocio
{
   public class Npresentacion
    {
        //Método Insertar que llama al método Insertar de la clase DPresentacion
        //de la CapaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            Dpresentacion Obj = new Dpresentacion
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DPresentacion
        //de la CapaDatos
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            Dpresentacion Obj = new Dpresentacion
            {
                Idpresentacion = idpresentacion,
                Nombre = nombre,
                Descripcion = descripcion
            };
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DPresentacion
        //de la CapaDatos
        public static string Eliminar(int idpresentacion)
        {
            Dpresentacion Obj = new Dpresentacion
            {
                Idpresentacion = idpresentacion
            };
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DPresentacion
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dpresentacion().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DPresentacion de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            Dpresentacion Obj = new Dpresentacion
            {
                TextoBuscar = textobuscar
            };
            return Obj.BuscarNombre(Obj);
        }
    }
}
