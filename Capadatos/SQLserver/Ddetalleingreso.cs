using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capadatos.SQLserver;

namespace Capadatos
{
   public class Ddetalleingreso:Conexion
    {
        private int _Iddetalle_Ingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;

        public int Iddetalle_Ingreso { get => _Iddetalle_Ingreso; set => _Iddetalle_Ingreso = value; }
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal Precio_Compra { get => _Precio_Compra; set => _Precio_Compra = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public int Stock_Inicial { get => _Stock_Inicial; set => _Stock_Inicial = value; }
        public int Stock_Actual { get => _Stock_Actual; set => _Stock_Actual = value; }
        public DateTime Fecha_Produccion { get => _Fecha_Produccion; set => _Fecha_Produccion = value; }
        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }



        public Ddetalleingreso()
        {

        }
        
        public Ddetalleingreso(detalleingreso Di)
        {
            this.Iddetalle_Ingreso = Di.iddetalle_ingreso;
            this.Idingreso = Di.idingreso;
            this.Idarticulo = Di.idarticulo;
            this.Precio_Compra = Di.precio_compra;
            this.Precio_Venta = Di.precio_venta;
            this.Stock_Inicial = Di.stock_inicial;
            this.Stock_Actual = Di.stock_actual;
            this.Fecha_Produccion = Di.fecha_produccion;
            this.Fecha_Vencimiento = Di.fecha_vencimiento;

        }

        public string Insertar2(Ddetalleingreso Detalleingreso, ref SqlConnection SqlCon ,ref SqlTransaction sqltra )
        {
            string Respuesta = "";
            try
            {
                
                SqlCommand SqlCmd = new SqlCommand
                {                  
                    Connection = SqlCon,
                    Transaction = sqltra,
                    CommandText = "spinsertar_detalle_ingreso",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIddetalle_Ingreso = new SqlParameter
                {
                    ParameterName = "@iddetalle_ingreso",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParIdingreso = new SqlParameter
                {
                    ParameterName = "@idingreso",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalleingreso.Idingreso
                };
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo = new SqlParameter
                {
                    ParameterName = "@idarticulo",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalleingreso.Idarticulo
                };
                SqlCmd.Parameters.Add(ParIdarticulo);


                SqlParameter ParPrecio_Compra = new SqlParameter
                {
                    ParameterName = "@precio_compra",
                    SqlDbType = SqlDbType.Money,
                    Value = Detalleingreso.Precio_Compra
                };
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter
                {
                    ParameterName = "@precio_venta",
                    SqlDbType = SqlDbType.Money,
                    Value = Detalleingreso.Precio_Venta
                };
                SqlCmd.Parameters.Add(ParPrecio_Venta);


                SqlParameter ParStock_Actual = new SqlParameter
                {
                    ParameterName = "@stock_inicial",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalleingreso.Stock_Actual
                };
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParStock_Inicial = new SqlParameter
                {
                    ParameterName = "@stock_actual",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalleingreso.Stock_Inicial
                };
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParFecha_Produccion = new SqlParameter
                {
                    ParameterName = "@fecha_produccion",
                    SqlDbType = SqlDbType.Date,
                    Value = Detalleingreso.Fecha_Produccion
                };
                SqlCmd.Parameters.Add(ParFecha_Produccion);

                SqlParameter ParFecha_Vencimiento = new SqlParameter
                {
                    ParameterName = "@fecha_vencimiento",
                    SqlDbType = SqlDbType.Date,
                    Value = Detalleingreso.Fecha_Vencimiento
                };
                SqlCmd.Parameters.Add(ParFecha_Vencimiento);

                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Inserto  el Registro";

            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
                
            }           
            return Respuesta;
        }      
    }
}
