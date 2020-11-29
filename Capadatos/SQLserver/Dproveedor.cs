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
    public class Dproveedor:Conexion
    {
        private int _Idproveedor;

        private string _Razon_Social;

        private string _Sector_Comercial;

        private string _Tipo_Documento;

        private string _Num_Documento;

        private string _Direccion;

        private string _Telefono;

        private string _Email;

        private string _Url;

        private string _TextoBuscar;

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Razon_Social { get => _Razon_Social; set => _Razon_Social = value; }
        public string Sector_Comercial { get => _Sector_Comercial; set => _Sector_Comercial = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        public Dproveedor()
        {

        }

           public Dproveedor(Proveedores Pro)
           {

            this.Idproveedor = Pro.idproveedor;
            this.Razon_Social = Pro.razon_social;
            this.Sector_Comercial = Pro.sector_comercial;
            this.Tipo_Documento = Pro.tipo_documento;
            this.Num_Documento = Pro.num_documento;
            this.Direccion = Pro.direccion;
            this.Telefono = Pro.telefono;
            this.Email = Pro.email;
            this.Url = Pro.url;
            this.TextoBuscar = Pro.textobuscar;

           }

        public string Insertar(Dproveedor Proveedor)
        {
            using (var SqlCon = Getconection())
            { string Respuesta;
                try
                {
                    
                    SqlCon.Open();
                    using (var SqlCmd = GetSqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "spinsertar_proveedor";
                        SqlCmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParIdproveedor = new SqlParameter
                        {
                            ParameterName = "@idproveedor",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                        SqlCmd.Parameters.Add(ParIdproveedor);

                        SqlParameter ParRazon_Social = new SqlParameter
                        {
                            ParameterName = "@razonsocial",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = Proveedor.Razon_Social
                        };
                        SqlCmd.Parameters.Add(ParRazon_Social);

                        SqlParameter ParSectorComercial = new SqlParameter
                        {
                            ParameterName = "@sectorcomercial",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Proveedor.Sector_Comercial
                        };
                        SqlCmd.Parameters.Add(ParSectorComercial);

                        SqlParameter ParTipoDocumento = new SqlParameter
                        {
                            ParameterName = "@tipodocumento",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Proveedor.Tipo_Documento
                        };
                        SqlCmd.Parameters.Add(ParTipoDocumento);

                        SqlParameter ParNum_Documento = new SqlParameter
                        {
                            ParameterName = "@numdocumento",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 11,
                            Value = Proveedor.Num_Documento
                        };
                        SqlCmd.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter
                        {
                            ParameterName = "@Direccion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 11,
                            Value = Proveedor.Direccion
                        };
                        SqlCmd.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter
                        {
                            ParameterName = "@Telefono",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10,
                            Value = Proveedor.Telefono
                        };
                        SqlCmd.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter
                        {
                            ParameterName = "@Email",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Proveedor.Email
                        };
                        SqlCmd.Parameters.Add(ParEmail);


                        SqlParameter ParUrl = new SqlParameter
                        {
                            ParameterName = "@Url",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = Proveedor.Url
                        };
                        SqlCmd.Parameters.Add(ParUrl);

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";
                    }
                }
                catch (Exception ex)
                {
                    Respuesta = ex.Message;
                   
                }
                return Respuesta;
            }
        }

        public string Editar(Dproveedor Proveedor)
        {
            using (var SqlCon = Getconection())
            {
                SqlCon.Open();
                string Respuesta;
                try
                {
                    using (var SqlCmd = GetSqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "speditar_proveedor";
                        SqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter
                        {
                            ParameterName = "@idproveedor",
                            SqlDbType = SqlDbType.Int,
                            Value = Proveedor.Idproveedor
                        };
                        SqlCmd.Parameters.Add(ParIdproveedor);

                        SqlParameter ParRazon_Social = new SqlParameter
                        {
                            ParameterName = "@razonsocial",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = Proveedor.Razon_Social
                        };
                        SqlCmd.Parameters.Add(ParRazon_Social);

                        SqlParameter ParSectorComercial = new SqlParameter
                        {
                            ParameterName = "@sectorcomercial",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Proveedor.Sector_Comercial
                        };
                        SqlCmd.Parameters.Add(ParSectorComercial);

                        SqlParameter ParTipoDocumento = new SqlParameter
                        {
                            ParameterName = "@tipodocumento",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Proveedor.Tipo_Documento
                        };
                        SqlCmd.Parameters.Add(ParTipoDocumento);

                        SqlParameter ParNum_Documento = new SqlParameter
                        {
                            ParameterName = "@numdocumento",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 11,
                            Value = Proveedor.Num_Documento
                        };
                        SqlCmd.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter
                        {
                            ParameterName = "@Direccion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 11,
                            Value = Proveedor.Direccion
                        };
                        SqlCmd.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter
                        {
                            ParameterName = "@Telefono",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10,
                            Value = Proveedor.Telefono
                        };
                        SqlCmd.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter
                        {
                            ParameterName = "@Email",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Proveedor.Email
                        };
                        SqlCmd.Parameters.Add(ParEmail);


                        SqlParameter ParUrl = new SqlParameter
                        {
                            ParameterName = "@Url",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = Proveedor.Url
                        };
                        SqlCmd.Parameters.Add(ParUrl);
                        //Ejecutamos nuestro comando

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";

                    }
                }
                catch (Exception ex)
                {
                    Respuesta = ex.Message;
                    
                }
                return Respuesta;
            }
        }

        public string Eliminar(Dproveedor Proveedor)
        {
            using (var SqlCon = Getconection())
            {
                string Respuesta;
                try
                {
                    using (var SqlCmd = GetSqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "speliminar_proveedor";
                        SqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter
                        {
                            ParameterName = "@idproveedor",
                            SqlDbType = SqlDbType.Int,
                            Value = Proveedor.Idproveedor
                        };
                        SqlCmd.Parameters.Add(ParIdproveedor);

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";
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
                using (var Datatable = GetDataTable("Categoria"))
                {
                    try
                    {
                        using (var sqlcmd = GetSqlCommand())
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.CommandText = "spmostrar_proveedor";
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

        public DataTable Buscarrazonsocial(Dproveedor Proveedor)
        {
            using (var Sqlcon = Getconection())
            {
                Sqlcon.Open();
                using (var Datatable = GetDataTable("proveedor"))
                {
                    try
                    {
                        using (var sqlcmd = GetSqlCommand())
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.CommandText = "spbuscar_razon_social";
                            sqlcmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter partexto = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Proveedor.TextoBuscar
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

        public DataTable Buscarnum_documento(Dproveedor Proveedor)
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
                            sqlcmd.CommandText = "spbuscar_num_documento";
                            sqlcmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter partexto = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Proveedor.TextoBuscar
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
