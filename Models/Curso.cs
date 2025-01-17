﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoMVC.Models
{
    public class Curso
    {
       
        [Key]
        public Guid Id { get; set; }

        public string Denominacion { get; set; }

        public Guid ProfesorId { get; set; }



        public Profesor Profesor { get; set; }



        public List<Inscripcion> Inscripciones { get; set; }
    }
}
