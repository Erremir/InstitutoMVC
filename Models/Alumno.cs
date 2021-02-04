using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoMVC.Models
{
    public class Alumno
    {

        public Guid Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }

        public string Telefono { get; set; }
        public string Legajo { get; set; }

        public List<Curso> Cursos { get; set; }
    }
}
