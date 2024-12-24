using pjGestionEmpleados.Datos;
using pjGestionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Presentacion
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }
        #region variables

        int i_codigoempleado = 0;
        bool estado_guardar = false;

        #endregion
        #region "Metodos"

        private void Cargar_empleados(string cBuscqueda)
        {

            D_Empleados empleados = new D_Empleados();
            dgvlista.DataSource = empleados.Listar_empleados(cBuscqueda);
            Formato_empleado();
        }

        private void Formato_empleado()
        {

            dgvlista.Columns[0].Width = 45;
            dgvlista.Columns[1].Width = 140;
            dgvlista.Columns[2].Width = 150;
            dgvlista.Columns[3].Width = 80;
            dgvlista.Columns[5].Width = 102;
        }

        private void Cargar_departamentos()
        {

            D_Departamentos departamento = new D_Departamentos();

            cbdepartamento.DataSource = departamento.Listar_departamentos();
            cbdepartamento.ValueMember = "id_departamento";
            cbdepartamento.DisplayMember = "nombre_departamento";
            cbdepartamento.SelectedIndex = -1;
        }

        public void Cargar_cargos()
        {

            D_Cargos cargos = new D_Cargos();

            cbcargo.DataSource = cargos.Listado_cargos();
            cbcargo.ValueMember = "id_cargo";
            cbcargo.DisplayMember = "nombre_cargo";
            cbcargo.SelectedIndex = -1;

        }

        private void Activar_texto(bool bestado)
        {

            txtnombre.Enabled = bestado;
            txtdireccion.Enabled = bestado;
            txttelefono.Enabled = bestado;
            cbdepartamento.Enabled = bestado;
            cbcargo.Enabled = bestado;
            txttelefono.Enabled = bestado;
            txtsalario.Enabled = bestado;
            dtfecha.Enabled = bestado;
            txtbuscar.Enabled = !bestado;
        }
        private void Activar_botones(bool bestado)
        {

            btnbuscar.Enabled = bestado;
            btnactualizar.Enabled = bestado;
            btnnuevo.Enabled = bestado;
    
            btncancelar.Enabled = !bestado;
            btneliminar.Enabled = bestado;
            btnsalir.Enabled = bestado;
            btnguardar.Enabled = !bestado;
            btnsalir.Enabled = bestado;
        }

        private void Seleccionar_empleado()
        {

            i_codigoempleado = Convert.ToInt32(dgvlista.CurrentRow.Cells["ID"].Value);
            txtnombre.Text = Convert.ToString(dgvlista.CurrentRow.Cells["NOMBRE"].Value);
            txtdireccion.Text = Convert.ToString(dgvlista.CurrentRow.Cells["DIRECCION"].Value);
            txtsalario.Text = Convert.ToString(dgvlista.CurrentRow.Cells["SALARIO"].Value);
            txttelefono.Text = Convert.ToString(dgvlista.CurrentRow.Cells["TELEFONO"].Value);
            cbcargo.Text = Convert.ToString(dgvlista.CurrentRow.Cells["CARGO"].Value);
            cbdepartamento.Text = Convert.ToString(dgvlista.CurrentRow.Cells["DEPARTAMENTO"].Value);
            dtfecha.Value = Convert.ToDateTime(dgvlista.CurrentRow.Cells["FECHA NACIMIENTO"].Value);

        }

        private void Guardar_empleado()
        {

            E_empleados empleado = new E_empleados();

            empleado.nombre_empleado = txtnombre.Text;
            empleado.direccion_empleado = txtdireccion.Text;
            empleado.telefono_empleado = txttelefono.Text;
            empleado.salario_empleado = Convert.ToDecimal(txtsalario.Text);
            empleado.fecha_nacimiento_empleado = dtfecha.Value;
            empleado.id_cargo = Convert.ToInt32(cbcargo.SelectedValue);
            empleado.id_departamento = Convert.ToInt32(cbdepartamento.SelectedValue);

            D_Empleados datos = new D_Empleados();

            string resultado = datos.Guardar_empleado(empleado);

            if (resultado.ToUpper().Equals("OK"))
            {

                Cargar_empleados("%");
                Limpiar();
                Activar_texto(false);
                Activar_botones(true);
                MessageBox.Show("Datos guardados correctamente", "Sistema de Gestion de empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show(resultado, "Sistema de Gestion deee empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Actualizar_empleado()
        {

            E_empleados empleado = new E_empleados();

            empleado.id_empleado = i_codigoempleado;
            empleado.nombre_empleado = txtnombre.Text;
            empleado.direccion_empleado = txtdireccion.Text;
            empleado.telefono_empleado = txttelefono.Text;
            empleado.salario_empleado = Convert.ToDecimal(txtsalario.Text);
            empleado.fecha_nacimiento_empleado = dtfecha.Value;
            empleado.id_cargo = Convert.ToInt32(cbcargo.SelectedValue);
            empleado.id_departamento = Convert.ToInt32(cbdepartamento.SelectedValue);

            D_Empleados datos = new D_Empleados();

            string resultado = datos.Actualizar_empleado(empleado);

            if (resultado.ToUpper().Equals("OK"))
            {

                Cargar_empleados("%");
                Limpiar();
                Activar_texto(false);
                Activar_botones(true);
                MessageBox.Show("Datos Actualizados correctamente", "Sistema de Gestion de empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show(resultado, "Sistema de Gestion deee empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Eliminar_empleado(int iCodigoEmpleado)
        {

            D_Empleados datos = new D_Empleados();

            string resultado = datos.Eliminar_empleado(iCodigoEmpleado);

            if (resultado.ToUpper().Equals("OK"))
            {

                Cargar_empleados("%");
                Limpiar();
                Activar_texto(false);
                Activar_botones(true);
                MessageBox.Show("Datos Eliminados correctamente", "Sistema de Gestion de empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show(resultado, "Sistema de Gestion deee empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private bool ValidarTexto()
        {

            bool textovacio = false;

            if (string.IsNullOrEmpty(txtnombre.Text)) textovacio = true;
            if (string.IsNullOrEmpty(txtsalario.Text)) textovacio = true;
            if (string.IsNullOrEmpty(txttelefono.Text)) textovacio = true;

            return textovacio;

        }
        private void Limpiar()
        {

            txtnombre.Clear();
            txtdireccion.Clear();
            txtsalario.Clear();
            txttelefono.Clear();
            txtbuscar.Clear();

            cbcargo.SelectedIndex = -1;
            cbdepartamento.SelectedIndex = -1;

            dtfecha.Value = DateTime.Now;

            i_codigoempleado = 0;


        }

        #endregion
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            estado_guardar = true;
            Activar_texto(true);
            Activar_botones(false);
            txtnombre.Select();
        }

        private void dgvlista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar_empleado();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            Cargar_empleados("%");
            Cargar_departamentos();
            Cargar_cargos();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            Cargar_empleados(txtbuscar.Text);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (ValidarTexto())
            {

                MessageBox.Show("Hay campos vacios", "Sistema de Gestion de empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (estado_guardar == true)
                {

                    Guardar_empleado();

                }
                else
                {

                    Actualizar_empleado();

                }

            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {

            estado_guardar = true;
            i_codigoempleado = 0;
            Activar_botones(true);
            Activar_texto(false);

            Limpiar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Cargar_empleados(txtbuscar.Text);
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            if (i_codigoempleado == 0)
            {

                MessageBox.Show("Selecciona un registro", "Sistema de Gestion de empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                estado_guardar = false;

                Activar_texto(true);

                Activar_botones(false);

                txtnombre.Select();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (i_codigoempleado == 0)
            {

                MessageBox.Show("Selecciona un registro", "Sistema de Gestion de empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                DialogResult result = MessageBox.Show("¿Estas seguro de eliminar este empleado?", "Sistema de Gestion de empleados", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {

                    Eliminar_empleado(i_codigoempleado);

                }
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
