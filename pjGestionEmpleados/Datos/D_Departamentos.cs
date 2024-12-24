using pjGestionEmpleados.Datos.Gestiondeempleados.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Datos
{
    public class D_Departamentos
    {
        public DataTable Listar_departamentos()
        {
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                con = Conexion.Crear_instancia().Crear_conexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_DEPARTAMENTOS", con);
                comando.CommandType = CommandType.StoredProcedure;

                con.Open();

                resultado = comando.ExecuteReader();
                tabla.Load(resultado);

                return tabla;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                throw ex;

            }
            finally
            {

                if (con.State == ConnectionState.Open) con.Close();

            }

        }

    }
}
