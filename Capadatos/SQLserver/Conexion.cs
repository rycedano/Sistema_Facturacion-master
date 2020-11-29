using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

namespace Capadatos
{
    public class Conexion
    {


        private readonly string conection = ConfigurationManager.ConnectionStrings["sinnombre.Properties.Settings.Setting"].ConnectionString;

        public SqlConnection Getconection()
        {
            return new SqlConnection(conection);
        }


        public DataTable GetDataTable(string v)
        {
            if (v is null)
            {
                throw new ArgumentNullException(nameof(v));
            }
            return new DataTable();
        }



        public SqlDataAdapter Getdataadapter(SqlCommand comand)
        {
            if (comand is null)
            {
                throw new ArgumentNullException(nameof(comand));
            }
            return new SqlDataAdapter(comand);
        }

       

        public SqlCommand GetSqlCommand()
        {       
            return new SqlCommand();
        }

        public SqlDataAdapter Getsqlcon(string V, SqlConnection B)
        {
            if (V is null)
            {
                throw new ArgumentNullException(nameof(V));
            }

            if (B is null)
            {
                throw new ArgumentNullException(nameof(B));
            }
            return new SqlDataAdapter(V,B);
        }



        public void Cargar_combobox(ComboBox box)
        {
            using (var conection = Getconection())
            {              
                using (var comand = GetSqlCommand())
                {
                    comand.CommandText = "select nombrerol from Roles";
                    comand.Connection = conection;
                    conection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(comand);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow Fila = dt.NewRow();
                    Fila["nombrerol"] = "Seleccione_un_Rol";
                    dt.Rows.InsertAt(Fila, 0);

                    box.ValueMember = "Codigorol";
                    box.DisplayMember = "nombrerol";
                    box.DataSource = dt;
                }
            }
        }

        public static string GetMachingGuid()
        {
            string Location = @"SOFTWARE\Microsoft\Cryptography";
            string Name = "MachineGuid";
            using (RegistryKey LocalMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,RegistryView.Registry64))
            {
                using (RegistryKey Rk = LocalMachineX64View.OpenSubKey(Location))
                {
                    if (Rk == null)
                        throw new KeyNotFoundException(string.Format("Key Not Found: {0}", Name));
                    object MachineGuid = Rk.GetValue(Name);
                    if (MachineGuid == null)
                        throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}",Name));
                    return MachineGuid.ToString();
                }
            }
        }

        public  static string Encrypt(string Str)
        {      
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(Str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}",stream[i]);
            return sb.ToString();
        } 



    }   

}
