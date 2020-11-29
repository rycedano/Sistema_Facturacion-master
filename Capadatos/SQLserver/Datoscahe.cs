 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capadatos.SQLserver
{
   public static class Datoscahe 
    {

        public static int Idusuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellidos { get; set; }
        public static string Sexo { get; set; }
        public static DateTime Fecha_nacimiento { get; set; }
        public static string Num_documento { get; set; }
        public static string Direccion { get; set; }
        public static string Telefono { get; set; }
        public static string Email { get; set; }
        public static int Idrol { get; set; }
        public static string Usuario { get; set; }
        public static string Password { get; set; }
        public static string estatus { get; set; }
        public static string Keyserial { get; set; }
        public static string Estatus_compu { get; set; }
        public static string Nombre_compu { get; set; }
        public static byte[] Saltresult { get; set; }
        public static byte[] Passwordresult { get; set; }

    }


    public static class Clasemodelo
    {
        public static int ID_Pieza { get; set; }
        public static string Descripcion_pi { get; set; }
        public static int Costo_pi { get; set; }
        public static int Precio_pi { get; set; }
        public static int Imp_pi { get; set; }
        public static Int32 ID_marca_pi;
    }

    public class Articulos
    {
        public  int idarticulo { get; set; }
        public  string codigo { get; set; }
        public  string nombre { get; set; }
        public  string descripcion { get; set; }
        public  byte[] imagen { get; set; }
        public  int idcategoria { get; set; }
        public  int idpresentacion { get; set; }
        public  string textobuscar { get; set; }
    }

    public class Categorias
    {
        public int idcategoria { get; set; }
        public  string nombre { get; set; }
        public  string descripcion { get; set; }
        public  string textobuscar { get; set; }
    }

    public class Clientes
    {
        public  int idcliente { get; set; }
        public  string nombre { get; set; }
        public  string apellidos { get; set; }
        public  string sexo { get; set; }
        public  DateTime fecha_nacimiento { get; set; }
        public  string tipo_documento { get; set; }
        public  string num_documento { get; set; }
        public  string direccion { get; set; }
        public  string telefono { get; set; }
        public  string email { get; set; }
        public  string textobuscar { get; set; }
    }

    public class detalleventa
    {
        public  int iddetalle_venta { get; set; }
        public  int idventa { get; set; }
        public  int iddetalle_ingreso { get; set; }
        public  int cantidad { get; set; }
        public  decimal precio_venta { get; set; }
        public  decimal descuento { get; set; }
    }

    public class Presentacion
    {
        public  int idpresentacion { get; set; }
        public  string nombre { get; set; }
        public  string descripcion { get; set; }
        public  string textobuscar { get; set; }
    }

    public class Venta
    {
        public  int idventa { get; set; }
        public  int idcliente { get; set; }
        public  int idtrabajador { get; set; }
        public  DateTime fecha { get; set; }
        public  string tipo_comprobante { get; set; }
        public  string serie { get; set; }
        public  string correlativo { get; set; }
        public  decimal igv { get; set; }
    }

    public class detalleingreso
    {
        public  int iddetalle_ingreso { get; set; }
        public  int idingreso { get; set; }
        public  int idarticulo { get; set; }
        public  decimal precio_compra { get; set; }
        public  decimal precio_venta { get; set; }
        public  int stock_inicial { get; set; }
        public  int stock_actual { get; set; }
        public  DateTime fecha_produccion { get; set; }
        public  DateTime fecha_vencimiento { get; set; }
    }

    public class Ingreso
    {
        public int idingreso { get; set; }
        public int idtrabajador { get; set; }
        public int idproveedor { get; set; }
        public DateTime fecha { get; set; }
        public string tipo_comprobante { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public decimal igv { get; set; }
        public string estado { get; set; }
    }

    public class Proveedores
    {
        public  int idproveedor { get; set; }
        public  string razon_social { get; set; }
        public  string sector_comercial { get; set; }
        public  string tipo_documento { get; set; }
        public  string num_documento { get; set; }
        public  string direccion { get; set; }
        public  string telefono { get; set; }
        public  string email { get; set; }
        public  string url { get; set; }
        public  string textobuscar { get; set; }
    }

    public class Usuarios
    {
        public  int Idusuario { get; set; }
        public  string nombre { get; set; }
        public  string apellidos { get; set; }
        public  string sexo { get; set; }
        public  DateTime fecha_nacimiento { get; set; }
        public  string num_documento { get; set; }
        public  string direccion { get; set; }
        public  string telefono { get; set; }
        public  string email { get; set; }
        public  string acceso { get; set; }
        public  string usuario { get; set; }
        public  string password { get; set; }
        public  string textobuscar { get; set; }
        public  byte[] Salpassword { get; set; }
    }

    public static class Computadora
    {
        public static string Estatus_compu { get; set; }
        public static string Nombre_compu { get; set; }
    }


}
