using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstitutoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace InstitutoMVC
{
    public class InstitutoContext : DbContext
    {

        public InstitutoContext(DbContextOptions<InstitutoContext> options ) : base(options)
        {

        }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Inscripcion> Inscripciones { get; set; }
    }
}
