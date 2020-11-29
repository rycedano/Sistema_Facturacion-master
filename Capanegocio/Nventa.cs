using Capadatos.SQLserver;
using System;
using System.Collections.Generic;
using System.Data;

namespace Capanegocio
{
   public class Nventa
    {

        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha,
           string tipo_comprobante, string serie, string correlativo, decimal igv,
           DataTable dtDetalles)
        {
            Dventa Obj = new Dventa
            {
                Idcliente = idcliente,
                Idtrabajador = idtrabajador,
                Fecha = fecha,
                Tipo_Comprobante = tipo_comprobante,
                Serie = serie,
                Correlativo = correlativo,
                Igv = igv
            };
            List<DDetalle_venta> detalles = new List<DDetalle_venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_venta detalle = new DDetalle_venta
                {
                    Iddetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString()),
                    Cantidad = Convert.ToInt32(row["cantidad"].ToString()),
                    Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString()),
                    Descuento = Convert.ToDecimal(row["descuento"].ToString())
                };

                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }

        public static string Eliminar(int idventa)
        {
            Dventa Obj = new Dventa
            {
                Idventa = idventa
            };
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DVenta
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            
            
                return new Dventa().Mostrar();
            
        }

        //Método BuscarFecha que llama al método BuscarFecha
        //de la clase DVenta de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            Dventa Obj = new Dventa();
            return Obj.Buscarfechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            Dventa Obj = new Dventa();
            return Obj.Mostrardetalleventa(textobuscar);
        }
        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            Dventa Obj = new Dventa();
            return Obj.Mostrararticulo_venta_nombre(textobuscar);
        }
        public static DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            Dventa Obj = new Dventa();
            return Obj.Mostraraarticulo_venta_codigo(textobuscar);
        }

    }
}
