using InstitutoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoMVC.Controllers
{
    public class AlumnosController : Controller
    {

        private readonly InstitutoContext  _context;

        public AlumnosController (InstitutoContext context)
        {
            _context = context;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([Bind("Nombre, Apellido, DNI, Email, FechaNacimiento, Domicilio, Telefono, Legajo")] Alumno alumno) {

            alumno.Id = Guid.NewGuid();

            _context.Alumnos.Add(alumno);
            _context.SaveChanges();

            return View("Detalle",alumno);
        }
        
        public IActionResult Actualizar(Guid id)
        {
            Alumno alumno = _context.Alumnos.Find(id);

            return View(alumno);
        }

        [HttpPost]
        public IActionResult Actualizar([Bind("Id, Nombre, Apellido, DNI, Email, FechaNacimiento, Domicilio, Telefono, Legajo")] Alumno alumno)
        {

            _context.Alumnos.Update(alumno);
            _context.SaveChanges();

            return View("Detalle", alumno);
        }

        public IActionResult Listar()
        {
            IEnumerable<Alumno> Alumnos = _context.Alumnos;
            return View(Alumnos);
        }

        public IActionResult Delete(Guid id)
        {
            Alumno alumno = _context.Alumnos.Find(id);
            
            _context.Alumnos.Remove(alumno);
            _context.SaveChanges();

            return View("Listar", _context.Alumnos);
        }

    }
}
