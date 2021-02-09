using InstitutoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoMVC.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly InstitutoContext _context;

        public ProfesoresController(InstitutoContext context)
        {
            _context = context;
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([Bind("Nombre, Apellido, DNI, Email, FechaNacimiento, Domicilio, Telefono")] Profesor profesor)
        {

            profesor.Id = Guid.NewGuid();

            _context.Profesores.Add(profesor);
            _context.SaveChanges();

            return View("Detalle", profesor);
        }

        public IActionResult Actualizar(Guid id)
        {
            Profesor profesor = _context.Profesores.Find(id);

            return View(profesor);
        }

        [HttpPost]
        public IActionResult Actualizar([Bind("Id, Nombre, Apellido, DNI, Email, FechaNacimiento, Domicilio, Telefono, legajo")] Profesor profesor)
        {

            _context.Profesores.Update(profesor);

            _context.SaveChanges();

            return View("Detalle", profesor);
        }

        public IActionResult Listar()
        {
            return View(_context.Profesores);
        }

        public IActionResult Delete(Guid id)
        {
            Profesor profesor = _context.Profesores.Find(id);
            _context.Profesores.Remove(profesor);
            _context.SaveChanges();
            return View("Listar", _context.Profesores);
        }

    }
}
