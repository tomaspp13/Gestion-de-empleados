using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjGestionEmpleados.Entidades
{
    public class E_empleados
    {
        public int id_empleado { get; set; }
        public string nombre_empleado { get; set; }
        public string direccion_empleado { get; set; }
        public DateTime fecha_nacimiento_empleado { get; set; }
        public string telefono_empleado { get; set; }
        public decimal salario_empleado { get; set; }
        public int id_departamento { get; set; }
        public int id_cargo { get; set; }

    }

}
