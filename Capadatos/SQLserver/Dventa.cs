using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capadatos.SQLserver
{
  public class Dventa:Conexion
    {
        private int _Idventa;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;

        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }



        public Dventa()
        {
        }
      
        public Dventa(Venta Ven)
        {
            this.Idventa = Ven.idventa;
            this.Idcliente = Ven.idcliente;
            this.Idtrabajador = Ven.idtrabajador;
            this.Fecha = Ven.fecha;
            this.Tipo_Comprobante = Ven.tipo_comprobante;
            this.Serie = Ven.serie;
            this.Correlativo = Ven.correlativo;
            this.Igv = Ven.igv;
        }

        public string Disminuirstock(int iddetalle_ingreso, int cantidad)
        {
            using (var SqlCon = Getconection())
            {
                SqlCon.Open();
                string Respuesta = "";
                try
                {
                    using (SqlCommand SqlCmd = GetSqlCommand()) 
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "spdisminuir_stock";
                        SqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIddetalle_Ingreso = new SqlParameter
                        {
                            ParameterName = "@iddetalle_ingreso",
                            SqlDbType = SqlDbType.Int,
                            Value = iddetalle_ingreso
                        };
                        SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                        SqlParameter ParCantidad = new SqlParameter
                        {
                            ParameterName = "@cantidad",
                            SqlDbType = SqlDbType.Int,
                            Value = cantidad
                        };
                        SqlCmd.Parameters.Add(ParCantidad);


                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Disminuyo es stock";
                    }
                }
                catch (Exception ex)
                {
                    Respuesta = ex.Message;
                    
                }
                return Respuesta;
            }
        }



        public string Insertar(Dventa Venta, List<DDetalle_venta> Detalle)
        {
            SqlConnection SqlCon = Getconection();
            string Respuesta = "";
            SqlCon.Open();                
            SqlTransaction Sqltra = SqlCon.BeginTransaction();

            try
            {
                    using (var SqlCmd = GetSqlCommand())
                    {
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.Transaction = Sqltra;
                    SqlCmd.CommandText = "spinsertar_venta2";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIdventa = new SqlParameter
                    {
                        ParameterName = "@idventa",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    SqlCmd.Parameters.Add(ParIdventa);

                    SqlParameter ParIdCliente = new SqlParameter
                    {
                        ParameterName = "@idcliente",
                        SqlDbType = SqlDbType.Int,
                        Value = Venta.Idcliente
                    };
                    SqlCmd.Parameters.Add(ParIdCliente);

                    SqlParameter ParIdtrabajador = new SqlParameter
                    {
                        ParameterName = "@idusuario",
                        SqlDbType = SqlDbType.Int,
                        Value = Venta.Idtrabajador
                    };
                    SqlCmd.Parameters.Add(ParIdtrabajador);

                    SqlParameter ParFecha = new SqlParameter
                    {
                        ParameterName = "@fecha",
                        SqlDbType = SqlDbType.Date,
                        Value = Venta.Fecha
                    };
                    SqlCmd.Parameters.Add(ParFecha);

                    SqlParameter ParTipo_Comprobante = new SqlParameter
                    {
                        ParameterName = "@tipo_comprovante",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 20,
                        Value = Venta.Tipo_Comprobante
                    };
                    SqlCmd.Parameters.Add(ParTipo_Comprobante);

                    SqlParameter ParSerie = new SqlParameter
                    {
                        ParameterName = "@serie",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 4,
                        Value = Venta.Serie
                    };
                    SqlCmd.Parameters.Add(ParSerie);

                    SqlParameter ParCorrelativo = new SqlParameter
                    {
                        ParameterName = "@correlativo",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 7,
                        Value = Venta.Correlativo
                    };
                    SqlCmd.Parameters.Add(ParCorrelativo);

                    SqlParameter ParIgv = new SqlParameter
                    {
                        ParameterName = "@igv",
                        SqlDbType = SqlDbType.Decimal,
                        Precision = 4,
                        Scale = 2,
                        Value = Venta.Igv
                    };
                    SqlCmd.Parameters.Add(ParIgv);


                    Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto la venta";


                    if (Respuesta.Equals("OK"))
                    {
                        this.Idventa = Convert.ToInt32(SqlCmd.Parameters["@idventa"].Value);
                        foreach (DDetalle_venta det in Detalle)
                        {
                            det.Idventa = this.Idventa;
                            //Llamar al método insertar de la clase DDetalle_Ingreso
                            Respuesta = det.Insertar(det, ref SqlCon, ref Sqltra);
                            if (!Respuesta.Equals("OK"))
                            {
                                break;
                            }
                            else
                            {
                                //Actualizamos el stock
                                Respuesta = Disminuirstock(det.Iddetalle_ingreso, det.Cantidad);
                                if (!Respuesta.Equals("OK"))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (Respuesta.Equals("OK"))
                    {
                        Sqltra.Commit();
                    }
                    else
                    {
                        Sqltra.Rollback();
                    }


                    }
                }
                catch (Exception ex)
                {

                Respuesta = ex.Message;
                    
                }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            SqlCon.Close();
            return Respuesta;          
        }


        public string Eliminar(Dventa Venta)
        {
            using (var SqlCon = Getconection())
            {
                SqlCon.Open();
                string Respuesta = "";
                try
                {
                    using (var SqlCmd= GetSqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "speliminar_venta";
                        SqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdventa = new SqlParameter
                        {
                            ParameterName = "@idventa",
                            SqlDbType = SqlDbType.Int,
                            Value = Venta.Idventa
                        };
                        SqlCmd.Parameters.Add(ParIdventa);

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK";
                    }
                }
                catch (Exception ex)
                {
                    Respuesta = ex.Message;
                }
                return Respuesta;
            }
        }


      
        
        
        public DataTable Mostrar()
        {
            using (var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("venta"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spmostrar_venta";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            using(var Sqldata = Getdataadapter(SqlCmd))
                            {
                                Sqldata.Fill(Dtresultado);
                            }
                        }
                    }
                    catch (Exception)
                    {                       
                    }
                    return Dtresultado;
                }
            }
        }


        public DataTable Buscarfechas( String Texto, String Texto1)
        {
            using (var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("venta"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spbuscar_venta_fecha";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Texto
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar);

                            SqlParameter ParTextoBuscar2 = new SqlParameter
                            {
                                ParameterName = "@texto1",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Texto1
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar2);

                            using (var Sqldat = Getdataadapter(SqlCmd))
                            {
                                Sqldat.Fill(Dtresultado);
                            }
                        }
                    }
                    catch (Exception)
                    {               
                    }
                    return Dtresultado;
                }
            }
        }

        public DataTable Mostrardetalleventa(String Texto)
        {
            using (var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("detalle_venta"))
                {
                    try
                    {
                        using(var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spmostrar_detalle_venta";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Texto
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar);
                            using(var Sqldata = Getdataadapter(SqlCmd))
                            {
                                Sqldata.Fill(Dtresultado);
                            }
                        }
                    }
                    catch (Exception)
                    {                       
                    }
                    return Dtresultado;
                }
            }
        }

        public DataTable Mostrararticulo_venta_nombre(String Texto)
        {
            using (var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("articulos"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spbuscararticulo_venta_nombre";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Texto
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar);

                            using (var Sqldata = Getdataadapter(SqlCmd))
                            {
                                Sqldata.Fill(Dtresultado);
                            }
                        }
                    }
                    catch (Exception)
                    {                       
                    }
                    return Dtresultado;
                }
            }
        }


        public DataTable Mostraraarticulo_venta_codigo(String Texto)
        {
            using (var SqlCon = Getconection())
            {
                using(var Dtresultado = GetDataTable("articulos"))
                {
                    try
                    {
                        using(var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spbuscararticulo_venta_codigo";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Texto
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar);
                            using (var Sqldata = Getdataadapter(SqlCmd))
                            {
                                Sqldata.Fill(Dtresultado);
                            }

                        }
                    }
                    catch (Exception)
                    {                      
                    }
                    return Dtresultado;
                }
            }
        }








    }
}
