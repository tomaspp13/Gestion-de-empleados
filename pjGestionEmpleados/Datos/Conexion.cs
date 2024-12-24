using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjGestionEmpleados.Datos
{
    namespace Gestiondeempleados.Datos
    {
        public class Conexion
        {

            private string Base;
            private string servidor;
            private string usuario;
            private string clave;
            private static Conexion con = null;

            private Conexion()
            {

                this.Base = "Gestiondeclientes";
                this.servidor = "DESKTOP-MBBH9EN\\SQLEXPRESS";
                this.usuario = "tomassilva";
                this.clave = "12345";

            }

            public SqlConnection Crear_conexion()
            {

                SqlConnection cadena = new SqlConnection();

                try
                {
                    cadena.ConnectionString = "Server=" + this.servidor + "; Database=" + this.Base + "; User id=" + this.usuario + "; Password=" + this.clave;
                }
                catch (Exception ex)
                {
                    cadena = null;
                    throw ex;

                }

                return cadena;
            }

            public static Conexion Crear_instancia()
            {

                if (Conexion.con == null)
                {

                    Conexion.con = new Conexion();

                }

                return con;
            }

        }
    }

}
