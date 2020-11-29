using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Capadatos.SQLserver;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Linq;

namespace Capadatos
{
    public class Dusuario : Conexion
    {

        string ContrasenaAleatoria = string.Empty;

        private int _Idusuario;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Usuario;
        private string _Password;
        private byte[] _Salpassword;
        private string _TextoBuscar;
        private int _Codigousuario;
        private int _Codigorol;
        private string _Estatususu;
        private string Cpassword;


        public int Idusuario { get => _Idusuario; set => _Idusuario = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public int Codigousuario { get => _Codigousuario; set => _Codigousuario = value; }
        public int Codigorol { get => _Codigorol; set => _Codigorol = value; }
        public string Estatususu { get => _Estatususu; set => _Estatususu = value; }
        public byte[] Salpassword { get => _Salpassword; set => _Salpassword = value; }

        public Dusuario()
        {

        }

        public Dusuario(Usuarios usuarios)
        {
            this.Idusuario = usuarios.Idusuario;
            this.Nombre = usuarios.nombre;
            this.Apellidos = usuarios.apellidos;
            this.Sexo = usuarios.sexo;
            this.Fecha_Nacimiento = usuarios.fecha_nacimiento;
            this.Num_Documento = usuarios.num_documento;
            this.Direccion = usuarios.direccion;
            this.Telefono = usuarios.telefono;
            this.Email = usuarios.email;
            this.Usuario = usuarios.usuario;
            this.Password = usuarios.password;
            this.TextoBuscar = usuarios.textobuscar;
            this.Salpassword = usuarios.Salpassword;
        }

        public static byte[] GetSalt()
        {
            var P = new RNGCryptoServiceProvider();
            var Salt = new byte[16];
            P.GetBytes(Salt);
            return Salt;
        }

        public static byte[] GetsecureHash(string Password, byte[] Salt)
        {
            Rfc2898DeriveBytes PBK = new Rfc2898DeriveBytes(Password, Salt);
            return PBK.GetBytes(64);
        }

        public string Insertar(Dusuario Usuario)
        {
            using (var SqlCon = Getconection())
            {
                string Respuesta;
                SqlCon.Open();
                try
                {
                    using (var SqlCmd = GetSqlCommand())
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = "spinsertar_usu2";
                        SqlCmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParIdtrabajador = new SqlParameter
                        {
                            ParameterName = "@Idusuario ",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                        SqlCmd.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParNombre = new SqlParameter
                        {
                            ParameterName = "@Nombre",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Usuario.Nombre
                        };
                        SqlCmd.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter
                        {
                            ParameterName = "@Apellidos",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 30,
                            Value = Usuario.Apellidos
                        };
                        SqlCmd.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter
                        {
                            ParameterName = "@Sexo",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 1,
                            Value = Usuario.Sexo
                        };
                        SqlCmd.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nacimiento = new SqlParameter
                        {
                            ParameterName = "@fecha_nac",
                            SqlDbType = SqlDbType.Date,
                            Size = 50,
                            Value = Usuario.Fecha_Nacimiento
                        };
                        SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                        SqlParameter ParNum_Documento = new SqlParameter
                        {
                            ParameterName = "@num_doc",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 8,
                            Value = Usuario.Num_Documento
                        };
                        SqlCmd.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter
                        {
                            ParameterName = "@Direccion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = Usuario.Direccion
                        };
                        SqlCmd.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter
                        {
                            ParameterName = "@Telefono",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10,
                            Value = Usuario.Telefono
                        };
                        SqlCmd.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter
                        {
                            ParameterName = "@Email",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Usuario.Email
                        };
                        SqlCmd.Parameters.Add(ParEmail);

                        SqlParameter ParUsuario = new SqlParameter
                        {
                            ParameterName = "@Usuario",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Usuario.Usuario
                        };
                        SqlCmd.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter
                        {

                            ParameterName = "@claveusu",
                            SqlDbType = SqlDbType.VarBinary,
                            Size = 5000,
                            Value = GetsecureHash(Usuario.Password,GetSalt())
                        };
                        SqlCmd.Parameters.Add(ParPassword);

                        SqlParameter Saltpassword = new SqlParameter
                        {

                            ParameterName = "@Saltpassword",
                            SqlDbType = SqlDbType.Binary,
                            Size = 50,
                            Value = Usuario.Salpassword
                        };
                        SqlCmd.Parameters.Add(Saltpassword);

                        Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Registro";
                    }
                }
                catch (Exception ex)
                {
                    Respuesta = ex.Message;

                }
                return Respuesta;
            }
        }


        public string Insertarrol(Dusuario dusuario)
        {
            using (var SqlCon = Getconection())
            {
                string Respuesta = "";
                SqlCon.Open();
                try
                {                   
                    using (SqlCommand Sqlcmd = GetSqlCommand())
                    {
                        Sqlcmd.Connection = SqlCon;
                        Sqlcmd.CommandText = "spinsertarrol";
                        Sqlcmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter Paridusuario = new SqlParameter
                        {
                            ParameterName = "@Codigousuario",
                            SqlDbType = SqlDbType.Int,
                            Value = dusuario.Idusuario
                        };
                        Sqlcmd.Parameters.Add(Paridusuario);

                        SqlParameter Paridrol = new SqlParameter
                        {
                            ParameterName = "@codigoro",
                            SqlDbType = SqlDbType.Int,
                            Value = dusuario.Codigorol
                        };
                        Sqlcmd.Parameters.Add(Paridrol);


                        SqlParameter Parestatus = new SqlParameter
                        {
                            ParameterName = "@statususu",
                            SqlDbType = SqlDbType.VarChar,
                            Value = dusuario.Estatususu
                        };
                        Sqlcmd.Parameters.Add(Parestatus);
                        Respuesta = Sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No se Inserto el rol del usuario";
                    }
                }
                catch (Exception ex)
                {

                    Respuesta = ex.Message;
                }
                return Respuesta;
            }
        }
         
            
        public string Editar(Dusuario Usuario)
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
                        SqlCmd.CommandText = "speditar_usu";
                        SqlCmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParIdtrabajador = new SqlParameter
                        {
                            ParameterName = "@Idusuario",
                            SqlDbType = SqlDbType.Int,
                            Value = Usuario.Idusuario
                        };
                        SqlCmd.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParNombre = new SqlParameter
                        {
                            ParameterName = "@Nombre",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Usuario.Nombre
                        };
                        SqlCmd.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter
                        {
                            ParameterName = "@Apellidos",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 30,
                            Value = Usuario.Apellidos
                        };
                        SqlCmd.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter
                        {
                            ParameterName = "@Sexo",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 1,
                            Value = Usuario.Sexo
                        };
                        SqlCmd.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nacimiento = new SqlParameter
                        {
                            ParameterName = "@fecha_nac",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Usuario.Fecha_Nacimiento
                        };
                        SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                        SqlParameter ParNum_Documento = new SqlParameter
                        {
                            ParameterName = "@num_doc",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 8,
                            Value = Usuario.Num_Documento
                        };
                        SqlCmd.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter
                        {
                            ParameterName = "@Direccion",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Value = Usuario.Direccion
                        };
                        SqlCmd.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter
                        {
                            ParameterName = "@Telefono",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10,
                            Value = Usuario.Telefono
                        };
                        SqlCmd.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter
                        {
                            ParameterName = "@Email",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = Usuario.Email
                        };
                        SqlCmd.Parameters.Add(ParEmail);

                        SqlParameter ParUsuario = new SqlParameter
                        {
                            ParameterName = "@Usuario",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Usuario.Usuario
                        };
                        SqlCmd.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter
                        {
                            ParameterName = "@claveusu",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 20,
                            Value = Usuario.Password
                        };
                        SqlCmd.Parameters.Add(ParPassword);


                        Respuesta = SqlCmd.ExecuteNonQuery()==1 ? "OK":"No se Actalizo el Registro";
                        
                    }
                }
                catch (Exception ex)
                {

                    Respuesta = ex.Message;
                   
                }
                return Respuesta;
            }
        }

        public string Eliminar(Dusuario Usuario)
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
                        SqlCmd.CommandText = "speliminar_usu";
                        SqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter
                        {
                            ParameterName = "@Idusuario",
                            SqlDbType = SqlDbType.Int,
                            Value = Usuario.Idusuario
                        };
                        SqlCmd.Parameters.Add(ParIdtrabajador);

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
            using (var SqlCon = Getconection())
            {
                SqlCon.Open();
                using ( var Dtresultado = GetDataTable("Usuario"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spmostar_usuario";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            using (var sqldat = Getdataadapter(SqlCmd))
                            {
                                sqldat.Fill(Dtresultado);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return Dtresultado;
                }
            }
        }

        public DataTable Buscarapellidos(Dusuario Usuario)
        {
            using(var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("Usuario"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spbuscar_apellidos_usu";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Usuario.TextoBuscar
                            };
                            SqlCmd.Parameters.Add(ParTextoBuscar);

                            using (var sqldat = Getdataadapter(SqlCmd))
                            {
                                sqldat.Fill(Dtresultado);
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

        public DataTable Buscarnum_doc(Dusuario Usuario)
        {
            using (var SqlCon = Getconection())
            {
                using (var Dtresultado = GetDataTable("Usuario"))
                {
                    try
                    {
                        using (var SqlCmd = GetSqlCommand())
                        {
                            SqlCmd.Connection = SqlCon;
                            SqlCmd.CommandText = "spnum_doc_usu";
                            SqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter ParTextoBuscar = new SqlParameter
                            {
                                ParameterName = "@texto",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 50,
                                Value = Usuario.TextoBuscar
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


        private bool Isvalidpassword(string usuario,string Password)
        {
            Loguin0(usuario);
            bool isvalid = false;
            if (!string.IsNullOrEmpty(Datoscahe.Nombre))
            {
              byte[] Hash = HashPasswordWithSalt(Encoding.UTF8.GetBytes(Password),Datoscahe.Saltresult);

                if (Hash.SequenceEqual(Datoscahe.Passwordresult))
                    isvalid = true;
            }
            return isvalid;
        }

        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedHash = Combine(toBeHashed, salt);

                return sha256.ComputeHash(combinedHash);
            }
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        public bool Login(string Nombre,string Contrasena)
        {
            using (var conection = Getconection())
            {
                conection.Open();
                using (var command = GetSqlCommand())
                {
                    Loguin0(Nombre);
                    byte[] Epass = GetsecureHash(Contrasena, Datoscahe.Saltresult);
                    command.Connection = conection;
                    command.CommandText = "splogueo";
                    command.Parameters.AddWithValue("@usuario", Nombre);
                    command.Parameters.AddWithValue("@claveusu", Epass);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Datoscahe.Idusuario = reader.GetInt32(0);
                            Datoscahe.Nombre = reader.GetString(1);



                            Obtenerrol();
                            Estatusop();
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public void Loguin0(string usuario)
        {
            using (var conection = Getconection())
            {
                conection.Open();
                using (var command = GetSqlCommand())
                {
                    command.Connection = conection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = ("select usuario,claveusu,Saltpassword from Usuario where usuario =@usuario");
                    command.Parameters.Add("@usuario", SqlDbType.VarChar, 20).Value = usuario;
                    using (SqlDataReader Reader = command.ExecuteReader())
                    {
                        if (Reader.HasRows)
                        {
                            while (Reader.Read())
                            {
                                Datoscahe.Saltresult = (byte[])Reader["Saltpassword"];
                                Datoscahe.Passwordresult = (byte[])Reader["claveusu"];
                                Datoscahe.Nombre = Reader["claveusu"].ToString();
                            }                              
                        }
                    }
                }
            }
        }

        private bool IsvalidPasswor(string usuario, string contrasena)
        {
            bool isvalid = false;
            Loguin0(usuario);
            if (!string.IsNullOrEmpty(usuario))
            {
                byte[] Hash = GetsecureHash(contrasena, Datoscahe.Saltresult);
                if (Hash == Datoscahe.Passwordresult)               
                    isvalid = true;
            }
            return isvalid;                  
        }


        public static byte[] Contrasena(string Password,byte[] Salt)
        {
            Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(Password,Salt);
            return PBKDF2.GetBytes(64);
        }

        public bool Isguid()
        {
            string Thisguid = GetMachingGuid();
            using ( StreamReader Sr = new StreamReader("data\\guid\\id.ls"))
            {
                string Readguid = Sr.ReadLine();
                while (Readguid != null)
                {
                    if (Thisguid == Readguid)
                    {
                        Sr.Close();
                        return false;
                    }
                    else if (Readguid == null)
                    {
                        Sr.Close();
                        return true;
                    }
                }
                return true;
            }
        }


        public void Obtenerrol()
        {
            using (var conection = Getconection())
            {
                conection.Open();
                using (var command = GetSqlCommand())
                {

                    command.Connection = conection;
                    command.CommandText = (" select * from Roles_usuario where Codigousuario = @Codigousuario ");
                    command.Parameters.AddWithValue("@Codigousuario", Datoscahe.Idusuario);
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader Reader = command.ExecuteReader())
                    {
                        if (Reader.HasRows)
                        {
                            while (Reader.Read())
                                Datoscahe.Idrol = Reader.GetInt32(1);

                        }
                    }

                }

            }

        }

        public bool ValidarOpcion(int codigorol, string nombreopcion)
        {
            using (var conection = Getconection())
            {
                conection.Open();
                string strsql = "select * from vistapermisos where codigorol = '" + codigorol + "' and subopcion like  '" + nombreopcion + "' ";
                using (DataTable dt = GetDataTable(""))
                {
                    using (SqlDataAdapter da = Getsqlcon(strsql, conection))
                    {
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            return bool.Parse(dt.Rows[0]["acceder"].ToString());

                        }
                        else
                        {
                            return true;
                        }
                    }
                 
                }
               
            }

        }

        public void Estatusop()
        {
            using (var conection = Getconection())
            {
                conection.Open();
                using (var command = GetSqlCommand())
                {
                    command.Connection = conection;
                    command.CommandText = ("select statususu from Roles_usuario where Codigousuario =@Codigousuario ");
                    command.Parameters.AddWithValue("@Codigousuario", Datoscahe.Idusuario);
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader Reader = command.ExecuteReader())
                    {
                        if (Reader.HasRows)
                        {
                            while (Reader.Read())
                                Datoscahe.estatus = Reader.GetString(0);

                        }
                    }
                }

            }

        }


    public void Sendemail(string Correo, string Asunto)
        {
            using (var  Conection = Getconection())
            {
                Conection.Open();
                using (var Comand = GetSqlCommand())
                {
                    Generarcontrasena();
                    
                    Comand.Connection = Conection;
                    Comand.CommandText = "SendEmail";
                    Comand.CommandType = CommandType.StoredProcedure;
                    Comand.Parameters.AddWithValue("@Recipiente",Correo);
                    Comand.Parameters.AddWithValue("@Subject",Asunto);
                    Comand.Parameters.AddWithValue("@Cuerpo",ContrasenaAleatoria);
                    Comand.ExecuteNonQuery();
                }
            }
        }    

        public void Generarcontrasena()
        {
            Random Rdn = new Random();
            string Caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = Caracteres.Length;
            char Letra;
            int Longitudcontrasenia = 10;
            for (int i = 0; i < Longitudcontrasenia; i++)
            {
                Letra = Caracteres[Rdn.Next(longitud)];
                ContrasenaAleatoria += Letra.ToString();
            }

        }

        public bool Login2() 
        {
            using (var conection = Getconection())
            {
               Datoscahe.Keyserial=GetMachingGuid();  
                conection.Open();
                using (var command = GetSqlCommand())
                {
                    command.Connection = conection;
                    command.CommandText = "select * from Computadora_id where Identificador =@identificador and Estatus = @Estatus";
                    command.Parameters.AddWithValue("@identificador",GetMachingGuid());
                    command.Parameters.AddWithValue("@Estatus","Activa");
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Datoscahe.Estatus_compu = reader.GetString(3);
                            Computadora.Nombre_compu = reader.GetString(1);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public string Passwordrecovery(string usuario)
        {
            using (var Conection = Getconection())
            {
                Conection.Open();
                using (var comand = GetSqlCommand())
                {
                    comand.Connection = Conection;
                    comand.CommandText = "select * from Usuario where nombre =@nombre or Email =@Email";
                    comand.Parameters.AddWithValue("@nombre",usuario);
                    comand.Parameters.AddWithValue("@Email",usuario);
                    comand.CommandType = CommandType.Text;
                    using (SqlDataReader Sqldata = comand.ExecuteReader())
                    {
                        if (Sqldata.Read() == true)
                        {
                            string Nombreusuario = Sqldata.GetString(1) + " , " + Sqldata.GetString(2);
                            string Emailusuario = Sqldata.GetString(8);
                            string contrasena = Sqldata.GetString(10);

                            var soportedesistema = new Soportedesistema();
                            soportedesistema.SendMail(
                                Subject: "SYSTEM: Recuperación de contraseña", body: "Hola" + Nombreusuario + "\n solicitud de recuperacion de contraseña.\n" +
                                "su contraseña es:" + contrasena + "\n Debe cambiar la contraseña despues que inicie sesion en el sistema.",
                                recipienteMail: new List<string> { Emailusuario });

                            return "Hola" + Nombreusuario + "\n Pediste una recuperacion de tu contraseña.\n" +
                                "Por favor revice  su Correo: " + Emailusuario + "\n Debe cambiar su contraseña inmediatamente inisie sesion";

                        }
                        else
                        {
                            return "Lo sentimos al parecer no tiene una cuenta registrada con nosotros";
                        }
                    }

                }
            }
        }

       

    }
}
