using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capadatos.SQLserver
{
   public class Dingreso:Conexion
    {

        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Estado { get => _Estado; set => _Estado = value; }




        public Dingreso()
        {

        }


        public Dingreso(Ingreso I)
        {
            this.Idingreso = I.idingreso;
            this.Idtrabajador = I.idtrabajador;
            this.Idproveedor = I.idproveedor;
            this.Fecha = I.fecha;
            this.Tipo_Comprobante = I.tipo_comprobante;
            this.Serie = I.serie;
            this.Correlativo = I.correlativo;
            this.Igv = I.igv;
            this.Estado = I.estado;
        }


        


        public string Insertar3(Dingreso Ingreso, List<Ddetalleingreso> Detalle)
        {
            SqlConnection SqlCon = Getconection();
            string Respuesta ="";
            SqlCon.Open();
            SqlTransaction Sqltra = SqlCon.BeginTransaction();          
                try
                {
                    using (var SqlCmd = GetSqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.Transaction = Sqltra;
                        SqlCmd.CommandText = "spinsertar_ingreso";
                        SqlCmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParIdingreso = new SqlParameter
                        {
                            ParameterName = "@idingreso",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                        SqlCmd.Parameters.Add(ParIdingreso);

                        SqlParameter ParIdtrabajador = new SqlParameter
                        {
                            ParameterName = "@idtrabajador",
                            SqlDbType = SqlDbType.Int,
                            Value = Ingreso.Idtrabajador
                        };
                        SqlCmd.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParIdproveedor = new SqlParameter
                        {
                            ParameterName = "@idproveedor",
                            SqlDbType = SqlDbType.Int,
                            Value = Ingreso.Idproveedor
                        };
                        SqlCmd.Parameters.Add(ParIdproveedor);


                        SqlParameter ParFecha = new SqlParameter
                        {
                            ParameterName = "@fecha",
                            SqlDbType = SqlDbType.Date,
                            Value = Ingreso.Fecha
                        };
                        SqlCmd.Parameters.Add(ParFecha);

                        SqlParameter ParTipo_Comprobante = new SqlParameter
                        {
                            ParameterName = "@tipocomprovante",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Ingreso.Tipo_Comprobante
                        };
                        SqlCmd.Parameters.Add(ParTipo_Comprobante);

                        SqlParameter ParSerie = new SqlParameter
                        {
                            ParameterName = "@serie",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 4,
                            Value = Ingreso.Serie
                        };
                        SqlCmd.Parameters.Add(ParSerie);

                        SqlParameter ParCorrelativo = new SqlParameter
                        {
                            ParameterName = "@correlativo",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 7,
                            Value = Ingreso.Correlativo
                        };
                        SqlCmd.Parameters.Add(ParCorrelativo);

                        SqlParameter ParIgv = new SqlParameter
                        {
                            ParameterName = "@igv",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 4,
                            Scale = 2,
                            Value = Ingreso.Igv
                        };
                        SqlCmd.Parameters.Add(ParIgv);

                        SqlParameter ParEstado = new SqlParameter
                        {
                            ParameterName = "@estado",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 7,
                            Value = Ingreso.Estado
                        };
                        SqlCmd.Parameters.Add(ParEstado);


                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Registro";

                        if (Respuesta.Equals("OK"))
                        {
                            this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);
                            foreach (Ddetalleingreso det in Detalle)
                            {
                                det.Idingreso = this.Idingreso;
                                Respuesta = det.Insertar2(det,ref SqlCon,  ref Sqltra);
                                if (!Respuesta.Equals("OK"))
                                {
                                    break;
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

        public string Anular(Dingreso Ingreso)
        {
            using (var SqlCon = Getconection())
            {
                SqlCon.Open();
                string Respuesta = "";
                using (var SqlCmd =GetSqlCommand())
                {
                    try
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "spanular_ingreso";
                        SqlCmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParIdingreso = new SqlParameter
                        {
                            ParameterName = "@idingreso",
                            SqlDbType = SqlDbType.Int,
                            Value = Ingreso.Idingreso
                        };
                        SqlCmd.Parameters.Add(ParIdingreso);

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Anular el Registro de ingreso";

                    }
                    catch (Exception ex)
                    {

                        Respuesta = ex.Message;
                    }
                    return Respuesta;
                }
            }
        }


        public DataTable Mostrar()
        {
            using (var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("ingreso"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spmostrar_ingreso";
                            SqlCmd.CommandType = CommandType.StoredProcedure;


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


        public DataTable BuscarFechas( String Texto, String Textobuscar)
        {
            using (var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("ingreso"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spbuscar_ingreso_fecha";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto ",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Texto
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar);

                            SqlParameter ParTextoBuscar2 = new SqlParameter
                            {
                                ParameterName = "@textobuscar",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Textobuscar
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar2);
                            using (var Sqldat = Getdataadapter(SqlCmd))
                            {
                                Sqldat.Fill(Dtresultado);
                            }
                        }
                    }
                    catch (Exception )
                    {               
                    }
                    return Dtresultado;
                }
            }
        }


        public DataTable Mostrardetalle(String Texto)

        {
            using (var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("detalle_ingreso"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spmostrar_detalle_ingreso";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Texto
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar);

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


    }
}
