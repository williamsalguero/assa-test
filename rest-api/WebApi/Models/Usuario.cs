using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Usuario
    {
        public int codigoEmpleado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string DPI { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public DateTime fechaIngreso{ get; set; }
        public string direccion {  get; set; }
        public string NIT { get; set;}
        public int codigoDepartamento { get; set;}
        public int edad { get; set;}
        public string correo { get; set;}
        public string password { get; set;}
    }
}