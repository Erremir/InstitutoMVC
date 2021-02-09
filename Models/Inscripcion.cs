using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoMVC.Models
{
    public class Inscripcion
    {

        [Key]
        public Guid Id { get; set; }

        public Guid CursoId { get; set; }

        public Guid AlumnoId { get; set; }



        public Curso Curso { get; set; }

        public Alumno Alumno { get; set; }
    }
}
