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
  public class Dcliente:Conexion
    {

        private int _Idcliente;

        private string _Nombre;

        private string _Apellidos;

        private string _Sexo;

        private DateTime _Fecha_Nacimiento;

        private string _Tipo_Documento;

        private string _Num_Documento;


        private string _Direccion;

        private string _Telefono;

        private string _Email;

        private string _TextoBuscar;

        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }



        public Dcliente()
        {

        }
        
        public Dcliente(Clientes C)
        {
            this.Idcliente = C.idcliente;
            this.Nombre = C.nombre;
            this.Apellidos = C.apellidos;
            this.Sexo = C.sexo;
            this.Fecha_Nacimiento = C.fecha_nacimiento;
            this.Tipo_Documento = C.tipo_documento;
            this.Num_Documento = C.num_documento;
            this.Direccion = C.direccion;
            this.Telefono = C.telefono;
            this.Email = C.email;
            this.TextoBuscar = C.textobuscar;

        }



        public string Insertar(Dcliente Cliente)
        {
            using(var SqlCon = Getconection())
            {
                string Respuesta = "";
                SqlCon.Open();
                try
                {
                    using (var SqlCmd = GetSqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "spinsertar_cliente";
                        SqlCmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParIdcliente = new SqlParameter
                        {
                            ParameterName = "@idcliente",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                        SqlCmd.Parameters.Add(ParIdcliente);

                        SqlParameter ParNombre = new SqlParameter
                        {
                            ParameterName = "@Nombre",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Nombre
                        };
                        SqlCmd.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter
                        {
                            ParameterName = "@Apellidos",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 40,
                            Value = Cliente.Apellidos
                        };
                        SqlCmd.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter
                        {
                            ParameterName = "@Sexo",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Sexo
                        };
                        SqlCmd.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nacimiento = new SqlParameter
                        {
                            ParameterName = "@Fecha_nacimiento",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Fecha_Nacimiento
                        };
                        SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                        SqlParameter ParTipoDocumento = new SqlParameter
                        {
                            ParameterName = "@tipo_docu",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Cliente.Tipo_Documento
                        };
                        SqlCmd.Parameters.Add(ParTipoDocumento);

                        SqlParameter ParNum_Documento = new SqlParameter
                        {
                            ParameterName = "@num_doc",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 11,
                            Value = Cliente.Num_Documento
                        };
                        SqlCmd.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter
                        {
                            ParameterName = "@Direccion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Direccion
                        };
                        SqlCmd.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter
                        {
                            ParameterName = "@Telefono",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10,
                            Value = Cliente.Telefono
                        };
                        SqlCmd.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter
                        {
                            ParameterName = "@Email",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Email
                        };
                        SqlCmd.Parameters.Add(ParEmail);

                        //Ejecutamos nuestro comando

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


                    }
                }
                catch (Exception ex)
                {
                    Respuesta = ex.Message;
                    
                }
                return Respuesta;
            }
        }

        public string Editar(Dcliente Cliente)
        {
            using (var SqlCon = Getconection())
            {
                string Respuesta = "";
                SqlCon.Open();
                try
                {
                    using (var SqlCmd = new SqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "speditar_cli";
                        SqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcliente = new SqlParameter
                        {
                            ParameterName = "@idcliente",
                            SqlDbType = SqlDbType.Int,
                            Value = Cliente.Idcliente
                        };
                        SqlCmd.Parameters.Add(ParIdcliente);

                        SqlParameter ParNombre = new SqlParameter
                        {
                            ParameterName = "@Nombre",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Nombre
                        };
                        SqlCmd.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter
                        {
                            ParameterName = "@Apellidos",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 40,
                            Value = Cliente.Apellidos
                        };
                        SqlCmd.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter
                        {
                            ParameterName = "@Sexo",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Sexo
                        };
                        SqlCmd.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nacimiento = new SqlParameter
                        {
                            ParameterName = "@Fecha_nacimiento",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Fecha_Nacimiento
                        };
                        SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                        SqlParameter ParTipoDocumento = new SqlParameter
                        {
                            ParameterName = "@tipo_docu",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Cliente.Tipo_Documento
                        };
                        SqlCmd.Parameters.Add(ParTipoDocumento);

                        SqlParameter ParNum_Documento = new SqlParameter
                        {
                            ParameterName = "@num_doc",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 11,
                            Value = Cliente.Num_Documento
                        };
                        SqlCmd.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter
                        {
                            ParameterName = "@Direccion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Direccion
                        };
                        SqlCmd.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter
                        {
                            ParameterName = "@Telefono",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10,
                            Value = Cliente.Telefono
                        };
                        SqlCmd.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter
                        {
                            ParameterName = "@Email",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Cliente.Email
                        };
                        SqlCmd.Parameters.Add(ParEmail);

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";

                    }
                }
                catch (Exception)
                {

                    
                }
                return Respuesta;
            }
        }

        public string Eliminar(Dcliente Cliente)
        {
            using (var SqlCon = Getconection())
            {
                string Respuesta = "";
                SqlCon.Open();
                try
                {
                    using(var SqlCmd = new SqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "speliminar_cli";
                        SqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcliente = new SqlParameter
                        {
                            ParameterName = "@idcliente",
                            SqlDbType = SqlDbType.Int,
                            Value = Cliente.Idcliente
                        };
                        SqlCmd.Parameters.Add(ParIdcliente);

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";

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
            using (var Sqlcon = Getconection())
            {
                Sqlcon.Open();
                using (var Datatable = GetDataTable("cliente"))
                {
                    try
                    {
                        using (var sqlcmd =GetSqlCommand())
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.CommandText = "spmostrar_cliente";
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

        public DataTable BuscarApellidos(Dcliente Cliente)
        {
            using (var Sqlcon = Getconection())
            {
                Sqlcon.Open();
                using (var Datatable = GetDataTable("cliente"))
                {
                    try
                    {
                        using (var sqlcmd = GetSqlCommand())
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.CommandText = "spbuscar_cliente_apellidos";
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Cliente.TextoBuscar
                            };
                            sqlcmd.Parameters.Add(ParTextoBuscar);
                            
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

        public DataTable Buscarnum_documento(Dcliente Cliente)
        {
            using (var Sqlcon = Getconection())
            {
                Sqlcon.Open();
                using (var Datatable = new DataTable("cliente"))
                {
                    try
                    {
                        using (var sqlcmd = GetSqlCommand())
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.CommandText = "spbuscarnum_doc_cliente";
                            sqlcmd.CommandType = CommandType.StoredProcedure;


                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Cliente.TextoBuscar
                            };
                            sqlcmd.Parameters.Add(ParTextoBuscar);

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
