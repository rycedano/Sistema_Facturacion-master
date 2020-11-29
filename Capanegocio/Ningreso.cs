using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capadatos.SQLserver;
using Capadatos;

namespace Capanegocio
{
   public class Ningreso
    {

        public static string Insertar3(int idtrabajador, int idproveedor, DateTime fecha,
           string tipo_comprobante, string serie, string correlativo, decimal igv,
           string estado, DataTable dtDetalles)
        {
            Dingreso Obj = new Dingreso
            {
                Idtrabajador = idtrabajador,
                Idproveedor = idproveedor,
                Fecha = fecha,
                Tipo_Comprobante = tipo_comprobante,
                Serie = serie,
                Correlativo = correlativo,
                Igv = igv,
                Estado = estado
            };

            List<Ddetalleingreso> detalles = new List<Ddetalleingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                Ddetalleingreso detalle = new Ddetalleingreso
                {
                    Idarticulo = Convert.ToInt32(row["idarticulo"].ToString()),
                    Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString()),
                    Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString()),
                    Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString()),
                    Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString()),
                    Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString()),
                    Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString())
                };
                detalles.Add(detalle);
            }
            return Obj.Insertar3(Obj, detalles);
        }
        public static string Anular(int idingreso)
        {
            Dingreso Obj = new Dingreso
            {
                Idingreso = idingreso
            };
            return Obj.Anular(Obj);
        }


        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static DataTable Mostrar() => new Dingreso().Mostrar();

        //Método BuscarFecha que llama al método BuscarNombre
        //de la clase DIngreso de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            Dingreso Obj = new Dingreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            Dingreso Obj = new Dingreso();
            return Obj.Mostrardetalle(textobuscar);
        }
    }
}
