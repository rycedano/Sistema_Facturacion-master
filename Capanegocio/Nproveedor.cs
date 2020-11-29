using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capadatos;
using System.Data;

namespace Capanegocio
{
   public class Nproveedor
    {

        //Método Insertar que llama al método Insertar de la clase DProveedor
        //de la CapaDatos
        public static string Insertar(string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento,
            string direccion, string telefono, string email, string url)
        {
            Dproveedor Obj = new Dproveedor
            {
                Razon_Social = razon_proveedor,
                Sector_Comercial = sector_comercial,
                Tipo_Documento = tipo_documento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Url = url
            };

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DProveedor
        //de la CapaDatos
        public static string Editar(int idproveedor, string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento,
            string direccion, string telefono, string email, string url)
        {
            Dproveedor Obj = new Dproveedor
            {
                Idproveedor = idproveedor,
                Razon_Social = razon_proveedor,
                Sector_Comercial = sector_comercial,
                Tipo_Documento = tipo_documento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Url = url
            };
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DProveedor
        //de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            Dproveedor Obj = new Dproveedor
            {
                Idproveedor = idproveedor
            };
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DProveedor
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new Dproveedor().Mostrar();
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social
        //de la clase DProveedor de la CapaDatos

        public static DataTable BuscarRazon_social(string textobuscar)
        {
            Dproveedor Obj = new Dproveedor
            {
                TextoBuscar = textobuscar
            };
            return Obj.Buscarrazonsocial(Obj);
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social
        //de la clase DProveedor de la CapaDatos

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            Dproveedor Obj = new Dproveedor
            {
                TextoBuscar = textobuscar
            };
            return Obj.Buscarnum_documento(Obj);
        }

    }
}
