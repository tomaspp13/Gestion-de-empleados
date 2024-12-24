using pjGestionEmpleados.Datos.Gestiondeempleados.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjGestionEmpleados.Entidades;

namespace pjGestionEmpleados.Datos
{
    public class D_Empleados
    {

        public DataTable Listar_empleados(string Cbusqueda)
        {

            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();

            try
            {

                con = Conexion.Crear_instancia().Crear_conexion();
                SqlCommand comando = new SqlCommand("SP_LISTAR_EMPLEADOS", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("cBusqueda", SqlDbType.VarChar).Value = Cbusqueda;
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

                if (con.State == ConnectionState.Open)
                {

                    con.Close();
                }
            }
        }

        public string Guardar_empleado(E_empleados empleado)
        {

            string respuesta = "";
            SqlConnection con = new SqlConnection();

            try
            {

                con = Conexion.Crear_instancia().Crear_conexion();

                SqlCommand command = new SqlCommand("SP_GUARDAR_EMPLEADOS", con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = empleado.nombre_empleado;

                command.Parameters.Add("@cDireccion", SqlDbType.VarChar).Value = empleado.direccion_empleado;

                command.Parameters.Add("@cFechaNacimiento", SqlDbType.Date).Value = empleado.fecha_nacimiento_empleado;

                command.Parameters.Add("@cTelefono", SqlDbType.VarChar).Value = empleado.telefono_empleado;

                command.Parameters.Add("@cSalario", SqlDbType.Decimal).Value = empleado.salario_empleado;

                command.Parameters.Add("@cIddepartamento", SqlDbType.Int).Value = empleado.id_departamento;

                command.Parameters.Add("@cIdcargo", SqlDbType.Int).Value = empleado.id_cargo;

                con.Open();

                respuesta = command.ExecuteNonQuery() >= 1 ? "Ok" : "Datos no ingresados";

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

            return respuesta;

        }

        public string Actualizar_empleado(E_empleados empleado)
        {

            SqlConnection con = new SqlConnection();
            string respuesta = "";

            try
            {

                con = Conexion.Crear_instancia().Crear_conexion();

                SqlCommand command = new SqlCommand("SP_ACTUALIZAR_EMPLEADO", con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@cId", SqlDbType.Int).Value = empleado.id_empleado;

                command.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = empleado.nombre_empleado;

                command.Parameters.Add("@cDireccion", SqlDbType.VarChar).Value = empleado.direccion_empleado;

                command.Parameters.Add("@cFechaNacimiento", SqlDbType.Date).Value = empleado.fecha_nacimiento_empleado;

                command.Parameters.Add("@cTelefono", SqlDbType.VarChar).Value = empleado.telefono_empleado;

                command.Parameters.Add("@cSalario", SqlDbType.Decimal).Value = empleado.salario_empleado;

                command.Parameters.Add("@cIddepartamento", SqlDbType.Int).Value = empleado.id_departamento;

                command.Parameters.Add("@cIdcargo", SqlDbType.Int).Value = empleado.id_cargo;

                con.Open();

                respuesta = command.ExecuteNonQuery() >= 1 ? "OK" : "Datos no ingresados";


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

            return respuesta;

        }

        public string Eliminar_empleado(int iCodigoEmpleado)
        {

            SqlConnection con = new SqlConnection();
            string respuesta = "";

            try
            {

                con = Conexion.Crear_instancia().Crear_conexion();

                SqlCommand command = new SqlCommand("SP_DESACTIVAR_EMPLEADO", con);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@nIdEmpleado", SqlDbType.Int).Value = iCodigoEmpleado;

                con.Open();

                respuesta = command.ExecuteNonQuery() >= 1 ? "OK" : "Datos no ingresados";

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

            return respuesta;

        }

    }

}
