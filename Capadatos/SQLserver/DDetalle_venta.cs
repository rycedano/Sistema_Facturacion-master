using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capadatos.SQLserver
{
    public class DDetalle_venta:Conexion
    {

        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_ingreso;
        private int _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Descuento;

        public int Iddetalle_venta { get => _Iddetalle_venta; set => _Iddetalle_venta = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Iddetalle_ingreso { get => _Iddetalle_ingreso; set => _Iddetalle_ingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }

       public DDetalle_venta()
        {

        }

        public DDetalle_venta(detalleventa Dv)
        {
            this.Iddetalle_venta = Dv.iddetalle_venta;
            this.Idventa = Dv.idventa;
            this.Iddetalle_ingreso = Dv.iddetalle_ingreso;
            this.Cantidad = Dv.cantidad;
            this.Precio_Venta = Dv.precio_venta;
            this.Descuento = Dv.descuento;
        }


        public string Insertar(DDetalle_venta Detalleventa,
            ref SqlConnection SqlCon, ref SqlTransaction Sqltra)
        {
            string Respuesta = "";
            try
            {
                using (var SqlCmd = GetSqlCommand())
                {
                   
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.Transaction = Sqltra;
                    SqlCmd.CommandText = "spinsertar_detalle_venta";
                    SqlCmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter ParIddetalle_Venta = new SqlParameter
                    {
                        ParameterName = "@iddetalle_venta",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    SqlCmd.Parameters.Add(ParIddetalle_Venta);

                    SqlParameter ParIdventa = new SqlParameter
                    {
                        ParameterName = "@idventa",
                        SqlDbType = SqlDbType.Int,
                        Value = Detalleventa.Idventa
                    };
                    SqlCmd.Parameters.Add(ParIdventa);

                    SqlParameter ParIddetalle_ingreso = new SqlParameter
                    {
                        ParameterName = "@iddetalle_ingreso",
                        SqlDbType = SqlDbType.Int,
                        Value = Detalleventa.Iddetalle_ingreso
                    };
                    SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                    SqlParameter ParCantidad = new SqlParameter
                    {
                        ParameterName = "@cantidad",
                        SqlDbType = SqlDbType.Int,
                        Value = Detalleventa.Cantidad
                    };
                    SqlCmd.Parameters.Add(ParCantidad);

                    SqlParameter ParPrecioVenta = new SqlParameter
                    {
                        ParameterName = "@precio_venta",
                        SqlDbType = SqlDbType.Money,
                        Value = Detalleventa.Precio_Venta
                    };
                    SqlCmd.Parameters.Add(ParPrecioVenta);

                    SqlParameter ParDescuento = new SqlParameter
                    {
                        ParameterName = "@descuento",
                        SqlDbType = SqlDbType.Money,
                        Value = Detalleventa.Descuento
                    };
                    SqlCmd.Parameters.Add(ParDescuento);

                    Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el detalle";
                }
            }
            catch (Exception ex )
            {
                Respuesta = ex.Message;
                
            }

            return Respuesta;
        }







    }
}
