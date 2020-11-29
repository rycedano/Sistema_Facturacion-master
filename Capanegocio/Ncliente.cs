using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capadatos;

namespace Capanegocio
{
   public class Ncliente
    {

        public static string Insertar(string nombre, string apellidos, string sexo,
           DateTime fecha_nacimiento,
           string tipo_documento, string num_documento,
           string direccion, string telefono, string email)
        {
            Dcliente Obj = new Dcliente
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Sexo = sexo,
                Fecha_Nacimiento = fecha_nacimiento,
                Tipo_Documento = tipo_documento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCliente
        //de la CapaDatos
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento,
            string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            Dcliente Obj = new Dcliente
            {
                Idcliente = idcliente,
                Nombre = nombre,
                Apellidos = apellidos,
                Sexo = sexo,
                Fecha_Nacimiento = fecha_nacimiento,
                Tipo_Documento = tipo_documento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCliente
        //de la CapaDatos
        public static string Eliminar(int idcliente)
        {
            Dcliente Obj = new Dcliente
            {
                Idcliente = idcliente
            };
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCliente
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dcliente().Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos
        //de la clase DCLiente de la CapaDatos

        public static DataTable BuscarApellidos(string textobuscar)
        {
            Dcliente Obj = new Dcliente
            {
                TextoBuscar = textobuscar
            };
            return Obj.BuscarApellidos(Obj);
        }

        //Método BuscarNum_Documento que llama al método BuscarNum_Documento
        //de la clase DCliente de la CapaDatos

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            Dcliente Obj = new Dcliente
            {
                TextoBuscar = textobuscar
            };
            return Obj.Buscarnum_documento(Obj);
        }

    }
}
