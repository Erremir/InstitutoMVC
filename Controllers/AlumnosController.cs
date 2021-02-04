using InstitutoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoMVC.Controllers
{
    public class AlumnosController : Controller
    {

        public List<Alumno> Alumnos = new List<Alumno>();

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([Bind("Nombre, Apellido, DNI, Email, FechaNacimiento, Domicilio, Telefono, legajo")] Alumno alumno) {

            alumno.Id = Guid.NewGuid();

            Alumnos.Add(alumno);

            return View("Detalle",alumno);
        }
        
        public IActionResult Actualizar(Guid id)
        {
            Alumno alumno = Alumnos.Find(a => a.Id == id);

            return View(alumno);
        }

        [HttpPut]
        public IActionResult Actualizar([Bind("Id, Nombre, Apellido, DNI, Email, FechaNacimiento, Domicilio, Telefono, legajo")] Alumno alumno)
        {
            Alumno oldAlumno = Alumnos.Find(a => a.Id == alumno.Id);
            Alumnos.Remove(oldAlumno);
            Alumnos.Add(alumno);

            return View("Detalle", alumno);
        }

        public IActionResult Listar()
        {
            return View(Alumnos);
        }

    }
}
