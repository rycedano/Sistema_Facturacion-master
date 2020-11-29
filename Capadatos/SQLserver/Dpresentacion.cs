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
    public class Dpresentacion: Conexion
    {

        private int _Idpresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }


        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public Dpresentacion()
        {

        }

        public Dpresentacion(Presentacion P)
        {
            this.Idpresentacion = P.idpresentacion;
            this.Nombre = P.nombre;
            this.Descripcion = P.descripcion;
            this.TextoBuscar = P.textobuscar;
        }

        public string Insertar(Dpresentacion Presentacion)
        {
            string rpta;
            using (var SqlCon = Getconection()) {
                try
                {
                    //Código

                    SqlCon.Open();
                    //Establecer el Comando
                    SqlCommand SqlCmd = GetSqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "spinsertar_presentacion";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIdpresentacion = new SqlParameter
                    {
                        ParameterName = "@idpresentacion",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    SqlCmd.Parameters.Add(ParIdpresentacion);

                    SqlParameter ParNombre = new SqlParameter
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = Presentacion.Nombre
                    };
                    SqlCmd.Parameters.Add(ParNombre);

                    SqlParameter ParDescripcion = new SqlParameter
                    {
                        ParameterName = "@descripcion",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 256,
                        Value = Presentacion.Descripcion
                    };
                    SqlCmd.Parameters.Add(ParDescripcion);

                    //Ejecutamos nuestro comando

                    rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


                }
            catch (Exception ex)
                {
                    rpta = ex.Message;
                }
                
                return rpta;
            }
        }

        public string Editar(Dpresentacion Presentacion)
        {
            string rpta;
            using (var SqlCon = Getconection())
            {
                try
                {
                    //Código

                    SqlCon.Open();
                    //Establecer el Comando
                    SqlCommand SqlCmd = GetSqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "speditar_presentacion";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIdpresentacion = new SqlParameter
                    {
                        ParameterName = "@idpresentacion",
                        SqlDbType = SqlDbType.Int,
                        Value = Presentacion.Idpresentacion
                    };
                    SqlCmd.Parameters.Add(ParIdpresentacion);

                    SqlParameter ParNombre = new SqlParameter
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = Presentacion.Nombre
                    };
                    SqlCmd.Parameters.Add(ParNombre);

                    SqlParameter ParDescripcion = new SqlParameter
                    {
                        ParameterName = "@descripcion",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 256,
                        Value = Presentacion.Descripcion
                    };
                    SqlCmd.Parameters.Add(ParDescripcion);

                    //Ejecutamos nuestro comando

                    rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


                }
                catch (Exception ex)
                {
                    rpta = ex.Message;
                }
              
                return rpta;
            }
        }

        public string Eliminar(Dpresentacion Presentacion)
        {
            string Rpta;
            using (var SqlCon = Getconection())
            {
                try
                {
                    //Código

                    SqlCon.Open();
                    //Establecer el Comando
                    SqlCommand SqlCmd = GetSqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "speliminar_presentacion";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIdpresentacion = new SqlParameter
                    {
                        ParameterName = "@idpresentacion",
                        SqlDbType = SqlDbType.Int,
                        Value = Presentacion.Idpresentacion
                    };
                    SqlCmd.Parameters.Add(ParIdpresentacion);


                    //Ejecutamos nuestro comando

                    Rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


                }
                catch (Exception ex)
                {
                    Rpta = ex.Message;
                }

                return Rpta;
            }
        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = GetDataTable("presentacion");
            using (var SqlCon = Getconection())
            {
                try
                {

                    SqlCommand SqlCmd = GetSqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "spmostrar_presentacion";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter SqlDat = Getdataadapter(SqlCmd);
                    SqlDat.Fill(DtResultado);

                }
                catch (Exception )
                {
                    DtResultado = null;
                }
                return DtResultado;
            }
        }

        public DataTable BuscarNombre(Dpresentacion Presentacion)
        {
            DataTable DtResultado = GetDataTable("presentacion");
            using (var SqlCon = Getconection())
            {
                try
                {

                    SqlCommand SqlCmd = GetSqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "spbuscar_presentacionnombre";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParTextoBuscar = new SqlParameter
                    {
                        ParameterName = "@textobuscar",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = Presentacion.TextoBuscar
                    };
                    SqlCmd.Parameters.Add(ParTextoBuscar);

                    SqlDataAdapter SqlDat = Getdataadapter(SqlCmd);
                    SqlDat.Fill(DtResultado);

                }
                catch (Exception )
                {
                    DtResultado = null;
                }
                return DtResultado;
            }
        }   
    }
}
