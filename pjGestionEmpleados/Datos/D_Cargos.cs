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
    public class D_Cargos
    {

        public DataTable Listado_cargos()
        {

            SqlConnection con = new SqlConnection();
            DataTable lista = new DataTable();
            SqlDataReader resultado;

            try
            {

                con = Conexion.Crear_instancia().Crear_conexion();

                SqlCommand comando = new SqlCommand("SP_LISTAR_CARGOS", con);

                comando.CommandType = CommandType.StoredProcedure;

                con.Open();

                resultado = comando.ExecuteReader();

                lista.Load(resultado);

                return lista;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {

                if (con.State == ConnectionState.Open)
                {

                    con.Close();

                }

            }
        }
    }
}
