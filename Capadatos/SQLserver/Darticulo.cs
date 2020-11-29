using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Capadatos.SQLserver;

namespace Capadatos
{
   public class Darticulo: Conexion
    {

        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _TextoBuscar;

        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        public Darticulo()
        {

        }

        public Darticulo(Articulos A)
        {
            Articulos articulos1 = new Articulos();
            this.Idarticulo = A.idarticulo;
            this.Codigo = A.codigo;
            this.Nombre = A.nombre;
            this.Descripcion = A.descripcion;
            this.Imagen = A.imagen;
            this.Idcategoria = A.idcategoria;
            this.Idpresentacion = A.idpresentacion;
            this.TextoBuscar = A.textobuscar;

        }

        public string Insertar(Darticulo Articulo)
        {
            using (var Sqlcon = Getconection())
            {
                string respuesta = "";
                try
                {
                    Sqlcon.Open();
                    using (var sqlcmd = GetSqlCommand())
                    {
                        sqlcmd.Connection = Sqlcon;
                        sqlcmd.CommandText = "spinsertar_articulo2";
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter paridarticulo = new SqlParameter
                        {
                            ParameterName = "@idarticulo",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                        sqlcmd.Parameters.Add(paridarticulo);

                        SqlParameter ParCodigo = new SqlParameter
                        {
                            ParameterName = "@codigo",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Articulo.Codigo
                        };
                        sqlcmd.Parameters.Add(ParCodigo);

                        SqlParameter ParNombre = new SqlParameter
                        {
                            ParameterName = "@nombre",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Articulo.Nombre
                        };
                        sqlcmd.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter
                        {
                            ParameterName = "@descripcion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 250,
                            Value = Articulo.Descripcion
                        };
                        sqlcmd.Parameters.Add(ParDescripcion);

                        SqlParameter ParImagen = new SqlParameter
                        {
                            ParameterName = "@imagen",
                            SqlDbType = SqlDbType.Image,
                            Value = Articulo.Imagen
                        };
                        sqlcmd.Parameters.Add(ParImagen);

                        SqlParameter ParIdcategoria = new SqlParameter
                        {
                            ParameterName = "@idcategoria",
                            SqlDbType = SqlDbType.VarChar,
                            Value = Articulo.Idcategoria
                        };
                        sqlcmd.Parameters.Add(ParIdcategoria);

                        SqlParameter ParIdpresentacion = new SqlParameter
                        {
                            ParameterName = "@idpresentacion",
                            SqlDbType = SqlDbType.VarChar,
                            Value = Articulo.Idpresentacion
                        };
                        sqlcmd.Parameters.Add(ParIdpresentacion);

                        respuesta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : " No se inserto el registro";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = ex.Message;                 
                }
                return respuesta;
            }
        }

        public string Editar(Darticulo Articulo)
        {
            using (var sqlcon = Getconection())
            {
                string Respuesta = "";
                
                try
                { 
                    using (var sqlcmd = GetSqlCommand())
                    {

                        sqlcon.Open();
                        sqlcmd.Connection = sqlcon;
                        sqlcmd.CommandText = "spinsertar_articulo2";
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter
                        {
                            ParameterName = "@idarticulo",
                            SqlDbType = SqlDbType.Int,
                            Value = Articulo.Idarticulo
                        };
                        sqlcmd.Parameters.Add(ParIdarticulo);

                        SqlParameter ParCodigo = new SqlParameter
                        {
                            ParameterName = "@codigo",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Articulo.Codigo
                        };
                        sqlcmd.Parameters.Add(ParCodigo);

                        SqlParameter ParNombre = new SqlParameter
                        {
                            ParameterName = "@Nombre",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Articulo.Nombre
                        };
                        sqlcmd.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter
                        {
                            ParameterName = "@descripcion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 250,
                            Value = Articulo.Descripcion
                        };
                        sqlcmd.Parameters.Add(ParDescripcion);

                        SqlParameter ParImagen = new SqlParameter
                        {
                            ParameterName = "@imagen",
                            SqlDbType = SqlDbType.Image,
                            Value = Articulo.Imagen
                        };
                        sqlcmd.Parameters.Add(ParImagen);

                        SqlParameter ParIdcategoria = new SqlParameter
                        {
                            ParameterName = "@idcategoria",
                            SqlDbType = SqlDbType.VarChar,
                            Value = Articulo.Idcategoria
                        };
                        sqlcmd.Parameters.Add(ParIdcategoria);

                        SqlParameter ParIdpresentacion = new SqlParameter
                        {
                            ParameterName = "@idpresentacion",
                            SqlDbType = SqlDbType.VarChar,
                            Value = Articulo.Idpresentacion
                        };
                        sqlcmd.Parameters.Add(ParIdpresentacion);

                        Respuesta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : " No se actualizo el registro";

                    }


                }
                catch (Exception ex)
                {

                    Respuesta = ex.Message;
                    
                }

                return Respuesta;

            }


        }

        public string Eliminar(Darticulo Articulo)
        {
            using (var sqlcon = Getconection())
            {
                string Respuesta = "";
                try
                {
                    using(var sqlcmd = GetSqlCommand())
                    {
                        sqlcon.Open();
                        sqlcmd.Connection = sqlcon;
                        sqlcmd.CommandText = "speliminar_articulo";
                        sqlcmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter
                        {
                            ParameterName = "@idarticulo",
                            SqlDbType = SqlDbType.Int,
                            Value = Articulo.Idarticulo
                        };
                        sqlcmd.Parameters.Add(ParIdarticulo);

                        Respuesta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";
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
            using (var sqlcon = Getconection())
            {
                using (var datatable =GetDataTable("articulo"))
                { 
                    sqlcon.Open();
                    try
                    {                     
                        using (var sqlcmd = GetSqlCommand())
                        {
                            sqlcmd.Connection = sqlcon;
                            sqlcmd.CommandText = "spmostrar_articulo";
                            sqlcmd.CommandType = CommandType.StoredProcedure;

                            using (var Sqldata = Getdataadapter(sqlcmd))
                            {
                                Sqldata.Fill(datatable);
                            }
                        }
                    }
                    catch (Exception )
                    {
                    }
                    return datatable;
                }
            }
        }

        public DataTable Buscarnombre(Darticulo Articulo)
        {
            using (var sqlcon = Getconection())
            {
                using ( var dtresultado = GetDataTable(""))
                {
                    try
                    {
                        using (var sqlcmd = GetSqlCommand())
                        {
                            sqlcon.Open();
                            sqlcmd.Connection = sqlcon;
                            sqlcmd.CommandText = "spbuscar_nombre_articulo";
                            sqlcmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter partexto = new SqlParameter
                            {
                                ParameterName = "@textobuscar",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Articulo.TextoBuscar
                            };
                            sqlcmd.Parameters.Add(partexto);

                            using (var sqldat = Getdataadapter(sqlcmd)) 
                            {
                                sqldat.Fill(dtresultado);
                            }
                        }
                    }
                    catch (Exception)
                    {                     
                    }
                    return dtresultado;
                }
            }
        } 
    }
}
