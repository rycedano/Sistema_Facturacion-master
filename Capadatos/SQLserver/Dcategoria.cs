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
   public  class Dcategoria : Conexion
    {
        private int _idcategoria;
        private string _nombre;
        private string _descripcion;

        private string _texto;

        public int Idcategoria { get => _idcategoria; set => _idcategoria = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Texto { get => _texto; set => _texto = value; }


        public Dcategoria()
        {

        }

        

        public Dcategoria(Categorias Cat)
        {
            this.Idcategoria = Cat.idcategoria;
            this.Nombre = Cat.nombre;
            this.Descripcion = Cat.descripcion;
            this.Texto = Cat.textobuscar;
        }


        public string Insertar(Dcategoria categoria)
        {
            string respuesta = "";
            using (var Sqlcon = Getconection())
            {
                try
                {
                    Sqlcon.Open();
                    using(var sqlcomand =GetSqlCommand())
                    {
                        sqlcomand.Connection = Sqlcon;
                        sqlcomand.CommandText = "spinsertar_categoria";
                        sqlcomand.CommandType = CommandType.StoredProcedure;

                        SqlParameter paridcategoria = new SqlParameter
                        {
                            ParameterName = "@idcategoria",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                        sqlcomand.Parameters.Add(paridcategoria);


                        SqlParameter parnombre = new SqlParameter
                        {
                            ParameterName = "@Nombre",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = categoria.Nombre
                        };
                        sqlcomand.Parameters.Add(parnombre);

                        SqlParameter pardescripcion = new SqlParameter
                        {
                            ParameterName = "@descripcion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 256,
                            Value = categoria.Descripcion
                        };
                        sqlcomand.Parameters.Add(pardescripcion);

                        respuesta = sqlcomand.ExecuteNonQuery() == 1 ? "OK": "No se registro el registro";

                        //98827
                    }


                }
                catch (Exception ex)
                {
                    respuesta = ex.Message;
                    
                }
            }
            return respuesta;
        }

        public string Editar(Dcategoria dcategoria)
        {
             

            string respuesta = "";

            using (var Sqlcon = Getconection())
            {
                try
                {
                    Sqlcon.Open();
                    using (var sqlcomand = GetSqlCommand())
                    {
                        sqlcomand.Connection = Sqlcon;
                        sqlcomand.CommandText = "speditar_categoria";
                        sqlcomand.CommandType = CommandType.StoredProcedure;

                        SqlParameter paridcategoria = new SqlParameter
                        {
                            ParameterName = "@idcategoria",
                            SqlDbType = SqlDbType.Int,
                            Value = dcategoria.Idcategoria
                        };
                        sqlcomand.Parameters.Add(paridcategoria);


                        SqlParameter parnombre = new SqlParameter
                        {
                            ParameterName = "@Nombre",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = dcategoria.Nombre
                        };
                        sqlcomand.Parameters.Add(parnombre);

                        SqlParameter pardescripcion = new SqlParameter
                        {
                            ParameterName = "@descripcion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 256,
                            Value = dcategoria.Descripcion
                        };
                        sqlcomand.Parameters.Add(pardescripcion);

                        respuesta = sqlcomand.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

                        //98827
                    }


                }
                catch (Exception ex)
                {
                    respuesta = ex.Message;

                }
            }
            return respuesta;
        }

        public string Eliminar (Dcategoria dcategoria)
        {
            string Respuesta = "";

            using (var Sqlcon = Getconection())
            {
                try
                {
                    Sqlcon.Open();
                    using (var sqlcomand = GetSqlCommand())
                    {
                        sqlcomand.Connection = Sqlcon;
                        sqlcomand.CommandText = "speliminar_categoria";
                        sqlcomand.CommandType = CommandType.StoredProcedure;

                        SqlParameter paridcategoria = new SqlParameter
                        {
                            ParameterName = "@idcategoria",
                            SqlDbType = SqlDbType.Int,
                            Value = dcategoria.Idcategoria
                        };
                        sqlcomand.Parameters.Add(paridcategoria);



                        Respuesta = sqlcomand.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

                        //98827
                    }


                }
                catch (Exception ex)
                {
                    Respuesta = ex.Message;

                }
            }
            return Respuesta;
        }

        public DataTable Mostrar()
        {
            using (var Sqlcon = Getconection())
            {               
                    Sqlcon.Open();
                using (var Datatable = GetDataTable("Categoria"))
                {
                    try
                    {
                        using (var sqlcmd = GetSqlCommand())
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.CommandText = "spmostrar_categoria";
                            sqlcmd.CommandType = CommandType.StoredProcedure;

                            using (var sqldata = Getdataadapter(sqlcmd))
                            {
                                sqldata.Fill(Datatable);
                            }
                        }
                    }
                    catch (Exception)
                    {                       
                    }
                    return Datatable;
                }                             
            }      
        }

        public DataTable Buscarnombre (Dcategoria categoria)
        {
            using (var Sqlcon = Getconection())
            {
                Sqlcon.Open();
                using (var Datatable = GetDataTable("Categoria"))
                {
                    try
                    {
                        using (var sqlcmd = GetSqlCommand())
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.CommandText = "spbuscar_categoria";
                            sqlcmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter partexto = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = categoria.Texto
                            };
                            sqlcmd.Parameters.Add(partexto);

                            using (var sqldata = Getdataadapter(sqlcmd))
                            {
                                sqldata.Fill(Datatable);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    return Datatable;
                }

            }
        }
    }
}
